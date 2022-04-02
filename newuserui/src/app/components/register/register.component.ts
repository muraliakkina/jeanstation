import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Email } from 'src/app/Model/email';
import { User } from 'src/app/Model/user';
import { EmailService } from 'src/app/service/email.service';
import { UserService } from 'src/app/service/user.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  emailclass: Email;
  user: User;
  otp: number;
  emailObj: Email;
  OtpVerified: boolean = false;
  Otpform!: FormGroup;
  val: number;
  EmailVerified: boolean;
  constructor(private formbuilder: FormBuilder, private userservice: UserService, private emailservice: EmailService, private route: Router) {
    this.emailObj = new Email();
    this.user = new User();
    this.emailclass = new Email();
  }
  signupform!: FormGroup;
  ngOnInit(): void {
    this.signupform = this.formbuilder.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      number: ['', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]],
      password: ['', [Validators.required, Validators.minLength(8)]],

    });
    this.Otpform = this.formbuilder.group({
      one: ['', Validators.required],
      two: ['', Validators.required],
      three: ['', Validators.required],
      four: ['', Validators.required]
    });
  }

  SendOtp() {
    //here we have to check the email
    //if the response is true which means the email is already registered
    // this.userservice.checkemail(this.signupform.value.email)
    // .subscribe(res=>{
    // this.EmailVerified=res);
    // },
    // err=>{
    //   alert("error");
    // });

    this.userservice.CheckEmail(this.signupform.controls['email'].value).subscribe(res => {
      if (!res) {
        //opt is assigned
        this.val = Math.floor(1000 + Math.random() * 9000);
        // console.log(val);
        //otp is passed to mail
        this.emailObj.ToEmail = this.signupform.value.email;
        this.emailObj.Subject = "OTP to reset password";
        this.emailObj.Body = "this is your Otp to reset your password : " + this.val;
        this.emailservice.SendEmail(this.emailObj)
          .subscribe(res => {
            alert("An email has been sent to your registered email Id with a OTP to reset your password");
          },
            err => {
              alert("something went wrong");
            });
      }
      else{
        alert("Email Already Registered")
      }
    })


  }

  VerifyOtp() {
    this.otp = (1000 * +this.Otpform.value.one) + (100 * +this.Otpform.value.two) + (10 * +this.Otpform.value.three) + +this.Otpform.value.four;
    if (this.otp == this.val) {
      this.OtpVerified = true;
      alert("Email Verified")
    }
    else {
      alert('enter correct otp');
    }
  }

  signup() {
    if (this.signupform.valid && this.OtpVerified) {
      this.user.userName = this.signupform.value.name;
      this.user.email = this.emailObj.ToEmail;
      this.user.mobileNo = this.signupform.value.number;
      this.user.password = this.signupform.value.password;
      this.user.role = "User";
      this.emailclass.ToEmail = this.user.email;
      this.emailclass.Body = "Hello" + this.user.userName + " ,thanks for signing up with jeanstation";
      this.emailclass.Subject = "Welcome to our family JeanStation";
      this.userservice.AddNewUser(this.user)
        .subscribe((response) => {
          if (response) {
            
            alert("User registerd!! Please login to Shop ")
            this.route.navigate([''])

          }

          this.emailservice.SendEmail(this.emailclass).subscribe(res => {
            if (res !== null) {
              //alert("A mail has sent to you for sign up")
            } else {
              //alert("Signup mail Not sent");
            }
          })
        },
          err => {
            alert("try again");
          });
    }
    else {
      alert('User form is not valid or Verify Email again and try again ');
    }
  }


}
