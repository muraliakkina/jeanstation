import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { observable, Observable } from 'rxjs';
import { AuthUser } from '../Model/authUser';
import { Login } from '../Model/login';
import { User } from '../Model/user';
import { Address } from '../Model/userAddress';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  

  url = environment.url_js
  private isUserLoggedIn: boolean = false;
  private userName: string;
  private userRole: string;
  userid:number;

  constructor(private http: HttpClient, private router: Router) { 
    
  }

  AddNewUser(user: User): Observable<User> {
    return this.http.post<User>(this.url + 'User/Register', user)
  }
  // EditUser(id:number,user:User):Observable<any>{
  //   return this.http.put<any>(this.apiurl+'GetByUserId/'+id,user)
  // }
  AddNewUserAddress(address: Address): Observable<Address> {
    return this.http.post<Address>(this.url + 'User/Address/new', address)
  }
  UserPasswordReset(mail:string,pass:string): Observable<User> {
    let queryParams = new HttpParams().append("email",mail)
    return this.http.put<User>(this.url + 'User/UpdateByUserId/email',pass,{params:queryParams});
  }
  // EditUserAddress(adressid:number,address:Address):Observable<Address>{
  //  return this.http.put<Address>(this.apiurl+'UpdateByAdressId/${addressId}',address)
  // }

  GetUser(userId: number): Observable<User> {

    return this.http.get<User>(this.url + 'User/' + userId);
  }

  CheckEmail(email:string):Observable<any>{
    let queryParams = new HttpParams().append("username",email)
    return this.http.get<any>(this.url+'User',{params:queryParams})
  }

  EditUser(id: number, user: User): Observable<any> {
    return this.http.put<any>(this.url + 'User/GetByUserId/' + id, user)
  }


  DeleteUserAddress(addressid: number): Observable<any> {
    return this.http.delete<any>(this.url + 'User/GetByAdressId/'+addressid);
  }
  GetUserAddressById(userId: number): Observable<Address[]> {
    return this.http.get<Address[]>(this.url + 'User/getaddress/by/userid/' + userId);
  }

  EditUserAddressById(addressId:number,address:Address):Observable<Address>{
    return this.http.put<Address>(this.url+'User/UpdateByAdressId/'+addressId,address)
  }

  Validate(login: Login): Observable<AuthUser> {
    return this.http.post<AuthUser>(this.url + "User/Login", login);
  }

  Logout() {
    localStorage.clear();
    alert('Your session expired')
    this.router.navigateByUrl('/login');
    // return localStorage.getItem('uname') 
  }


  IsLogged() {
    return localStorage.getItem("token") != null;
  }

  getRole(){
    return localStorage.getItem("role")
  }


  public setLoggedInUser(flag) {
    this.isUserLoggedIn = flag;
  }
  public setUserName(name: string) {
    this.userName = name;
  }
  public getUserName() {
    var logincookie = localStorage.getItem('uname');
    if (logincookie != null) {
      return logincookie;
    }
    return this.userName;
  }
  public getUserLoggedIn(): boolean {
    var logincookie = localStorage.getItem('token');
    if (logincookie != null) { return true; }
    return this.isUserLoggedIn;
  }

  public setUserRole(name: string) {
    this.userRole = name
  }



  public getUserRole() {
    var logincookie = localStorage.getItem('role');
    if (logincookie != null) {
      return logincookie;
    }
    return this.userRole;
  }

  public setUserId(id:any){
    this.userid = id;
  }

  public getUserId(){
    var logincookie = +localStorage.getItem('userId');
    if (logincookie != null) {
      return logincookie;
    }
    return this.userid;
  }

}
