import { LiveAnnouncer } from '@angular/cdk/a11y';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { Order } from 'src/app/admin/Model/Order';
import { AdminService } from 'src/app/admin/Services/admin.service';
import { OrderService } from 'src/app/service/order.service';

@Component({
  selector: 'app-orderslist',
  templateUrl: './orderslist.component.html',
  styleUrls: ['./orderslist.component.css']
})
export class OrderslistComponent implements OnInit {

  orders: Order[]
  dataSource:MatTableDataSource<Order>
  userId = +localStorage.getItem('userId')
  

  GetOrders(){
    
    this.order.GetOrderByUserId(this.userId).subscribe(res=>{
      this.orders = res;
      this.dataSource = new MatTableDataSource(this.orders)
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      //console.log(this.orders[0].orderCreatedAt);
      // console.log(Buffer.from(`${this.orders[0].orderCreatedAt}`, 'base64').toString('binary'))
      //console.log(this.orders);
    },(err)=>{
      //console.log(err);
    })
  }

  constructor(private _liveAnnouncer: LiveAnnouncer,public dialog: MatDialog, private order:OrderService) {
    
    this.GetOrders()
   }

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatTable,{static:true}) table: MatTable<any>;
  displayedColumns: string[] = ['orderId','TotalItems','TotalOrderValue','OrderStatus','OrderPlacedAt','action']

  ngOnInit(): void {
  }

  announceSortChange(sortState: Sort){
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

}
