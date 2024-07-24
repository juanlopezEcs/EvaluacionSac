import { Component } from '@angular/core';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  constructor(
    private _userService:UserService
  ){}

  userForm:any ={
    userName: "",
    userGroup:"",
    firstName: "",
    lastName: "",
    email:"",
    dateOfBirth: "",
    pass:""
  };

  async ngOnInit() {
    
  }

  loggin(){
    let result = this._userService.loggin(this.userForm);
    console.log("Ingreso Loggin: " +result)
  }

}
