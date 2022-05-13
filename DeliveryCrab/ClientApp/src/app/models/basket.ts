export class Basket{
  constructor(
    public id?:number,
    public userid?:number,
    public productid?:number,
    public productname?:string,
    public price?:number|undefined,
    public count?:number|undefined,
    public cost?:number|undefined,
  ){}
}
