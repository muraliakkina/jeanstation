
//import { Variable } from '@angular/compiler/src/render3/r3_ast';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/Model/user';
import { EmailService } from 'src/app/service/email.service';
import { UserService } from 'src/app/service/user.service';
import { AuthUser } from '../../Model/authUser';
import { Email } from '../../Model/email';
import { Login } from '../../Model/login';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  modelform!: FormGroup;
  loginform!: FormGroup;
  Otpform!: FormGroup;
  Passwordform!: FormGroup;
  otp: number;
  emailObj: Email;
  loginObj: Login;
  errMsg: string;
  authuser: AuthUser;
  user:User
  val: number;
  modalCheck:string = "modal";
  constructor(private formbuilder: FormBuilder, private emailservice: EmailService, private userservice: UserService, private route: Router, private cd: ChangeDetectorRef) {
    this.emailObj = new Email();
    this.loginObj = new Login();
    this.authuser = new AuthUser();
    this.user = new User();
  }

  ngOnInit(): void {
    this.loginform = this.formbuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
    this.modelform = this.formbuilder.group({
      email: ['', [Validators.required]]
    });
    this.Otpform = this.formbuilder.group({
      one: [''],
      two: [''],
      three: [''],
      four: ['']
    })
    this.Passwordform = this.formbuilder.group({
      password: [''],
      confirmpassword: ['']
    });
    this.EmailVerified = false;
    this.OtpVerified = false;
  }
  EmailVerified: boolean = false;
  OtpVerified: boolean = false;

  login() {
    // this.emailObj.ToEmail = this.loginform.value.email;
    // this.emailObj.Subject = "Login notification";
    // this.emailObj.Body = "Wellcome to JeanStation ";
    this.loginObj.email = this.loginform.value.email;
    this.loginObj.password = this.loginform.value.password;
    this.userservice.Validate(this.loginObj).subscribe(response => {
      if (response != null) {
        this.authuser = response;
        //console.log(this.authuser);
        let role = this.authuser.role;
        localStorage.setItem('userId', this.authuser.userId)
        localStorage.setItem("uname", this.authuser.name);
        localStorage.setItem("token", this.authuser.token);
        localStorage.setItem("role", this.authuser.role);
        //console.log(localStorage["token"])
        //this.cd.markForCheck()
        alert("Login successful!");

        this.userservice.setLoggedInUser(true);
        this.userservice.setUserName(this.authuser.name);
        //alert("Login successful!");

        if (role == 'User') {
          this.route.navigate([''])
        }
        else if (role == 'Admin') {
          this.route.navigate(['dashboard'])
        }
        
      }
      else {
        this.errMsg = "Invalid credentials";
      }
    })


  }

  modal() {
    this.modelform.reset();
    this.Otpform.reset();
    this.Passwordform.reset();
  }

  //for forgot password
  submitEmail() {
    if(this.modelform.valid){
      this.userservice.CheckEmail(this.modelform.controls['email'].value).subscribe(res => {
        if (res) {
          //email id verification needs to be done
          //supposedly email is right
          this.loginObj.email = this.modelform.value.email;
          this.EmailVerified = true;
          //opt is assigned
          this.val = Math.floor(1000 + Math.random() * 9000);
          // console.log(val);
          //otp is passed to mail
          this.emailObj.ToEmail = this.modelform.value.email;
          this.emailObj.Subject = "OTP to reset password";
          this.emailObj.Body = "this is your Otp to reset your password : " + this.val;
          this.emailservice.SendEmail(this.emailObj)
            .subscribe(res => {
              alert("An email has been sent to your registered email Id with a OTP to reset your password");
            },
              err => {
                alert("something went wrong");
              });
          // mail is sent
          // verifying otp
        }
        else{
          alert('Email is not Registered')
        }
      })
    }
    else{
      alert("Please enter your emailid")
    }
    

  }
  verify() {
    this.otp = (1000 * +this.Otpform.value.one) + (100 * +this.Otpform.value.two) + (10 * +this.Otpform.value.three) + +this.Otpform.value.four;
    if (this.otp == this.val) {
      this.OtpVerified = true;
      alert("OTP Verified")
    }
    else {
      alert('enter correct otp');
    }
  }
  Reset() {

    if (this.Passwordform.value.password == this.Passwordform.value.confirmpassword && this.OtpVerified) {
      this.user.email = this.modelform.value.email;
      this.user.password = this.Passwordform.value.password;
      this.userservice.UserPasswordReset(this.user.email,JSON.stringify(this.user.password))
        .subscribe(res => {
          //this.modalClose(res)
          alert("password reset");
          
        },
          err => {
            alert("something went wrong");
          });
    }
    else {
      alert('do not match');
    }

  }

  modalClose(res:any){
    if(res){
      return this.modalCheck
    }
    else{
      this.modalCheck = null;
      return this.modalCheck;
    }
     
  }
}

