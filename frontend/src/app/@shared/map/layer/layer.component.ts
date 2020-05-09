import { Component, Input, OnInit, Host } from '@angular/core';

import { MapService } from '../map.service';
import { MapidService } from '../mapid.service';

import Stamen from 'ol/source/Stamen';
import Map from 'ol/Map';
import View from 'ol/View';
import Static from 'ol/source/ImageStatic';
import { Tile as TileLayer, Image as ImageLayer } from 'ol/layer';
import { OSM, ImageArcGISRest } from 'ol/source';
import Projection from 'ol/proj/Projection';
import { getCenter } from 'ol/extent';

/**
 * Add layers to a map
 * @example
  <app-map>
    <app-layer></app-layer>
  </app-map>
 */
@Component({
  selector: 'app-layer',
  template: '',
})
export class LayerComponent implements OnInit {
  /** Layer */
  @Input() layer: any;
  /** Layer opacity */
  @Input() name: any;
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
  ) {}

  /** Add layer to the map
   */
  ngOnInit() {
    var imageUri = 'http://www.pngall.com/wp-content/uploads/1/World-Map-PNG-File.png';
    // Get the current map
    const map: Map = this.mapService.getMap(this.mapidService);
    // Add the layer
    let tileLayer;
    let layer;
    const imageExtent = [0, 0, 1024, 980];
    const projection = this.mapService.createProjection(imageExtent);
    switch (this.layer) {
      case 'watercolor': {
        layer = new TileLayer({
          source: new Stamen({ layer: 'watercolor' }),
        });
        break;
      }
      case 'labels': {
        layer = new TileLayer({
          source: new Stamen({ layer: 'toner-labels' }),
        });
        break;
      }
      case 'image': {
        tileLayer = new TileLayer({
          source: new OSM(),
        });
        layer = new ImageLayer({
          source: this.mapService.createImageSource(imageUri, projection, [0, 0, 1024, 980]),
        });
        break;
      }
      case 'OSM':
      default: {
        layer = new TileLayer({
          source: new OSM(),
        });
      }
    }
    layer.set('name', this.name || this.layer);
    // layer.setOpacity(this.opacity);
    layer.setOpacity(4);
    layer.setVisible(this.visibility);

    map.addLayer(layer);
    map.addLayer(tileLayer);
    const mapView = this.mapService.createMapView(projection, imageExtent);
    map.setView(mapView);
  }
}
