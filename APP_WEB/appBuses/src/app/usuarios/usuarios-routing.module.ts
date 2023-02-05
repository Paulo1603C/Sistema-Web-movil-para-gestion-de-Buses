import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageUsuarioComponent } from './pages/page-usuario/page-usuario.component';

const routes: Routes = [
  {path: '', component:PageUsuarioComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuariosRoutingModule { }
