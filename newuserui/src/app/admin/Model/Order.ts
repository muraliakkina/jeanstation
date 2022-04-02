export class Order {
    orderId: number;
    userId: number;
    addressId: number;
    totalProducts: number;
    totalPrice: number;
    //PaymentMethod:string;
    orderStatus:string;
    orderCreatedAt:string;
    

    constructor(orderid:number,userId:number,addressId:number,totalItems:number,totalOrderValue:number,orderStatus:string,orderPlacedAt:string){
        this.orderId = orderid;
        this.userId = userId;
        this.addressId =addressId;
        this.totalProducts =totalItems;
        this.totalPrice =totalOrderValue;
        //this.PaymentMethod = paymentMethod;
        this.orderStatus = orderStatus;
        this.orderCreatedAt = orderPlacedAt;
        
    }
}