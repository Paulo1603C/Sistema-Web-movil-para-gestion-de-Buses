import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TableComponent } from './table/table.component';
import { NgxPaginationModule } from 'ngx-pagination';


@NgModule({
  declarations: [
    TableComponent
  ],
  imports: [
    CommonModule,
    NgxPaginationModule
  ],
  exports: [
    TableComponent,
    NgxPaginationModule
  ]
})
export class SharedModule { }
