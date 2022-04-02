import { Injectable } from '@angular/core';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../Model/Product';
import { Order } from '../Model/Order';
import { Item } from 'src/app/Model/Item';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient) { }

  api:string = environment.url_js

  GetItems():Observable<Item[]>{
    return this.http.get<Item[]>(this.api+'Items')
  }

  GetItemById(id):Observable<Item>{
    return this.http.get<Item>(this.api+'Items/GetItem/'+id)
  }

  AddItem(product:Item):Observable<Item>{
    return this.http.post<Item>(this.api+'Items',product)
  }

  RemoveItem(id:number):Observable<any>{
    return this.http.delete<any>(this.api+`Items/${id}`)
  }

  UpdateItem(id:number,product:Item):Observable<Item>{
    return this.http.put<Item>(this.api+`Items/${id}`,product)
  }

  GetOrders():Observable<Order[]>{
    return this.http.get<Order[]>(this.api+'Order')
  }

  EditOrderStatus(id:number,orderStatus:string):Observable<any>{
    return this.http.put<any>(this.api+`Order/${id}`,orderStatus)
  }



  
}
