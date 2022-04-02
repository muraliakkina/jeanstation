import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from './service/user.service';


@Injectable({
  providedIn: 'root'
})
export class AdmingaurdGuard implements CanActivate {
  constructor(private roleService:UserService, private nab:Router){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if(this.roleService.getRole() == "Admin"){
      return true;
    }
    else if(this.roleService.getRole() == "User"){
      alert("No Access");
      return false
    }
    else{
      this.nab.navigate(["login"])
      return false;
    }
  }
  
}
