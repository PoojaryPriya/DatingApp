import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';


@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busyReqCount=0;

  constructor(private spinnerService: NgxSpinnerService) { }

  busy() {
    this.busyReqCount++;
    this.spinnerService.show(undefined,{
      type: 'ball-atom',
      bdColor: 'rgba(255,255,255,0)',
      color: '#FF7518'
    })
  }

  idle() {
    this.busyReqCount--;
    if(this.busyReqCount <= 0){
      this.busyReqCount=0;
      this.spinnerService.hide();
    }
  }
}
