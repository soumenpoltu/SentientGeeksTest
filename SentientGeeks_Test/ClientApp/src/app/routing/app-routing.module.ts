import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JwtModule } from '@auth0/angular-jwt';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../authGuard/auth.guard';

export function tokengetter() {
  return sessionStorage.getItem("token");
}
const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('../login/login.module').then(si => si.LoginModule)
  },
  {
    path: 'employee',
    loadChildren: () => import('../employee/employee.module').then(si => si.EmployeeModule)
  },
  ]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokengetter,
        allowedDomains: ["*"],
        disallowedRoutes: [],

      }
    })

  ], 
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }
