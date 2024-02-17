import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginFormComponent } from './login-form/login-form.component';
import { LoginRoutingModule } from '../routing/login-routing.module';
import {  ReactiveFormsModule } from '@angular/forms';
 


@NgModule({
  declarations: [
    LoginFormComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    ReactiveFormsModule
  ]
})
export class LoginModule { }
