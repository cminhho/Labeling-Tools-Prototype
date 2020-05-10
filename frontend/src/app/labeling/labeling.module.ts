import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LabelingCanvasComponent } from './labeling-canvas/labeling-canvas.component';
import { EditorPageComponent } from './editor-page/editor-page.component';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from '@app/@shared';
import { LabelingRoutingModule } from './labeling-routing.module';
import { EmbededOcrFormToolsComponent } from './embeded-ocr-form-tools/embeded-ocr-form-tools.component';

@NgModule({
  declarations: [LabelingCanvasComponent, EditorPageComponent, EmbededOcrFormToolsComponent],
  imports: [CommonModule, TranslateModule, SharedModule, LabelingRoutingModule],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class LabelingModule {}
