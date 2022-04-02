import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from 'src/app/Model/Item';
import { CartService } from 'src/app/service/cart.service';
import { ProductService } from 'src/app/service/product.service';
import { UserService } from 'src/app/service/user.service';
import { WishlistService } from 'src/app/service/wishlist.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(private itemService:ProductService, private cartService:CartService, private route:Router,private wishService:WishlistService,private userSer:UserService) {
    this.userName = localStorage.getItem('uname')
   }

  items: Item[];
  category:string[] = ['Men', 'Women']
  filterCategory:string;
  userName:string;

  brand:string[] = ['Wrongun','Rodstar','Louis Phil','Flying Mac','Calvein Klien','Under Power']
  filterBrandName:string;

  fit = ['Regular Fit','Slim Fit','Skinny Fit', 'Bootcut']
  filterByFit:string;

  size = ['28','30','32','34','36']
  filterBySize:string;

  color = ['Black','Blue','Green','Grey','White']
  filterByColor:string;

 //@Output() addingCart = new EventEmitter();

 

 getProducts(){
   this.itemService.getProducts().subscribe(res=>{
     this.items = res
     //console.log(res);
   })
 }

 

  ngOnInit(): void {
    this.getProducts();
    
  }

  resetFilter(){
    this.filterBrandName = "";
    this.filterByFit = "";
    this.filterBySize = "";
    this.filterCategory = "";
    this.filterByColor = "";
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
