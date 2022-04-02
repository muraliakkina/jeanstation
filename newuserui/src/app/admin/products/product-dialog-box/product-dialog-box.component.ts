import { Component, Optional, Inject } from '@angular/core';
import { Item } from 'src/app/Model/Item';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product-dialog-box',
  templateUrl: './product-dialog-box.component.html',
  styleUrls: ['./product-dialog-box.component.css']
})
export class ProductDialogBoxComponent  {
  action:string;
  local_data:any;
  file: any;
  fileData: any;
  url = environment.url_js

  constructor(
    public dialogRef: MatDialogRef<ProductDialogBoxComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any,private http:HttpClient) {
    //console.log(data);
    this.local_data = {...data};
    this.action = this.local_data.action;
  }

  doAction(){
    this.dialogRef.close({event:this.action,data:this.local_data});
  }

  selectFile1(event) {
    this.file = event.target.files[0];
    //console.log(event.target.files[0].name);
    let formData = new FormData();
      formData.append('file', this.file, this.file.name);
      //console.log(formData.get('file'));
      //console.log(formData.getAll('file'));
      this.http.post<any>(this.url +'Files/upload', formData, { headers: { 'Anonymous': '',skip:"true" } }).subscribe(
        res => {
          // alert("Uploaded!");
          //console.log(res);
          this.fileData = res;
          
          this.local_data.itemImage1 = this.fileData.fileName;
          //console.log("imgurl:" + this.local_data.itemImage1);

        })
  }

  selectFile2(event) {
    this.file = event.target.files[0];
    //console.log(event.target.files[0].name);
    let formData = new FormData();
      formData.append('file', this.file, this.file.name);
      //console.log(formData.get('file'));
      //console.log(formData.getAll('file'));
      this.http.post<any>(this.url +'Files/upload', formData, { headers: { 'Anonymous': '',skip:"true" } }).subscribe(
        res => {
          // alert("Uploaded!");
         // console.log(res);
          this.fileData = res;
          
          this.local_data.itemImage2 = this.fileData.fileName;
         // console.log("imgurl:" + this.local_data.itemImage2);

        })
  }


  selectFile3(event) {
    this.file = event.target.files[0];
    //console.log(event.target.files[0].name);
    let formData = new FormData();
      formData.append('file', this.file, this.file.name);
      //console.log(formData.get('file'));
      //console.log(formData.getAll('file'));
      this.http.post<any>(this.url +'Files/upload', formData, { headers: { 'Anonymous': '',skip:"true" } }).subscribe(
        res => {
          // alert("Uploaded!");
          //console.log(res);
          this.fileData = res;
          
          this.local_data.itemImage3 = this.fileData.fileName;
          //console.log("imgurl:" + this.local_data.itemImage3);

        })
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }

}

