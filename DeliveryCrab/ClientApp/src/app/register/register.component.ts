import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../service/user.service';
import { User } from '../models/user';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
    user: User = new User();
    users: User[] = [];
    formsReg!:FormGroup;
    constructor(public userService: UserService, private router:Router, private fb: FormBuilder) { }

    ngOnInit() {
      this.loadUsers();
      this.initForm();
  }
  loadUsers() {
    this.userService.getUsers()
      .subscribe((data:any)=>this.users = data as User[])
  }

  initForm(){
    this.formsReg = this.fb.group({
      firstname: ['', [
        Validators.required,
        Validators.pattern(/[А-я]/)
      ]],
      lastname: ['', [
        Validators.required,
        Validators.pattern(/[А-я]/)
      ]],
      age: ['',[
        Validators.required,
        Validators.min(0),
        Validators.max(100)
      ]],
      login: ['',[
        Validators.required
      ]],
      email: ['',[
        Validators.required,
        Validators.email
      ]],
      password: ['',[
        Validators.required,
      ]]
    });
  }

  isControlInvalid(controlName: string): boolean {
    const control = this.formsReg.controls[controlName];
    const result = control.invalid && control.touched;
      return result;
    }
  save() {
    const control = this.formsReg.controls;
    if(this.formsReg.invalid){
      Object.keys(control)
      .forEach(controlName => control[controlName].markAsTouched());
      return;
    }
    this.userService.createUser(this.user)
      .subscribe((data: User) => this.users.push(data));
    this.userService.isAuthorization = true;
    this.userService.log_user.firstname = this.user?.firstname;
    this.userService.log_user.lastname = this.user?.lastname;
    this.userService.log_user.age = this.user?.age;
    this.userService.log_user.login = this.user?.login;
    this.userService.log_user.email = this.user?.email;
    this.userService.log_user.password = this.user?.password;
    this.router.navigate(['']);
}
}


