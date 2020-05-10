import {
  Component, OnInit, ElementRef, Input, AfterViewInit,
  SimpleChanges, OnChanges
} from '@angular/core';


import Map from 'ol/Map';
import { fromLonLat } from 'ol/proj';
import { MapidService } from './mapid.service';
import { MapService } from './map.service';

@Component({
  selector: 'app-common-map',
  template: '',
  styleUrls: ['./common-map.component.scss'],
  providers: [MapidService],
})
export class CommonMapComponent implements OnInit, AfterViewInit, OnChanges {
  public instance: Map;
  public map: Map;
  public componentType: string = 'map';

  @Input() width: string = '100%';
  @Input() height: string = '100%';
  @Input() pixelRatio: number;
  @Input() keyboardEventTarget: Element | string;
  @Input() loadTilesWhileAnimating: boolean;
  @Input() loadTilesWhileInteracting: boolean;
  @Input() logo: string | boolean;
  @Input() renderer: 'canvas' | 'webgl';

  /** Map id
   */
  @Input() id: string;

  /** Longitude of the map
   */
  @Input() lon: string;

  /** Latitude of the map
   */
  @Input() lat: string;

  /** Zoom of the map
   */
  @Input() zoom: number;

  constructor(
    private elementRef: ElementRef,
    private mapService: MapService,
    private mapidService: MapidService) { }

  ngOnInit(): void {
    // Register a new id in the Mapid Service
    this.mapidService.setId(this.id);
    // Create a new map
    this.map = this.mapService.getMap(this.id);

    // If id is not defined place the map in the component element itself
    if (!this.id) {
      this.id = 'map';
      this.map.setTarget(this.elementRef.nativeElement);
    }
    // Center on attribute
    this.map.getView().setCenter(fromLonLat([parseFloat(this.lon) || 0, parseFloat(this.lat) || 0]));
    this.map.getView().setZoom(this.zoom);
  }

  ngOnChanges(changes: SimpleChanges) {

  }

  ngAfterViewInit() {
  }

}
