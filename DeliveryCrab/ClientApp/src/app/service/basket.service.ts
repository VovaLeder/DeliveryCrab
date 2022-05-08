import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Basket } from '../models/basket';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baskets:Basket[] = [];
  sum:number = 0;
  constructor(private http: HttpClient) { }

  loadBasket(){
    this.getBasket()
      .subscribe((data:any)=>{
        this.baskets = data as Basket[]
        for (let o of this.baskets){
          console.log(o)
          this.sum+=o.price!;
        }
      })
  }
  getBasket(){
    return this.http.get("https://localhost:44432/basket")
  }
  postProduct(basket: Basket){
    return this.http.post("https://localhost:44432/basket/postbasket", basket);
  }
  deleteProduct(id:number|undefined){
    return this.http.delete("https://localhost:44432/basket/deleteitem/?id=" + id);
  }
}
