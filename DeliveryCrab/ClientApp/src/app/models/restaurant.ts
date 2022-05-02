import { Product } from "./product";

export class Restaurant{
  constructor(
    public id?:number,
    public name?:string,
    public icon?:string,
    public address?:string,
    public products?:Array<Product>
  ){}
}
