import { Component, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Order } from '../Model/Order';



@Component({
  selector: 'app-dialogbx',
  templateUrl: './dialogbx.component.html',
  styleUrls: ['./dialogbx.component.css']
})
export class DialogbxComponent {
  action: string;
  local_data: any;

  constructor(
    public dialogRef: MatDialogRef<DialogbxComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: Order) {
    //console.log(data);
    this.local_data = { ...data };
    this.action = this.local_data.action;
  }
  doAction() {
    this.dialogRef.close({ event: this.action, data: this.local_data });
  }

  closeDialog() {
    this.dialogRef.close({ event: 'Cancel' });
  }


}
