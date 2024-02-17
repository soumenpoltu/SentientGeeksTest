import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginFormComponent } from '../login/login-form/login-form.component';
const routes: Routes = [
  { path: '', component: LoginFormComponent, pathMatch: 'full' }

]


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)

  ],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
