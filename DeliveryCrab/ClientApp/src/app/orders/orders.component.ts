import { Component, OnInit } from '@angular/core';
import { Order } from '../models/order';
import { OrderService } from '../service/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {


  constructor(public orderService:OrderService) { }
  ngOnInit() {
    this.orderService.loadOrder();
  }

  editOrder(o: Order){
    this.orderService.order = o;
  }
  update(){
    this.orderService.putOrder(this.orderService.order)
      .subscribe(data=>this.orderService.loadOrder());
    this.cancel();
  }

  cancel(){
    this.orderService.order = new Order();
  }
}
