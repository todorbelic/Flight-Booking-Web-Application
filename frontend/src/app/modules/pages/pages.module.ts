import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { LandingComponent } from './landing/landing.component';
import { StartToolbarComponent } from './start-toolbar/start-toolbar.component';
import { FlightFormComponent } from './flight-form/flight-form.component'; 
import { FormsModule } from '@angular/forms';
import { MaterialModule } from 'app/material/material.module';
import { MatToolbar } from '@angular/material/toolbar';
import { Routes, RouterModule } from '@angular/router';
import { MatDatepicker } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { AppRoutingModule } from 'app/app-routing.module';

const routes: Routes = [
  { path: '', component: LandingComponent },
  { path: 'login', component: LoginComponent},
  { path:'register', component: RegistrationComponent},
];



@NgModule({
  declarations: [
    LoginComponent,
    RegistrationComponent,
    LandingComponent,
    StartToolbarComponent,
    FlightFormComponent,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    MaterialModule,
    FormsModule,
    RouterModule.forChild(routes),

    
    
  ]
})
export class PagesModule { }
