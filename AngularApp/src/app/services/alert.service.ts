import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root'} )

export class AlertService {
  constructor() {}

  readonly alert = {
    color: "",
    message: ""
  };

  setAlert(color: string, message: string) {
    this.alert.color = color;
    this.alert.message = message;
    setTimeout(() => {
      this.alert.color = "";
      this.alert.message = "";
    }, 5000);
  }
}
