import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuariosRoutingModule } from './usuarios-routing.module';
import { PageUsuarioComponent } from './pages/page-usuario/page-usuario.component';
import { ModalComponent } from './components/modal/modal.component';
import { SharedModule } from '../shared/shared.module';
import { CoreModule } from '../core/core.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';



@NgModule({
  declarations: [
    PageUsuarioComponent,
    ModalComponent
  ],
  imports: [
    CommonModule,
    UsuariosRoutingModule,
    SharedModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule
  ]
})
export class UsuariosModule { }
