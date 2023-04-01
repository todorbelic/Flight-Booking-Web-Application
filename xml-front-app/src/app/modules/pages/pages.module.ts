import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { LandingComponent } from './landing/landing.component';
import { StartToolbarComponent } from './start-toolbar/start-toolbar.component';
import { FlightFormComponent } from './flight-form/flight-form.component'; 
import { MaterialModule } from 'src/app/material/material.module';


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
    MaterialModule
    
  ]
})
export class PagesModule { }
