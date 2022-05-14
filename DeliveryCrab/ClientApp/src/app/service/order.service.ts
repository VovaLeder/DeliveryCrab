import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  orders:Order[] = [];
  order:Order = new Order();

  constructor(private http:HttpClient) { }

  loadOrder(){
    this.getOrder()
      .subscribe((data:any)=>
        this.orders = data as Order[])

  }
  getOrder(){
    return this.http.get("https://localhost:44432/order");
  }
  postOrder(order: Order){
    return this.http.post("https://localhost:44432/order/postorder", order);
  }
  putOrder(order: Order){
    return this.http.put("https://localhost:44432/order/putorder", order)
  }
}
