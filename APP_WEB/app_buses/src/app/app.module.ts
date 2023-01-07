import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { SideNavComponent } from './components/side-nav/side-nav.component';
import { HeaderComponent } from './components/header/header.component';
import { MainComponent } from './pages/main/main.component';
import { CooperativesComponent } from './cooperatives/cooperatives/cooperatives.component';
import { BusesComponent } from './buses/buses/buses.component';
import { AppRoutingModule } from './app-routing.module';
import { FrequenciesComponent } from './frequencies/frequencies/frequencies.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SideNavComponent,
    HeaderComponent,
    MainComponent,
    CooperativesComponent,
    BusesComponent,
    FrequenciesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
