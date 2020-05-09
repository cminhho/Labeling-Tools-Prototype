import { Component, Input, OnInit, Host } from '@angular/core';

import Stamen from 'ol/source/Stamen';
import Map from 'ol/Map';
import View from 'ol/View';
import Static from 'ol/source/ImageStatic';
import { Tile as TileLayer, Image as ImageLayer } from 'ol/layer';
import { OSM, ImageArcGISRest } from 'ol/source';
import Projection from 'ol/proj/Projection';
import { getCenter } from 'ol/extent';
import { MapService } from '../../map.service';
import { MapidService } from '../../mapid.service';

/**
 * Add image layer to a map
 * @example
  <app-map>
    <app-layer></app-layer>
  </app-map>
 */

@Component({
  selector: 'app-image-layer',
  templateUrl: './image-layer.component.html',
  styleUrls: ['./image-layer.component.scss'],
})
export class ImageLayerComponent implements OnInit {
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
  ) {}

  /** Add layer to the map
   */
  ngOnInit() {
    // Get the current map
    const map: Map = this.mapService.getMap(this.mapidService);
    // Add the layer
    let tileLayer;
    let layer;
    const imageExtent = [0, 0, 1024, 980];
    const projection = this.mapService.createProjection(imageExtent);

    tileLayer = new TileLayer({
      source: new OSM(),
    });
    layer = new ImageLayer({
      source: this.mapService.createImageSource(this.imageUri, projection, [0, 0, 1024, 980]),
    });
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
