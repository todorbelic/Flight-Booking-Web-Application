import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MaterialModule } from 'app/material/material.module';
import { MatToolbar } from '@angular/material/toolbar';
import { Routes, RouterModule } from '@angular/router';
import { MatDatepicker } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { CustomerHomeComponent } from './customer-home/customer-home.component';
import { AppRoutingModule } from 'app/app-routing.module';
import { CustomerToolbarComponent } from './customer-toolbar/customer-toolbar.component';

const routes: Routes = [
  { path: 'customer-home', component: CustomerHomeComponent },

];



@NgModule({
  declarations: [
    CustomerHomeComponent,
    CustomerToolbarComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    RouterModule.forChild(routes),
    AppRoutingModule,
    MatInputModule,
    MatNativeDateModule,
    MatDatepickerModule
    
  ]
})
export class CustomerModule { }
