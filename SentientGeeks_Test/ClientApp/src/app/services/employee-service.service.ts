import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  saveEmployeeUrl = this.baseUrl + 'api/employee/SaveEmployee';
  updateEmployeeUrl = this.baseUrl + 'api/employee/UpdateEmployee';
  getAllEmployeeUrl = this.baseUrl + 'api/employee/GetAllEmployee';
  getDtlsEmployeeUrl = this.baseUrl + 'api/employee/GetDtlsEmployee';
  deleteEmployeeUrl = this.baseUrl + 'api/employee/DeleteEmployee';

  public saveEmployee(data: any) {
    let fd = new FormData();
    fd.append("hf_Id", data["hf_Id"]);
    fd.append("txt_FullName", data["txt_FullName"]);
    fd.append("txt_Address", data["txt_Address"]);
    fd.append("txt_Phone", data["txt_Phone"]);
    fd.append("txt_Email", data["txt_Email"]);
    return this.http.post(this.saveEmployeeUrl, fd);
  }
  
  public updateEmployee(data: any) {
    let fd = new FormData();
    fd.append("hf_Id", data["hf_Id"]);
    fd.append("txt_FullName", data["txt_FullName"]);
    fd.append("txt_Address", data["txt_Address"]);
    fd.append("txt_Phone", data["txt_Phone"]);
    fd.append("txt_Email", data["txt_Email"]);
    return this.http.post(this.updateEmployeeUrl, fd);
  }
  
  public getAllEmployee() {
    return this.http.get(this.getAllEmployeeUrl);
  }

  public getDtlsEmployee(id: number) {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("empId", id);

    return this.http.get(this.getDtlsEmployeeUrl, { params: queryParams });
  }
  
  public deleteEmployee(id: any) {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("empId", id);

    return this.http.delete(this.deleteEmployeeUrl, { params: queryParams });
  }

}
