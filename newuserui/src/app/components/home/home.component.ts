import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from 'src/app/Model/Item';
import { CartService } from 'src/app/service/cart.service';
import { ProductService } from 'src/app/service/product.service';
import { UserService } from 'src/app/service/user.service';
import { WishlistService } from 'src/app/service/wishlist.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  items: Item[];
  constructor(private itemService:ProductService, private cartService:CartService, private route:Router,private wishService:WishlistService,private userSer:UserService) {
    this.userName = localStorage.getItem('uname')
   }

  userName:string;

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(){
    this.itemService.getProducts().subscribe(res=>{
      this.items = res
      this.items =this.items.slice(0,4)
      //console.log(res);
    })
  }

  addToCart(itemId:number){
    if(this.userName != null || this.userName != '', this.userName != undefined){
      this.cartService.addToCart(itemId,1).subscribe(res=>{
        //console.log(res);
        if(res != null){
          alert("Item Added to the Cart")
        }
        else {
          alert("Item Already in the Cart")
        }
      },)
    }
    else{
      alert("Login to your Account")
      this.route.navigate(['login'])
    }
   
    
  }

  addToWishlist(itemId:number){
    if(this.userName != null || this.userName != '', this.userName != undefined){
      this.wishService.addToWishList(itemId,this.userSer.getUserId()).subscribe(res=>{
        //console.log(res);
        if(res != null){
          alert("Item Added to wishlist")
        }else if( res == null){
          alert("Item Already added to wishlist")
        }
      })
    }
    else{
      alert("Login to your Account");
      this.route.navigate(['login'])
    }
    
  }

}
