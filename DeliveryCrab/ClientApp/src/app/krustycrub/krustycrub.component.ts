import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { Restaurant } from '../models/restaurant';
import { ProductService } from '../service/product.service';
import { RestaurantService } from '../service/restaurant.service';

@Component({
  selector: 'app-krustycrub',
  templateUrl: './krustycrub.component.html',
  styleUrls: ['./krustycrub.component.css']
})
export class KrustycrubComponent implements OnInit {
  crustycrub: Restaurant[] = [];
  product:Product[] = [];
  constructor(public restaurantService: RestaurantService, public productService:ProductService) { }

  ngOnInit() {
    this.loadRestaurant();
    this.loadProduct();
  }
  loadRestaurant(){
    this.restaurantService.getRestaurants()
      .subscribe((data:any)=>this.crustycrub = data as Restaurant[])
  }
  loadProduct(){
    this.productService.getProduct()
      .subscribe((data:any)=>this.product = data as Product[])
  }

}
