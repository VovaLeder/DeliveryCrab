import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../service/user.service';
import { User } from '../models/user';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { OrderService } from '../service/order.service';
import { Order } from '../models/order';


@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css'],
})
export class AccountComponent implements OnInit {
  user: User = new User();
  users: User[] = [];
  orders:Order[] = [];
  editMode:boolean|undefined = false;
  formsEdit!:FormGroup;
  constructor(public userService:UserService, private router:Router,private fb: FormBuilder, public orderService:OrderService) { }
  ngOnInit(){
    this.loadUsers();
    this.initForm();
    this.loadOrders();
  }

  initForm(){
    this.formsEdit = this.fb.group({
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
      email: ['',[
        Validators.required,
        Validators.email
      ]],
      password: ['',[
        Validators.required,
      ]]
    });
  }
  loadUsers() {
    this.userService.getUsers()
      .subscribe((data:any)=>this.users = data as User[])
  }
  loadOrders(){
    this.orderService.getOrder()
      .subscribe((data:any)=>this.orders = data as Order[])
  }
  delete(u: User){
    this.userService.deleteUser(u.id)
              .subscribe(data => this.loadUsers());
    this.userService.isAuthorization = false;
    this.router.navigate([''])
  }
  edit(u: User){
    this.user = u;
    this.editMode = true;
  }
  isControlInvalid(controlName: string): boolean {
    const control = this.formsEdit.controls[controlName];
    const result = control.invalid && control.touched;
      return result;
    }

  save(){
    const control = this.formsEdit.controls;
      if(this.formsEdit.invalid){
        Object.keys(control)
        .forEach(controlName => control[controlName].markAsTouched());
        return;
      }
    this.userService.updateUser(this.user)
      .subscribe(data => this.loadUsers());
    this.user = new User();
    this.editMode = false;

}
}
