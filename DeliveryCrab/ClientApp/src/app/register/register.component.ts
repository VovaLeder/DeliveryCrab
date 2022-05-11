import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../service/user.service';
import { User } from '../models/user';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
    user: User = new User();
    users: User[] = [];
    error_login:string = '';
    list_login:Array<any> = [];
    formsReg!:FormGroup;
    regSuccess:boolean = false;
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
        Validators.pattern(/[А-яA-z]/)
      ]],
      lastname: ['', [
        Validators.required,
        Validators.pattern(/[А-яA-z]/)
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
      .subscribe((data: User) => this.users.push(data),
      (error:HttpErrorResponse)=>console.log(error.status)
      );
    for (let u of this.users){
      this.list_login.push(u.login);
    }
    for (let i=0;i<this.list_login.length;i++){
      if (this.user.login == this.list_login[i]){
        this.error_login = "Такой логин уже существует!!!";
        return;
      }
    }
    this.regSuccess = true;




}
}


