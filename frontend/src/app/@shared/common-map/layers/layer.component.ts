import { Component, Input, OnInit, Host } from '@angular/core';

import Map from 'ol/Map';
import OSM from 'ol/source/OSM';
import Stamen from 'ol/source/Stamen';
import OlTileLayer from 'ol/layer/Tile';
import { MapService } from '../map.service';
import { MapidService } from '../mapid.service';

/**
 * Add layers to a map
 * @example
  <app-map>
    <app-layer></app-layer>
  </app-map>
 */
@Component({
  selector: 'app-common-layer',
  template: ''
})

export class CommonLayerComponent implements OnInit {
  /** Layer */
  @Input() layer: any;
  /** Layer opacity */
  @Input() name: any;
  /** Layer opacity */
  @Input() opacity = 1;
  /** Layer visibility */
  @Input() visibility = true;

  /** Define the service
   */
  constructor(
    private mapService: MapService,
    @Host()
    private mapidService: MapidService
  ) { }

  /** Add layer to the map
   */
  ngOnInit() {
    // Get the current map
    const map: Map = this.mapService.getMap(this.mapidService);
    // Add the layer
    let layer;
    switch (this.layer) {
      case 'watercolor': {
        layer = new OlTileLayer({
          source: new Stamen({ layer: 'watercolor' })
        });
        break;
      }
      case 'labels': {
        layer = new OlTileLayer({
          source: new Stamen({ layer: 'toner-labels' })
        });
        break;
      }
      case 'OSM':
      default: {
        layer = new OlTileLayer({
          source: new OSM()
        });
      }
    }
    layer.set('name', this.name || this.layer);
    // layer.setOpacity(this.opacity);
    // layer.setVisible(this.visibility);
    map.addLayer(layer);
  }

}