import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item } from 'src/app/Model/Item';
import { CartService } from 'src/app/service/cart.service';
import { ProductService } from 'src/app/service/product.service';
import { UserService } from 'src/app/service/user.service';
import { WishlistService } from 'src/app/service/wishlist.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  id:number;
  sub;
  item:Item;
  qty:number;
  constructor(private route:ActivatedRoute, private itemService:ProductService, private cartService:CartService,private wishService:WishlistService,private userSer:UserService) { }

  getProductById(){
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.itemService.getProductById(this.id).subscribe(res=>{
      this.item = res;
      //console.log(res);
      
    })
  }
  ngOnInit(): void {
    this.getProductById();
  }

  // ngOnDestroy(): void {
  //     this.sub.unsubscribe()
  // }

  addToCart(itemId:number,qty:number){
    this.cartService.addToCart(itemId,qty).subscribe(res=>{
      //console.log(res);
      if(res != null){
        
          alert("Item Added to the Cart")
        
      }
      else {
        alert("Item Already in the Cart")
      }
    },)
    
  }

  addToWishlist(itemId:number){
    this.wishService.addToWishList(itemId,this.userSer.getUserId()).subscribe(res=>{
      //console.log(res);
      if(res != null){
        alert("Item Added to wishlist")
      }else if( res == null){
        alert("Item Already added to wishlist")
      }
    })
  }

}
