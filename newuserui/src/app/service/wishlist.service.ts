import { Injectable } from '@angular/core';
import { HttpClient, HttpHandler, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError, Observable, Subject, tap, throwError } from 'rxjs';
import { Wishlist } from '../Model/wishlist';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WishlistService {

  // userId:number
  url = environment.url_js
  constructor(private http:HttpClient) {
    // this.userId = +localStorage.getItem("userId")
    // console.log(this.userId);
   }

  
  addToWishList(itemId:number,userId:number):Observable<Wishlist>{
    return this.http.post<Wishlist>(this.url+'whishlist/'+itemId+'/'+userId,{})
  }

  removeFromWishlist(itemId:number,userId:number):Observable<any>{
    return this.http.delete(this.url+'Whishlist/'+userId+'/del/'+itemId)
    
  }

   getWishlistItems(userId:number):Observable<Wishlist[]>{
     return  this.http.get<Wishlist[]>(this.url+'Whishlist/'+userId)
  }

  // public setUserId(id:any){
  //   this.userid = id;
  // }

  // public getUserId(){
  //   var logincookie = +localStorage.getItem('userId');
  //   if (logincookie != null) {
  //     return logincookie;
  //   }
  //   return this.userid;
  // }

  // handleError(error:any) {
  //   let errorMessage = '';
  //   if (error.error instanceof ErrorEvent) {
  //     // client-side error
  //     errorMessage = `Error: ${error.error.message}`;
  //   } else {
  //     // server-side error
  //     errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
  //   }
  //   console.log(errorMessage);
  //   return throwError(() => {
  //       return errorMessage;
  //   });
  // }


}
