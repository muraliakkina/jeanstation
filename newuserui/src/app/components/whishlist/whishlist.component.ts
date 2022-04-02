import { Component, OnInit } from '@angular/core';
import { Wishlist } from 'src/app/Model/wishlist';
import { UserService } from 'src/app/service/user.service';
import { WishlistService } from 'src/app/service/wishlist.service';

@Component({
  selector: 'app-whishlist',
  templateUrl: './whishlist.component.html',
  styleUrls: ['./whishlist.component.css'],
  
})
export class WhishlistComponent implements OnInit {

  wishlist:Wishlist
  wishlistItems:Wishlist[];
  userId:number;
  constructor(private wishlistService:WishlistService,private userService:UserService) {
     this.wishlist = new Wishlist();
     this.getWhishlistItems();
     //console.log(this.userService.getUserId());
   }

   
  

  // getWhishlistItems(){
  //   this.wishlistService.getWishlistItems().subscribe(res=>{
  //     this.wishlistItems = res;
  //     console.log(res);  
  //   })
  // }
  getWhishlistItems(){
    this.wishlistService.getWishlistItems(this.userService.getUserId()).subscribe(res=>{
      //console.log(res);
      this.wishlistItems = res;
      //console.log(this.wishlistItems);
    })
      
  
  }

  ngOnInit(): void {
    
  }

  removeFromWishlist(itemId:number){
    this.wishlistService.removeFromWishlist(itemId,this.userService.getUserId()).subscribe(res =>{
      //console.log(res);
      // if(res == null){
        
      // }else if(res !=null){
      //   this.wishlistItems = this.wishlistItems.filter(ele=> ele.itemId != res.itemId)
      // }
      //console.log(this.wishlistItems);
      this.getWhishlistItems();
    })
    
    
  }

}
