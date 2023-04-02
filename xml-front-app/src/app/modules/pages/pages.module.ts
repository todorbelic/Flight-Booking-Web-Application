import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { LandingComponent } from './landing/landing.component';
import { StartToolbarComponent } from './start-toolbar/start-toolbar.component';
import { FlightFormComponent } from './flight-form/flight-form.component'; 
import { MaterialModule } from 'src/app/material/material.module';
import { FormsModule } from '@angular/forms';
import { NewFlightFormComponent } from './new-flight-form/new-flight-form.component';


@NgModule({
  declarations: [
    LoginComponent,
    RegistrationComponent,
    LandingComponent,
    StartToolbarComponent,
    FlightFormComponent,
    NewFlightFormComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule
    
  ]
})
export class PagesModule { }
