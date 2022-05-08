export class Order{
  constructor(
    public id?:number,
    public data?:Date,
    public address?:string,
    public userid?:number,
    public description?:string,
    public price?:number
  ){}
}
