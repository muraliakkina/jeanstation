import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Cart } from 'src/app/Model/cart';
import { Item } from 'src/app/Model/Item';
import { CartService } from 'src/app/service/cart.service';
import { ProductService } from 'src/app/service/product.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Address } from 'src/app/Model/userAddress';
import { UserService } from 'src/app/service/user.service';
import { OrderService } from 'src/app/service/order.service';
import { Order } from 'src/app/admin/Model/Order';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  withoutMaterialForm: FormGroup;
  submitted: boolean = false;


  cartItems: Cart[];
  items: Item[];
  cartQty: number;
  cartPrice: number;
  adresses: Address[];
  adresid: number;
  order: Order;

  userId: number = +localStorage.getItem('userId')


  constructor(private cartSer: CartService, private user: UserService, private orderser: OrderService, private route: Router, public dialog: MatDialog) {
    this.getCartItems();
    this.getUserAddress();
    //console.log(this.adresid);
  }

  getUserAddress() {
    this.user.GetUserAddressById(this.userId).subscribe(res => {
      //console.log(res);
      this.adresses = res;
    })
  }

  getCartItems() {
    this.cartSer.getCartItems().subscribe(res => {
      this.cartItems = res;
      //console.log(res);
      this.cartPrice = 0;
      this.cartQty = 0
      this.cartItems.forEach(x => {
        this.cartPrice += (x.itemPrice * x.itemQuantity)
        this.cartQty += x.itemQuantity
      })
    })
  }



  


  removeItem(itemId: number) {
    this.cartSer.removeItem(itemId).subscribe(res => {
      //console.log(res);
      this.getCartItems()
    })

  }

  ngOnInit(): void {
    
  }


  

  increaseItem(itemId: number) {
    this.cartSer.increaseItem(itemId).subscribe(res => {
      //console.log(res);
      this.getCartItems();
      //console.log(this.adresid);
    })

  }

  decreaseItems(itemId: number) {
    this.cartSer.decreaseItem(itemId).subscribe(res => {
      //console.log(res);
      this.getCartItems();
      //console.log(this.adresid);
    })
    

  }

  clearCart() {
    this.cartSer.clearCart().subscribe(res => {
      //console.log(res);
      this.getCartItems()
    })
  }

  placeOrder() {
    //console.log(this.adresid);
    if (this.adresid >0) {
      this.orderser.PlaceOrder(this.userId, this.adresid).subscribe(res => {
        if (res) {
          console.log(res);
          this.order = res;
          
          alert("Order Placed Sucessfully")
          this.route.navigate(['/user/orders/', this.order.orderId])
          //this.route.navigateByUrl(`/user/orders/${this.order.orderId}`)
        }
      })
    }
    else if (this.adresses.length == 0) {
      alert("Please add Address to place the Order")
    }
    else {
      alert("Please Choose the Address to Place the Order")
    }

  }


}
