import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditorPageComponent } from './editor-page/editor-page.component';

const routes: Routes = [
  {
    path: '',
    component: EditorPageComponent,
    resolve: {},
    data: {
      authorities: [],
      defaultSort: 'id,asc',
      pageTitle: '',
    },
    canActivate: [],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LabelingRoutingModule {}
