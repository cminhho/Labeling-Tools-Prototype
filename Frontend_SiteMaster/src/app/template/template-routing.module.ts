import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TemplateListComponent } from './template-list/template-list.component';
import { TemplateComponent } from './template/template.component';

const routes: Routes = [
  {
    path: '',
    component: TemplateListComponent,
    resolve: {},
    data: {
      authorities: [],
      defaultSort: 'id,asc',
      pageTitle: '',
    },
    canActivate: [],
  },
  {
    path: ':id/view',
    component: TemplateComponent,
    resolve: {},
    data: {
      authorities: [],
      pageTitle: '',
    },
    canActivate: [],
  },
  {
    path: 'new',
    component: TemplateComponent,
    resolve: {},
    data: {
      authorities: [],
      pageTitle: '',
    },
    canActivate: [],
  },
  {
    path: ':id/edit',
    component: TemplateComponent,
    resolve: {},
    data: {
      authorities: [],
      pageTitle: '',
    },
    canActivate: [],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TemplateRoutingModule {}
