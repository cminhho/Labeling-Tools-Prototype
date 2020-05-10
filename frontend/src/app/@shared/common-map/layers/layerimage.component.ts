import { Component, Input, OnInit, Host, OnChanges, SimpleChanges } from '@angular/core';

import Map from 'ol/Map';
import { Tile as TileLayer, Image as ImageLayer } from 'ol/layer';
import { MapService } from '../map.service';
import { MapidService } from '../mapid.service';

/**
 * Add image layer to a map
 * @example
  <app-map>
    <app-image-layer></app-image-layer>
  </app-map>
 */

@Component({
  selector: 'app-image-layer',
  template: '',
  styleUrls: [],
})
export class ImageLayerComponent implements OnInit, OnChanges {
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

      // Get the current map
      const map: Map = this.mapService.getMap(this.mapidService);
      // Add the layer
      let imagelayer;
      const imageExtent = [0, 0, 1024, 980];
      const projection = this.mapService.createProjection(imageExtent);

      imagelayer = new ImageLayer({
        source: this.mapService.createImageSource(this.imageUri, projection, imageExtent),
      });

      imagelayer.set('name', this.name || this.layer);
      imagelayer.setOpacity(0.6);
      imagelayer.setVisible(this.visibility);
      map.addLayer(imagelayer);

      const mapView = this.mapService.createMapView(projection, imageExtent);
      map.setView(mapView);
    }
  }

  /** Add layer to the map
   */
  ngOnInit() {

  }
}
