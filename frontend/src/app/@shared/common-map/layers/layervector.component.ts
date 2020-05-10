import { Component, Input, OnInit, Host, OnChanges, SimpleChanges } from '@angular/core';

import Stamen from 'ol/source/Stamen';
import Static from 'ol/source/ImageStatic';
import { Tile as TileLayer, Image as ImageLayer } from 'ol/layer';
import { OSM, ImageArcGISRest } from 'ol/source';
import Projection from 'ol/proj/Projection';
import transform from 'ol/proj/Projection';
import { getCenter } from 'ol/extent';
import { MapService } from '../map.service';
import { MapidService } from '../mapid.service';

import { Feature, MapBrowserEvent } from "ol";
import Layer from "ol/layer/Layer";
import Polygon from 'ol/geom/Polygon';

import Map from 'ol/Map';
import View from 'ol/View';
import GeoJSON from 'ol/format/GeoJSON';
import MultiPoint from 'ol/geom/MultiPoint';
import VectorLayer from 'ol/layer/Vector';
import VectorSource from 'ol/source/Vector';
import { Circle as CircleStyle, Fill, Stroke, Style } from 'ol/style';

/**
 * Add image layer to a map
 * @example
  <app-map>
    <app-vector-layer></app-vector-layer>
  </app-map>
 */

@Component({
  selector: 'app-vector-layer',
  template: '',
  styleUrls: [],
})
export class VectorLayerComponent implements OnInit, OnChanges {

  featureStyler?: any;

  private textVectorLayer: VectorLayer;
  private readonly TEXT_VECTOR_LAYER_NAME = "textVectorLayer";
  private textVectorLayerFilter = {
    layerFilter: (layer: Layer) => layer.get("name") === this.TEXT_VECTOR_LAYER_NAME,
  };

  /** Layer */
  @Input() layer: any;
  /** Layer opacity */
  @Input() name: any;

  @Input() imageUri: any;

  /** Layer opacity */
  @Input() opacity: number = 1;
  /** Layer visibility */
  @Input() visibility = true;

  /** Define the service
   */
  constructor(
    private mapService: MapService,
    @Host()
    private mapidService: MapidService
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (this.imageUri) {
      var styles = [
        new Style({
          stroke: new Stroke({
            color: 'blue',
            width: 3
          }),
          fill: new Fill({
            color: 'rgba(0, 0, 255, 0.1)'
          })
        }),
        new Style({
          image: new CircleStyle({
            radius: 5,
            fill: new Fill({
              color: 'orange'
            })
          }),
          geometry: function (feature: any) {
            // return the coordinates of the first ring of the polygon
            var coordinates = feature.getGeometry().getCoordinates()[0];
            return new MultiPoint(coordinates);
          }
        })
      ];

      var geojsonObject = {
        'type': 'FeatureCollection',
        'crs': {
          'type': 'name',
          'properties': {
            'name': 'EPSG:3857'
          }
        },
        'features': [{
          'type': 'Feature',
          'geometry': {
            'type': 'Polygon',
            'coordinates': [[[-5e6, 6e6], [-5e6, 8e6], [-3e6, 8e6],
            [-3e6, 6e6], [-5e6, 6e6]]]
          }
        }, {
          'type': 'Feature',
          'geometry': {
            'type': 'Polygon',
            'coordinates': [[[-2e6, 6e6], [-2e6, 8e6], [0, 8e6],
            [0, 6e6], [-2e6, 6e6]]]
          }
        }, {
          'type': 'Feature',
          'geometry': {
            'type': 'Polygon',
            'coordinates': [[[1e6, 6e6], [1e6, 8e6], [3e6, 8e6],
            [3e6, 6e6], [1e6, 6e6]]]
          }
        }, {
          'type': 'Feature',
          'geometry': {
            'type': 'Polygon',
            'coordinates': [[[-2e6, -1e6], [-1e6, 1e6],
            [0, -1e6], [-2e6, -1e6]]]
          }
        }]
      };

      var source = new VectorSource({
        features: (new GeoJSON()).readFeatures(geojsonObject)
      });

      var layer = new VectorLayer({
        source: source,
        style: styles
      });
      layer.setOpacity(1);
      layer.setVisible(true);

      // Get the current map
      const map: Map = this.mapService.getMap(this.mapidService);
      map.addLayer(layer);

      const imageExtent = [0, 0, 1024, 980];
      const projection = this.mapService.createProjection(imageExtent);
      const mapView = this.mapService.createMapView(projection, imageExtent);
      map.setView(mapView);
    }
  }

  /** Add layer to the map
   */
  ngOnInit() {

  }

  /**
   * Add one feature to the map
   */
  public addFeature = (feature: Feature) => {
    this.textVectorLayer.getSource().addFeature(feature);
  }

  public addFeatures = (features: Feature[]) => {
    this.textVectorLayer.getSource().addFeatures(features);
  }

  public toggleTextFeatureVisibility = () => {
    this.textVectorLayer.setVisible(!this.textVectorLayer.getVisible());
  }

  private createBoundingBoxVectorFeature = (text: string, boundingBox: any) => {
    const coordinates: any[] = [[8623931.28, 1449016.75], [8624007.72, 1458265.63],
    [8629358.31, 1458571.37], [8628441.06, 1455284.58], [8625765.77, 1449781.12], [8630275.55, 1453450.09],
    [8629281.88, 1452456.42], [8627294.51, 1451080.54], [8625765.76, 1449781.11], [8623931.28, 1449016.75]];

    const featureId = '1';

    const feature = new Feature({
      geometry: new Polygon([coordinates]),
    });

    feature.setProperties({
      id: featureId,
      text,
      boundingbox: boundingBox,
      highlighted: false,
      isOcrProposal: true,
    });

    feature.setId(featureId);
    return feature;
  }
}
