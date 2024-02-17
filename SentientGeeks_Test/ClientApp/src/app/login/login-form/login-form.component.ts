import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginServiceService } from '../../services/login-service.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  loginform: FormGroup;

  constructor(private loginservice: LoginServiceService, private route: Router) {
    this.loginform = new FormGroup({
      txt_EMAIL: new FormControl('', [Validators.required, Validators.email]),
      txt_PASSWORD: new FormControl('', Validators.required)
    })

  }

  ngOnInit(): void {
  }


  public getlogin() {
    debugger;
    if (this.loginform.invalid) {
      Swal.fire('Required', 'Please fill all field', 'error');
      this.loginform.markAllAsTouched();
      return;
    }

    Swal.fire({
      title: 'Please Wait !',
      html: 'login in...',// add html attribute if you want or remove
      allowOutsideClick: false,
      showConfirmButton: false,
      willOpen: () => {
        Swal.showLoading(null)
      }
    });

    this.loginservice.login(this.loginform.value).subscribe((data:any) => {
      sessionStorage.setItem("token", data["token"]);
      console.log(data);
      Swal.close();
      this.route.navigate(['/employee/employee-list'])
    }, error => {

      Swal.close();
      Swal.fire('Unauthorize', 'Please use correct username and password', 'warning');
      console.error(error);
    });
  }

}
