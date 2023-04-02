import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './modules/pages/landing/landing.component';
import { LoginComponent } from './modules/pages/login/login.component';
import { RegistrationComponent } from './modules/pages/registration/registration.component';
import { NewFlightFormComponent } from './modules/pages/new-flight-form/new-flight-form.component';

const routes: Routes = [
  { path: '', component: LandingComponent },
  { path: 'login', component: LoginComponent},
  { path:'registration', component: RegistrationComponent},
  { path: 'new-flight', component: NewFlightFormComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
