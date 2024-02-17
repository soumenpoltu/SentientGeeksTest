import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import Swal from 'sweetalert2';
import { EmployeeServiceService } from '../../services/employee-service.service';
import { EmployeeAddComponent } from '../employee-add/employee-add.component';
import { faPencil, faTrash } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  faPencil = faPencil;
  faTrash = faTrash;
  
  @ViewChild('employeeAdd') employeeAdd: EmployeeAddComponent;
  employeeList: any = [];
  employeeKeys: string = "";

  constructor(private employeeService: EmployeeServiceService) { }
  
  ngOnInit(): void {
    this.getAllList("1");
  }

  getAllList(msg: string) {
    if (msg == "1") {

      Swal.fire({
        title: 'Please Wait !',
        html: 'getting Data...',// add html attribute if you want or remove
        allowOutsideClick: false,
        showConfirmButton: false,
        willOpen: () => {
          Swal.showLoading(null)
        }
      });
      this.employeeService.getAllEmployee().subscribe((data: any) => {
        debugger;
        Swal.close()
        this.employeeList = JSON.parse(data.result);
      }, (error) => {

        Swal.fire("Error", "Error Occured", "error");
        Swal.close()
      })
    }
  }

  showEmployeeAdd() {
    this.employeeAdd.showModal();
  }
  

  closeEmployeeAdd() {
    this.employeeAdd.closeModal();
  }
  showModalEdit(id: any) {

    Swal.fire({
      title: 'Please Wait !',
      html: 'getting Data...',// add html attribute if you want or remove
      allowOutsideClick: false,
      showConfirmButton: false,
      willOpen: () => {
        Swal.showLoading(null)
      }
    });
    this.employeeService.getDtlsEmployee(id).subscribe((data: any) => {
  
      this.employeeAdd.showModalEdit(JSON.parse(data.result));

      Swal.close();
    }, (error) => {

      Swal.fire("Error", "Error Occured", "error");
      Swal.close();
    })

  }

  EmployeeDelete(id: any) {
 
    Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!"
    }).then((result) => {
      if (result.isConfirmed) {

        Swal.fire({
          title: 'Please Wait !',
          html: 'Deleting Data...',// add html attribute if you want or remove
          allowOutsideClick: false,
          showConfirmButton: false,
          willOpen: () => {
            Swal.showLoading(null)
          }
        });

        this.employeeService.deleteEmployee(id).subscribe((data: any) => {
          if (data.result == "true") {
            Swal.fire({
              title: "Success!!",
              text: "Data Deleted",
              icon: "success",
              showCancelButton: false,
              confirmButtonColor: "#3085d6",
              cancelButtonColor: "#d33",
              confirmButtonText: "OK"
            }).then((result) => {
              if (result.isConfirmed) {

                this.getAllList("1");
              }
            });
 
          }
          else {
            Swal.fire("Error", "Error Occured", "error");
          } 
        }, (error) => {

          Swal.fire("Error", "Error Occured", "error");
        })
      }
    });

  }

  selectEmployeeKey(ele: any) {
    debugger;
    if (ele.target.checked) { 
      this.employeeKeys = this.employeeKeys + ele.target.value + ",";
    }
    else {
      this.employeeKeys = this.employeeKeys.replace(ele.target.value + ",", "");
    }
  }

  DeleteMultipleData() {
    debugger;
    if (this.employeeKeys.length <= 1) {
      Swal.fire("Error", "Please select atleast one Employee", "error");
      return;
    }
    Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!"
    }).then((result) => {
      if (result.isConfirmed) {

        Swal.fire({
          title: 'Please Wait !',
          html: 'Deleting Data...',// add html attribute if you want or remove
          allowOutsideClick: false,
          showConfirmButton: false,
          willOpen: () => {
            Swal.showLoading(null)
          }
        });

        this.employeeService.deleteEmployee(this.employeeKeys).subscribe((data: any) => {
          if (data.result == "true") { 
            Swal.fire({
              title: "Success!!",
              text: "Data Deleted",
              icon: "success",
              showCancelButton: false,
              confirmButtonColor: "#3085d6",
              cancelButtonColor: "#d33",
              confirmButtonText: "OK"
            }).then((result) => {
              if (result.isConfirmed) {

                this.getAllList("1");
              }
            });
             
          }
          else {
            Swal.fire("Error", "Error Occured", "error");
          } 
        }, (error) => {

          Swal.fire("Error", "Error Occured", "error");
        })
      }
    });
  }
}
