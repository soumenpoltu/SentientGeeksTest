import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  loginUrl = this.baseUrl + 'api/auth/login';

  public login(data: any) {
    let fd = new FormData();
    fd.append("txt_EMAIL", data["txt_EMAIL"]);
    fd.append("txt_PASSWORD", data["txt_PASSWORD"]);
    return this.http.post(this.loginUrl, fd);
  }
}
