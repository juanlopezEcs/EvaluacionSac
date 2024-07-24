import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { UserService } from '../app/Services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'evaluacion';

  users: any= [];
  userForm:any ={
    userName: "",
    userGroup:"",
    firstName: "",
    lastName: "",
    email:"",
    dateOfBirth: "",
    pass:""
  };
  constructor(
    private userService:UserService,
    private router: Router,
  ) {
   
  }

  async ngOnInit() {
    await this.getUsers();
  }

  goLoggin(){
    this.router.navigate(["/loggin"]);
  }

  async getUsers() {
    this.users = await this.userService.getUsers().subscribe(users => this.users = users);
    console.log(this.users);
  }

  async addUser() {
    this.users =await this.userService.createUsers(this.userForm).subscribe(users => this.users = users);
    console.log(this.users);

  } 
  
}
