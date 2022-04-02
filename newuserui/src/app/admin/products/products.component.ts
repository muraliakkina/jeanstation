import { Component, ViewChild, AfterViewInit } from '@angular/core';
//import { ActivatedRoute, Router } from '@angular/router';
//import { Product } from '../Model/Product';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { ProductDialogBoxComponent } from './product-dialog-box/product-dialog-box.component';
import { AdminService } from '../Services/admin.service';
//import { DatePipe } from '@angular/common';
//import { CursorError } from '@angular/compiler/src/ml_parser/lexer';
import { Item } from 'src/app/Model/Item';
import { FileInfo } from '../Model/FileInfo';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements AfterViewInit {
  products: Item[];

  dataSource: MatTableDataSource<Item>

  

  GetProduct() {
    this.admin.GetItems().subscribe(res => {
      this.products = res;
      this.dataSource = new MatTableDataSource(res)
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      //console.log(this.products);
    }, (err) => {
      //console.log(err);
    })
  }

  displayedColumns: string[] = ['itemId', 'name',  'material', 'brandName', 'type', 'color', 'category', 'size', 'price', 'quantity', 'actions']
  //dataSource = new MatTableDataSource(this.products)

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatTable, { static: true }) table: MatTable<any>;

  constructor(private _liveAnnouncer: LiveAnnouncer, public dialog: MatDialog, private admin: AdminService, private http: HttpClient) {


    this.GetProduct();
  }

  ngAfterViewInit(): void {
  }




  announceSortChange(sortState: Sort) {
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

  openDialog(action, obj) {
    obj.action = action;
    const dialogRef = this.dialog.open(ProductDialogBoxComponent, {
      width: '250px',
      data: obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result.event == 'Add') {
        this.addRowData(result.data);
      } else if (result.event == 'Update') {
        this.updateRowData(result.data);
      } else if (result.event == 'Delete') {
        this.deleteRowData(result.data);
      }
    });
  }

  itemDetails(row_obj) {

  }

  addRowData(row_obj) {
    
    let current = new Date()
    row_obj.dateAdded = current;
    this.admin.AddItem(row_obj).subscribe(res => {
      this.GetProduct();
      this.table.renderRows();
      return res;
    }, (err) => {
      //console.log(err);
    })
    //this.table.renderRows();
  }

  updateRowData(row_obj) {
    this.admin.UpdateItem(row_obj.itemId, row_obj).subscribe(res => {
      this.dataSource.data = this.dataSource.data.map((val: Item) => {
        if (val.itemId == res.itemId) {
          val = res
        }
        this.GetProduct();
        return val
      }, (err) => {
        //console.log(err);
      })
    })

  }
  deleteRowData(row_obj) {
    this.admin.RemoveItem(row_obj.itemId).subscribe(res => {
      this.GetProduct();
      this.table.renderRows();
      return res;
    }, (err) => {
      //console.log(err);
    })
    
  }

}
