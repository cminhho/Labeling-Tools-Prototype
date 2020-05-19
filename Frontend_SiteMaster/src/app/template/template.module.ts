import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TemplateRoutingModule } from './template-routing.module';
import { TemplateListComponent } from './template-list/template-list.component';
import { TemplateComponent } from './template/template.component';
import { TranslateModule } from '@ngx-translate/core';
import { CoreModule } from '@app/@core';
import { SharedModule } from '@app/@shared';
import { NgbTabsetModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [TemplateListComponent, TemplateComponent],
  imports: [CommonModule, TranslateModule, SharedModule, TemplateRoutingModule, NgbTabsetModule],
})
export class TemplateModule {}
