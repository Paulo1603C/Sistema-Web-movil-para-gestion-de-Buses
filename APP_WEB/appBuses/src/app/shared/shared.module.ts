import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TableComponent } from './table/table.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { SearchBarComponent } from './search-bar/search-bar.component';


@NgModule({
  declarations: [
    TableComponent,
    SearchBarComponent
  ],
  imports: [
    CommonModule,
    NgxPaginationModule
  ],
  exports: [
    TableComponent,
    NgxPaginationModule,
    SearchBarComponent
  ]
})
export class SharedModule { }
