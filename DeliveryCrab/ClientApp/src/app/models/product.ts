import { Restaurant } from "./restaurant";

export class Product{
  constructor(
    public id?:number,
    public name?:string,
    public image?:string,
    public price?:number,
    public description?:string,
    public restaurantid?:number,
    public restaurant?:Restaurant
  ){}

}
