import { Component, OnInit } from '@angular/core';
import { Basket } from '../models/basket';
import { Product } from '../models/product';
import { Restaurant } from '../models/restaurant';
import { BasketService } from '../service/basket.service';
import { ProductService } from '../service/product.service';
import { RestaurantService } from '../service/restaurant.service';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-chumbucket',
  templateUrl: './chumbucket.component.html',
  styleUrls: ['./chumbucket.component.css']
})
export class ChumbucketComponent implements OnInit {
  basket:Basket = new Basket();
  products:Basket[] = [];
  chumbucket: Restaurant[] = [];
  product:Product[] = [];
  constructor(public restaurantService: RestaurantService, public productService:ProductService,
    public userService:UserService, public basketService:BasketService) { }

  ngOnInit() {
    this.loadRestaurant();
    this.loadProduct();
    this.loadBasket();
  }

  loadRestaurant(){
    this.restaurantService.getRestaurants()
      .subscribe((data:any)=>this.chumbucket = data as Restaurant[])
  }
  loadProduct(){
    this.productService.getProduct()
      .subscribe((data:any)=>this.product = data as Product[])
  }
  loadBasket(){
    this.basketService.getBasket()
      .subscribe((data:any)=>this.products = data as Basket[])
  }
  addToBasket(id:number|undefined, name:string|undefined,price:number|undefined, count:string){
    this.basket.userid = this.userService.log_user.id;
    this.basket.count = parseInt(count);
    this.basket.price = price!*parseInt(count);
    this.basket.productid = id;
    this.basket.productname = name;
    this.basketService.postProduct(this.basket)
      .subscribe((data:Basket)=>this.products.push(data));
  }

}
