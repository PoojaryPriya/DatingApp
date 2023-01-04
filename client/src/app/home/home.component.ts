import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode=false;
  users:any;
  model:any={}

  constructor(private http:HttpClient,public accountService:AccountService,private router:Router,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    this.http.get("https://localhost:5001/api/users").subscribe({
      next: response => this.users=response,
      error: error=>console.error(),
      complete: ()=> console.log('Request has completed')
      
    })
  }

  registerToggle() {
    this.registerMode=!this.registerMode;
  }

  cancelRegisterMode(event:boolean){
    this.registerMode=event;
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next:_=>this.router.navigateByUrl('/members'),
      error:error=>this.toastr.error(error.error)
    })
  }

  // clickFunction(event:any){
    
  // }

}
