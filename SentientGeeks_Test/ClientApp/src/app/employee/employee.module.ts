import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeRoutingModule } from '../routing/employee-routing.module';
import { EmployeeAddComponent } from './employee-add/employee-add.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';



@NgModule({
  declarations: [
    EmployeeListComponent,
    EmployeeAddComponent
  ],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    ReactiveFormsModule,
    FontAwesomeModule
  ]
})
export class EmployeeModule { }
