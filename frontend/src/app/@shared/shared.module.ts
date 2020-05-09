import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoaderComponent } from './loader/loader.component';
import { ImageMapComponent } from './image-map/image-map.component';
import { MousePositionComponent } from './map/control/mouse-position.component';
import { InteractionComponent } from './map/interaction/interaction.component';
import { LayerComponent } from './map/layer/layer.component';
import { MapComponent } from './map/map.component';
import { ControlComponent } from './map/control/control.component';
import { MapService } from './map/map.service';
import { ImageLayerComponent } from './map/layer/image-layer/image-layer.component';
import { PdfViewerComponent } from './pdf-viewer/pdf-viewer.component';
import { FormsModule } from '@angular/forms';

const COMPONENTS = [
  LoaderComponent,
  ImageMapComponent,
  MousePositionComponent,
  InteractionComponent,
  LayerComponent,
  MapComponent,
  ControlComponent,
  ImageLayerComponent,
  PdfViewerComponent
];

@NgModule({
  imports: [CommonModule, FormsModule],
  declarations: [...COMPONENTS],
  exports: [...COMPONENTS],
  providers: [MapService],
})
export class SharedModule {}
