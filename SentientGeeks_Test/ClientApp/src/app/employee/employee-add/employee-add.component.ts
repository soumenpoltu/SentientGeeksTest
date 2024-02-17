import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { EmployeeServiceService } from '../../services/employee-service.service';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css']
})
export class EmployeeAddComponent implements OnInit {
  employeeForm: FormGroup;
  @Output() successMsg = new EventEmitter<string>();

  constructor(private employeeService: EmployeeServiceService) {
    this.employeeForm = new FormGroup({
      hf_Id: new FormControl('0', [Validators.required]),
      txt_FullName: new FormControl('', [Validators.required]),
      txt_Address: new FormControl('', Validators.required),
      txt_Phone: new FormControl('', Validators.required),
      txt_Email: new FormControl('',[ Validators.required, Validators.email])
    })


  }

  saveEmployee() {
    if (this.employeeForm.invalid) {
      Swal.fire('Required', 'Please fill all field', 'error');
      this.employeeForm.markAllAsTouched();
      return;
    }

    Swal.fire({
      title: 'Please Wait !',
      html: 'Saving Data...',// add html attribute if you want or remove
      allowOutsideClick: false,
      showConfirmButton: false,
      willOpen: () => {
        Swal.showLoading(null)
      }
    });
    if (this.employeeForm.value["hf_Id"] != "0") {
      this.employeeService.updateEmployee(this.employeeForm.value).subscribe((data: any) => {
        if (data.result == "true") { 
          Swal.fire({
            title: "Success!!",
            text: "Data Updated",
            icon: "success",
            showCancelButton: false,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "OK"
          }).then((result) => {
            if (result.isConfirmed) {
              this.closeModal();
              this.successMsg.emit("1")
            }
          });
        }
        else {
          Swal.fire("Error", "Error Occured", "error");
        } 
      }, error => {
        Swal.fire("Error", "Error Occured", "error");
        Swal.close();
        console.error(error);
      });
    }
    else {
      this.employeeService.saveEmployee(this.employeeForm.value).subscribe((data: any) => {
        if (data.result == "true") {
          Swal.fire({
            title: "Success!!",
            text: "Data Saved",
            icon: "success",
            showCancelButton: false,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "OK"
          }).then((result) => {
            if (result.isConfirmed) {
              this.closeModal();
              this.successMsg.emit("1")
            }
          });
        }
        else {
          Swal.fire("Error", "Error Occured", "error");
        } 
      }, error => {
        Swal.fire("Error", "Error Occured", "error");
        Swal.close();
        console.error(error);
      });
    }
  }

  ngOnInit(): void {
  }

  public showModal() {

    document.getElementById("exampleModalCenter").style.background = "rgba(169, 169, 169, 0.3)";
    this.employeeForm.markAsUntouched();
    this.employeeForm.controls["hf_Id"].setValue("0");
    this.employeeForm.controls["txt_FullName"].setValue("");
    this.employeeForm.controls["txt_Address"].setValue("");
    this.employeeForm.controls["txt_Phone"].setValue("");
    this.employeeForm.controls["txt_Email"].setValue("");

      document.getElementById("exampleModalCenter").style.display = "block";
  }

  public closeModal() {
    document.getElementById("exampleModalCenter").style.background = "";
      document.getElementById("exampleModalCenter").style.display = "none";
  }

  public showModalEdit(data:any) {
    document.getElementById("exampleModalCenter").style.background = "rgba(169, 169, 169, 0.3)";
    this.employeeForm.controls["hf_Id"].setValue(data.MAST_EMPLOYEE_KEY);
    this.employeeForm.controls["txt_FullName"].setValue(data.FULLNAME);
    this.employeeForm.controls["txt_Address"].setValue(data.ADDRESS);
    this.employeeForm.controls["txt_Phone"].setValue(data.PHONE);
    this.employeeForm.controls["txt_Email"].setValue(data.EMAIL);

    document.getElementById("exampleModalCenter").style.display = "block";
  }

}
