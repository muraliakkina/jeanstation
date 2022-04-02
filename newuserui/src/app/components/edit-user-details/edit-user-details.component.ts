import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Email } from 'src/app/Model/email';
import { User } from 'src/app/Model/user';
import { EmailService } from 'src/app/service/email.service';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-edit-user-details',
  templateUrl: './edit-user-details.component.html',
  styleUrls: ['./edit-user-details.component.css']
})
export class EditUserDetailsComponent implements OnInit {

  constructor(private formbuilder: FormBuilder, private emailservice: EmailService, private userservice: UserService) {
    this.user = new User();
    this.emailclass = new Email();
    this.userId = +localStorage.getItem("userId");
  }

  EditDetailsForm!: FormGroup;
  user: User;
  emailclass: Email;

  //get userid from local storage
  userId: number;
  ngOnInit(): void {
    
    this.buildform();
    this.getValues();

  }

  getValues() {
    
    this.userservice.GetUser(this.userId)
      .subscribe(res => {
        //console.log(res);
        this.user = res;
        // this.EditDetailsForm.value.name=this.user.UserName;
        this.EditDetailsForm.controls['name'].setValue(this.user.userName);
        this.EditDetailsForm.controls['email'].setValue(this.user.email);
        this.EditDetailsForm.controls['number'].setValue(this.user.mobileNo);
        //console.log(this.EditDetailsForm.controls['number']);
      },
        err => {
          alert("something went wrong");
        });
  }

  buildform() {
    this.EditDetailsForm = this.formbuilder.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.email, Validators.required]],
      number: ['', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]]
    });
  }

  submit() {
    if (this.EditDetailsForm.valid) {

      this.user.userName = this.EditDetailsForm.value.name;
      this.user.email = this.EditDetailsForm.value.email;
      this.user.mobileNo = this.EditDetailsForm.value.number;

      this.user.role = "user";
      this.emailclass.ToEmail = this.EditDetailsForm.value.email;
      this.emailclass.Body = "Hello" + this.user.userName + " ,your details have been updated";
      this.emailclass.Subject = "notification";

      this.userservice.EditUser(this.userId, this.user)
        .subscribe((response) => {
          //console.log(response);
          if (response != null) {
            
            this.emailservice.SendEmail(this.emailclass).subscribe(res => {

            })
            alert("Details Updated")
          }
          else{
            alert("Please try again")
          }

        })
    }
    else {
      alert('User form is not valid!!');
    }

  }
}
