import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http:HttpClient) { }
  getOrder(){
    return this.http.get("https://localhost:44432/order");
  }
  postOrder(order: Order){
    return this.http.post("https://localhost:44432/order/postorder", order);
  }
}
