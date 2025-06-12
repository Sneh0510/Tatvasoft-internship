import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Menu1Service {

  constructor() { }

  onSubmit(name: String) {
    console.log('in service')
    console.log(name)
  }
}
