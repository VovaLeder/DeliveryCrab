import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Basket } from '../models/basket';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baskets:Basket[] = [];
  basket:Basket = new Basket();
  sum:number = 0;
  empty:boolean = true;
  constructor(private http: HttpClient) { }
  loadBasket(){
    this.getBasket()
      .subscribe((data:any)=>{
        this.baskets = data as Basket[]
        this.sum = 0;
        for (let o of this.baskets){
          this.sum+=o.price!;
          this.sum = Math.round(this.sum*100)/100;
        }
        if(this.sum != 0){
          this.empty = false;
        }
        else if(this.sum === 0){
          this.empty = true;
        }

      })
  }
  getBasket(){
    return this.http.get("https://localhost:44432/cart")
  }
  postProduct(basket: Basket){
    return this.http.post("https://localhost:44432/cart/postcart", basket);
  }
  deleteProduct(id:number|undefined){
    return this.http.delete("https://localhost:44432/cart/deleteitem/?id=" + id);
  }
  updateCount(basket: Basket){
    return this.http.put("https://localhost:44432/cart/putcart", basket);
  }
}
