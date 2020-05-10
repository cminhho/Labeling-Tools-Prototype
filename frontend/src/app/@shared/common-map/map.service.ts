import { Injectable } from '@angular/core';

import Stamen from 'ol/source/Stamen';
import Map from 'ol/Map';
import View from 'ol/View';
import Static from 'ol/source/ImageStatic';
import { Tile as TileLayer, Image as ImageLayer } from 'ol/layer';
import { OSM, ImageArcGISRest } from 'ol/source';
import Projection from 'ol/proj/Projection';
import { getCenter } from 'ol/extent';

/**
 * Openlayers map service to acces maps by id
 * Inject the service in the class that have to use it and access the map with the getMap method.
 * @example
 *
  import { MapService } from '../map.service';
  import Map from 'ol/Map';

  constructor(
    private mapService: MapService,
  ) { }
  ngOnInit() {
    // Get the current map
    const map: Map = this.mapService.getMap('map');
  }
 */
@Injectable({
  providedIn: 'root',
})
export class MapService {
  imageWidth?= 1024;

  imageHeight?= 968;

  /**
   * List of Openlayer map objects [ol.Map](https://openlayers.org/en/latest/apidoc/module-ol_Map-Map.html)
   */
  private map = {};
  private imageExtent: any;

  constructor() {
    this.imageExtent = [0, 0, this.imageWidth, this.imageHeight];
  }

  /**
   * Create a map
   * @param id map id
   * @returns [ol.Map](https://openlayers.org/en/latest/apidoc/module-ol_Map-Map.html) the map
   */
  private createMap(id: any): Map {
    const projection = this.createProjection(this.imageExtent);
    const minZoom = 1;
    const map = new Map({
      // layers: [
      //   new TileLayer({
      //     source: new OSM()
      //   })
      // ],
      target: id,
      view: new View({
        center: [0, 0],
        zoom: 5
      })
    });
    return map;
  }

  createProjection = (imageExtent: any) => {
    return new Projection({
      code: 'xkcd-image',
      units: 'pixels',
      extent: imageExtent,
    });
  };

  createMapView(projection: any, imageExtent: any) {
    const minZoom = 1;
    return new View({
      projection: projection,
      center: getCenter(imageExtent),
      zoom: minZoom,
      maxZoom: 8,
    });
  }

  createImageSource(imageUri: string, projection: any, imageExtent: any) {
    return new Static({
      url: imageUri,
      projection: projection,
      imageExtent: imageExtent,
    });
  }

  /**
   * Get a map. If it doesn't exist it will be created.
   * @param id id of the map or an objet with a getId method (from mapid service), default 'map'
   */
  getMap(id: any): Map {
    id = (id && id.getId ? id.getId() : id) || 'map';
    // Create map if not exist
    if (!this.map[id]) {
      this.map[id] = this.createMap(id);
    }
    // return the map
    return this.map[id];
  }

  /** Get all maps
   * NB: to access the complete list of maps you should use the ngAfterViewInit() method to have all maps instanced.
   * @return the list of maps
   */
  getMaps() {
    return this.map;
  }

  /** Get all maps
   * NB: to access the complete list of maps you should use the ngAfterViewInit() method to have all maps instanced.
   * @return array of maps
   */
  getArrayMaps() {
    return Object.values(this.map);
  }
}
