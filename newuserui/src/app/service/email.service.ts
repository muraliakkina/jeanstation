import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Email } from '../Model/email';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  url = environment.url_js;
  constructor(private http:HttpClient) { }
  SendEmail(email: Email): Observable<any> {
    return this.http.post(this.url+"Mail/send", email);
  }

}
