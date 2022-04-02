import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  userName: string;
  userRole: string;
  constructor(private route: Router, private userService: UserService) {
    //this.userName = localStorage.getItem('uname')
  }

  public getUserLoggedIn(): boolean {
    return this.userService.getUserLoggedIn()
  }
  public getUserName() {
    return this.userService.getUserName();
  }

  public getUserRole(){
     return this.userService.getUserRole();
  }



  ngOnInit(): void {
    this.getUserLoggedIn();
    this.getUserName();
    this.getUserRole();
    //console.log(this.userRole);
  }

  logout() {
    localStorage.clear();
    this.userService.setLoggedInUser(false);
    alert('Your session expired')
    this.route.navigateByUrl('/login');
  }
  //isLogged: boolean = this.userService.IsLogged()
  // isLogged:boolean = this.userService.IsLogged()
}
