export class Cart{
    userId:number;
    cartId:number;
    itemId:number;
    itemSize:string;
    itemQuantity:number;
    itemImg1:string;
    itemPrice:number;
    itemName:string;
    itemBrandName:string;

    constructor(userid:number,cartid:number,itemid:number,itemSize:string,itemqty:number,itemImg1:string,itemprice:number,itemname:string,itemBrandname:string){
        this.cartId = cartid;
        this.userId = userid;
        this.itemId = itemid;
        this.itemSize = itemSize;
        this.itemQuantity =itemqty;
        this.itemImg1 = itemImg1;
        this.itemPrice = itemprice;
        this.itemBrandName = itemBrandname;
        this.itemName = itemname;
    }
}