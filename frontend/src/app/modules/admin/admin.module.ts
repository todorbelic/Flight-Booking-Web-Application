import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminToolbarComponent } from './admin-toolbar/admin-toolbar.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { MaterialModule } from 'app/material/material.module';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { NewFlightFormComponent } from './new-flight-form/new-flight-form.component';

const routes: Routes = [
  { path: 'admin-home', component: AdminHomeComponent },
  { path: 'admin-new-flight', component: NewFlightFormComponent },

];





@NgModule({
  declarations: [
    AdminToolbarComponent,
    AdminHomeComponent,
    NewFlightFormComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    MatInputModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatToolbarModule,
    FormsModule,
    RouterModule.forChild(routes),
  ]
})
export class AdminModule { }
