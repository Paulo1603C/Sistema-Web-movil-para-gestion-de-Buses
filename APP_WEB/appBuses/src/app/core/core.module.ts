import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreRoutingModule } from './core-routing.module';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { HeaderComponent } from './components/header/header.component';
import { SideNavComponent } from './components/side-nav/side-nav.component';
import { LoginComponent } from './pages/login/login.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    MainPageComponent,
    HeaderComponent,
    SideNavComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    CoreRoutingModule,
    RouterModule
  ],
  exports:[
    MainPageComponent,
    HeaderComponent,
    SideNavComponent,
  ]
})
export class CoreModule { }
