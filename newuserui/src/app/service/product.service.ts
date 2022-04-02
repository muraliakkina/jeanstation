import { Injectable } from '@angular/core';
import { Item } from '../Model/Item';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  url = environment.url_js
  constructor(private http:HttpClient) { }
 

  public getProducts():Observable<Item[]> {
    
    return this.http.get<Item[]>(this.url+'Items')
    
  }

  public getProductById(id):Observable<Item> {
    
    return this.http.get<Item>(this.url+'Items/getItem/'+id)
}
}
