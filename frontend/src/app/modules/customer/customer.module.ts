import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MaterialModule } from 'app/material/material.module';
import { MatToolbar } from '@angular/material/toolbar';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Routes, RouterModule } from '@angular/router';
import { MatDatepicker } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { CustomerHomeComponent } from './customer-home/customer-home.component';
import { CustomerToolbarComponent } from './customer-toolbar/customer-toolbar.component';
import { CustomerTicketsComponent } from './customer-tickets/customer-tickets.component';

const routes: Routes = [
  { path: 'customer-home', component: CustomerHomeComponent },
  { path: 'customer-tickets', component: CustomerTicketsComponent },
];



@NgModule({
  declarations: [
    CustomerHomeComponent,
    CustomerToolbarComponent,
    CustomerTicketsComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    RouterModule.forChild(routes),

    MatInputModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatToolbarModule
    
  ]
})
export class CustomerModule { }
