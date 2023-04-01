import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './modules/pages/login/login.component';
import { RegistrationComponent } from './modules/pages/registration/registration.component';
import { LandingComponent } from './modules/pages/landing/landing.component';
import { StartToolbarComponent } from './modules/pages/start-toolbar/start-toolbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from "./material/material.module";
import {MatToolbarModule} from '@angular/material/toolbar'; 


@NgModule({
  declarations: [
    AppComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
