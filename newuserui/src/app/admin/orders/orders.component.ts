import { Component, OnInit } from '@angular/core';
import { Order } from '../Model/Order';
import { MatSort,Sort } from '@angular/material/sort';
import {AfterViewInit, ViewChild} from '@angular/core';
import {MatTable, MatTableDataSource} from '@angular/material/table';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { DialogbxComponent } from '../dialogbx/dialogbx.component';
import { AdminService } from '../Services/admin.service';


@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements AfterViewInit {

  orders: Order[]
  dataSource:MatTableDataSource<Order>

  GetOrders(){
    this.admin.GetOrders().subscribe(res=>{
      this.orders = res;
      this.dataSource = new MatTableDataSource(this.orders)
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      //console.log(this.orders);
    },(err)=>{
      //console.log(err);
    })
  }

  
  constructor(private _liveAnnouncer: LiveAnnouncer,public dialog: MatDialog, private admin:AdminService) {
    this.GetOrders();
   }

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatTable,{static:true}) table: MatTable<any>;
  displayedColumns: string[] = ['orderId','UserId','AddressId','TotalItems','TotalOrderValue','OrderStatus','OrderPlacedAt','action']
  
  //this.dataSource = this.orders;
  

  ngAfterViewInit(): void {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
  }

  announceSortChange(sortState: Sort){
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  openDialog(action,obj) {
    obj.action = action;
    const dialogRef = this.dialog.open(DialogbxComponent, {
      width: '250px',
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
     this.updateRowData(result.data);
  
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  updateRowData(row_obj){
    this.admin.EditOrderStatus(row_obj.orderId,JSON.stringify( row_obj.orderStatus)).subscribe(res=>{
      this.dataSource.data = this.dataSource.data.map((val:Order)=>{
        if(val.orderId == res.orderId){
          val.orderStatus = res.orderStatus
        }
        this.GetOrders();
        this.table.renderRows();
        return val;
      })
    })
    
  }

}
