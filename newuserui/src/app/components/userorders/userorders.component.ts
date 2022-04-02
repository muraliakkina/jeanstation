import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order } from 'src/app/admin/Model/Order';
import { Item } from 'src/app/Model/Item';
import { OrderService } from 'src/app/service/order.service';

@Component({
  selector: 'app-userorders',
  templateUrl: './userorders.component.html',
  styleUrls: ['./userorders.component.css']
})
export class UserordersComponent implements OnInit {

  constructor(private route:ActivatedRoute,private orderser:OrderService) {
    this.getOrderById();
   }

  id:number;
  order:Order;
  items:Item[];

  ngOnInit(): void {
  }

  getOrderById(){
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.orderser.GetOrderbyId(this.id).subscribe(res=>{
      //console.log(res);
      if(res){
        
        this.order = res;
        //console.log(typeof(this.order.orderCreatedAt));
      }
    })
    this.orderser.GetItemsInOrder(this.id).subscribe(res=>{
      //console.log(res);
      if(res){
        this.items = res;
      }
    })
  }

}
