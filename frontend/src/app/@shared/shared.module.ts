import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoaderComponent } from './loader/loader.component';
import { PdfViewerComponent } from './pdf-viewer/pdf-viewer.component';
import { FormsModule } from '@angular/forms';
import { CommonMapComponent } from './common-map/common-map.component';
import { CommonLayerComponent } from './common-map/layers/layer.component';
import { MousePositionComponent } from './common-map/control/mouse-position.component';
import { InteractionComponent } from './common-map/interactions/interaction.component';
import { MapComponent } from './common-map/map.component';
import { ControlComponent } from './common-map/control/control.component';
import { MapService } from './common-map/map.service';
import { ImageLayerComponent } from './common-map/layers/layerimage.component';
import { VectorLayerComponent } from './common-map/layers/layervector.component';

const COMPONENTS = [
  LoaderComponent,
  MousePositionComponent,
  InteractionComponent,
  MapComponent,
  ControlComponent,
  ImageLayerComponent,
  PdfViewerComponent,
  CommonMapComponent,
  CommonLayerComponent,
  VectorLayerComponent
];

@NgModule({
  imports: [CommonModule, FormsModule],
  declarations: [...COMPONENTS],
  exports: [...COMPONENTS],
  providers: [MapService],
})
export class SharedModule {}
