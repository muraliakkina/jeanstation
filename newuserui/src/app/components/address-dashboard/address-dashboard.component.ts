import { LiveAnnouncer } from '@angular/cdk/a11y';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { Address } from 'src/app/Model/userAddress';
import { UserService } from 'src/app/service/user.service';
import { AddressDialogComponent } from './address-dialog/address-dialog.component';

@Component({
  selector: 'app-address-dashboard',
  templateUrl: './address-dashboard.component.html',
  styleUrls: ['./address-dashboard.component.css']
})
export class AddressDashboardComponent implements OnInit {

  addresses: Address[];
  userId:number;


  dataSource: MatTableDataSource<Address>

  

  GetProduct() {
    this.admin.GetUserAddressById(this.userId).subscribe(res => {
      this.addresses = res;
      this.dataSource = new MatTableDataSource(res)
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      //console.log(this.addresses);
    })
  }

  displayedColumns: string[] = ['addressId', 'DoorNo', 'StreetName', 'Locality', 'City', 'District', 'State', 'Pincode', 'actions']
  //dataSource = new MatTableDataSource(this.products)

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatTable, { static: true }) table: MatTable<any>;

  constructor(private _liveAnnouncer: LiveAnnouncer, public dialog: MatDialog, private admin: UserService, private http: HttpClient) {
    this.userId = +localStorage.getItem('userId')
    this.GetProduct();
  }

  ngAfterViewInit(): void {
  }

  ngOnInit(): void {
      
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
    const dialogRef = this.dialog.open(AddressDialogComponent, {
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



  addRowData(row_obj) {
     row_obj.userId = this.userId
    this.admin.AddNewUserAddress(row_obj).subscribe(res => {
      this.GetProduct();
      this.table.renderRows();
      return res;
    }, (err) => {
      //console.log(err);
    })
    //this.table.renderRows();
  }

  updateRowData(row_obj) {
    this.admin.EditUserAddressById(row_obj.addressId, row_obj).subscribe(res => {
      this.dataSource.data = this.dataSource.data.map((val: Address) => {
        if (val.addressId == res.addressId) {
          val = res
        }
        this.GetProduct();
        return val
      }, (err) => {
       // console.log(err);
      })
    })

  }
  
  deleteRowData(row_obj) {
    this.admin.DeleteUserAddress(row_obj.addressId).subscribe(res => {
      this.GetProduct();
      this.table.renderRows();
      return res;
    }, (err) => {
      //console.log(err);
    })
    this.GetProduct();
  }
}



