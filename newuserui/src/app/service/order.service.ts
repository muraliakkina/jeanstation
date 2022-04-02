import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../admin/Model/Order';
import { Item } from '../Model/Item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  url = environment.url_js;
  constructor(private http:HttpClient) { }

 

  PlaceOrder(userid:number,addressid:number):Observable<Order>{
    return this.http.post<Order>(this.url+'Order/'+userid+'/placeorder/'+addressid,{})
  }

  GetOrderbyId(orderid:number):Observable<Order>{
    return this.http.get<Order>(this.url+'Order/orderid/'+orderid)
  }

  GetItemsInOrder(orderId:number):Observable<Item[]>{
    return this.http.get<Item[]>(this.url+'Order/Items/Order/'+orderId)
  }

  GetOrderByUserId(userid:number):Observable<Order[]>{
    return this.http.get<Order[]>(this.url+'Order/'+userid)
  }
}
