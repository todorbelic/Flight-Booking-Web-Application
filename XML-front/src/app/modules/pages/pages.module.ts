import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { LandingComponent } from './landing/landing.component';
import { StartToolbarComponent } from './start-toolbar/start-toolbar.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import { FlightFormComponent } from './flight-form/flight-form.component'; 


@NgModule({
  declarations: [
    LoginComponent,
    RegistrationComponent,
    LandingComponent,
    StartToolbarComponent,
    FlightFormComponent
  ],
  imports: [
    CommonModule,
    MatToolbarModule
    
  ]
})
export class PagesModule { }
