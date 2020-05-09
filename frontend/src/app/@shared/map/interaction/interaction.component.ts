import { Component, Input, OnInit, Host } from '@angular/core';

import { MapService } from '../map.service';
import { MapidService } from '../mapid.service';
import Map from 'ol/Map';
import { Draw, Modify, Snap } from 'ol/interaction';
import { OSM, Vector as VectorSource } from 'ol/source';
import { Tile as TileLayer, Vector as VectorLayer } from 'ol/layer';
import { Circle as CircleStyle, Fill, Stroke, Style } from 'ol/style';

/**
 * Add interactions to a map
 * @example
  <app-map>
    <app-interaction></app-interaction>
  </app-map>
 */
@Component({
  selector: 'app-interaction',
  templateUrl: './interaction.component.html',
})
export class InteractionComponent implements OnInit {
  map: Map;

  source: any;
  snap: any;
  draw: any;

  /** draw type */
  @Input() type: any;

  /** Define the service
   */
  constructor(
    private mapService: MapService,
    @Host()
    private mapidService: MapidService
  ) {}

  /** Add new interaction to the map
   */
  ngOnInit() {
    this.source = new VectorSource();
    var typeSelect = document.getElementById('type');
    var vector = new VectorLayer({
      source: this.source,
      style: new Style({
        fill: new Fill({
          color: 'rgba(255, 255, 255, 0.2)',
        }),
        stroke: new Stroke({
          color: '#ffcc33',
          width: 2,
        }),
        image: new CircleStyle({
          radius: 7,
          fill: new Fill({
            color: '#ffcc33',
          }),
        }),
      }),
    });

    // Get the current map
    this.map = this.mapService.getMap(this.mapidService);
    // Get the second map to synchronize
    const mapId = this.mapidService.getId();
    const map2 = mapId === 'map1' ? 'map' : 'map1';
    // Add interaction
    this.map.addLayer(vector);
  }

  addInteractions(drawType: string) {
    this.map.removeInteraction(this.draw);
    this.map.removeInteraction(this.snap);
    this._addInteractions(drawType);
  }

  removeInteractions() {
    this.map.removeInteraction(this.draw);
    this.map.removeInteraction(this.snap);
  }

  private _addInteractions(drawType: any) {
    this.draw = new Draw({
      source: this.source,
      type: drawType,
    });
    this.map.addInteraction(this.draw);
    this.snap = new Snap({ source: this.source });
    this.map.addInteraction(this.snap);
  }
}
