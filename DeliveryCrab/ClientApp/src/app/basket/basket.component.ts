import { Component, OnInit } from '@angular/core';
import { Basket } from '../models/basket';
import { Order } from '../models/order';
import { BasketService } from '../service/basket.service';
import { OrderService } from '../service/order.service';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  orders:Order[] = [];
  id_list:Array<any> = [];
  order:Order = new Order();
  products:Array<any> = [];
  count:Array<any> = [];
  price:number = 0;
  description:string = '';
  success:boolean = false;

  constructor(public basketService:BasketService, public orderService:OrderService, public userService:UserService) {}

  ngOnInit(){
    this.basketService.loadBasket();
    this.loadOrder();

  }
  loadOrder(){
    this.orderService.getOrder()
      .subscribe((data:any)=>
        this.orders = data as Order[])

  }
  placeAnOrder(){
    for(let b of this.basketService.baskets){
      this.id_list.push(b.id)
      this.products.push(b.productname);
      this.count.push(b.count);
      this.price +=b.price!;
    }
    for (let i=0;i<this.products.length;i++){
      this.description +=this.products[i] + " " + String(this.count[i]) + "шт.\n" ;
    }
    this.order.data = new Date();
    this.order.userid = this.userService.log_user.id;
    this.order.description = this.description;
    this.order.price = this.price;
    this.orderService.postOrder(this.order)
      .subscribe((data: Order)=>this.orders.push(data))
    for (let i of this.id_list){
      this.basketService.deleteProduct(i)
        .subscribe(data=>this.basketService.loadBasket)
    }

    this.success = true;
  }
}
