import { Injectable } from '@angular/core';
import { Item } from '../Model/Item';
import { HttpClient, HttpHandler, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cart } from '../Model/cart';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  
  userId:number
  url = environment.url_js
  constructor(private http:HttpClient) {
    this.userId = +localStorage.getItem("userId")
    //console.log(this.userId);
   }

  cartItems: Cart[] = [];
  getCartItems():Observable<Cart[]>{
    return this.http.get<Cart[]>(this.url+'Cart/'+this.userId)
  }
  
  addToCart(itemId:number,qty:number):Observable<Cart> {
    let queryParams = new HttpParams().append("Qty",qty)
    return this.http.post<Cart>(this.url+'Cart/'+itemId+'/'+this.userId,{},{params:queryParams})
  }

  // getItems() {
  //   return this.cartItems;
  // }

  clearCart():Observable<any> {
    return this.http.delete(this.url+'Cart/'+this.userId)
  }

  removeItem(itemId:number):Observable<any>{
    return this.http.delete(this.url+'Cart/'+this.userId+'/'+itemId)
  }

  increaseItem(itemId:number):Observable<Cart>{
    return this.http.put<Cart>(this.url+'Cart/'+this.userId+'/cart/'+itemId,{})
  }

  decreaseItem(itemId:number):Observable<Cart>{
    return this.http.put<Cart>(this.url+'Cart/dec/'+this.userId+'/'+itemId,{})
  }
}
