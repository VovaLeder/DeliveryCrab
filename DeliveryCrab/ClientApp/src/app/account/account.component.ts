import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../user.service';
import { User } from '../user';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  users: User[] = [];
  constructor(public dataService:DataService, private router:Router) { }
  ngOnInit(): void {
    this.loadUsers()
  }
  loadUsers() {
    this.dataService.getUsers()
      .subscribe((data:any)=>this.users = data as User[])
  }
delete(u: User){
  this.dataService.deleteUser(u.id)
            .subscribe(data => this.loadUsers());
  this.dataService.isAuthorization = false;
  this.router.navigate([''])
}
}
