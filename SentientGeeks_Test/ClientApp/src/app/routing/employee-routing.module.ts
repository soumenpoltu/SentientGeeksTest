import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from '../employee/employee-list/employee-list.component';
import { AuthGuard } from '../authGuard/auth.guard';

const routes: Routes = [
  { path: 'employee-list', component: EmployeeListComponent, pathMatch: 'full', canActivate: [AuthGuard] }

]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)

  ],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
