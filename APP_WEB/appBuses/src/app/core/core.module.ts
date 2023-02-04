import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreRoutingModule } from './core-routing.module';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { HeaderComponent } from './components/header/header.component';
import { SideNavComponent } from './components/side-nav/side-nav.component';
import { LoginComponent } from './pages/login/login.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastContainer } from './pages/login/toast.component';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    MainPageComponent,
    HeaderComponent,
    SideNavComponent,
    LoginComponent,
    ToastContainer
  ],
  imports: [
    CommonModule,
    CoreRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    NgbToastModule
  ],
  exports:[
    MainPageComponent,
    HeaderComponent,
    SideNavComponent,
  ]
})
export class CoreModule { }
