import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map, Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private acountService:AccountService,private toastrService:ToastrService){}

  canActivate(): Observable<boolean> {
    return this.acountService.currentUser$.pipe(
      map(user=>{
        if (user) return true;
        else {
          this.toastrService.error("Opps.. something wrong!");
          return false;
        }
      })
    )
  }
  
}