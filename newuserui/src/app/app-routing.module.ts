import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { OrdersComponent } from './admin/orders/orders.component';
import { ProductsComponent } from './admin/products/products.component';
import { AdmingaurdGuard } from './admingaurd.guard';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { AddressDashboardComponent } from './components/address-dashboard/address-dashboard.component';
import { CartComponent } from './components/cart/cart.component';
import { EditUserDetailsComponent } from './components/edit-user-details/edit-user-details.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { OrderslistComponent } from './components/orderslist/orderslist.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { ProductComponent } from './components/product/product.component';
import { RegisterComponent } from './components/register/register.component';
import { UserordersComponent } from './components/userorders/userorders.component';
import { WhishlistComponent } from './components/whishlist/whishlist.component';
import { AuthGaurdGuard } from './service/auth-gaurd.guard';


const routes: Routes = [
 
  {path:'home',component:HomeComponent},
  {path:'product',component:ProductComponent},
  {path:'details/:id',component:ProductDetailsComponent,canActivate:[AuthGaurdGuard]},
  {path:'cart',component:CartComponent,canActivate:[AuthGaurdGuard]},
  {path:'wishlist',component:WhishlistComponent,canActivate:[AuthGaurdGuard]},
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'dashboard',component:DashboardComponent,canActivate:[AdmingaurdGuard]},
  {path:'products', component:ProductsComponent,canActivate:[AdmingaurdGuard]},
  {path:'orders',component:OrdersComponent,canActivate:[AdmingaurdGuard]},
  {path:'',redirectTo:'home',pathMatch:'full'},
  {path:'address',component:AddressDashboardComponent,canActivate:[AuthGaurdGuard]},
  {path:'user/orders/:id',component:UserordersComponent,canActivate:[AuthGaurdGuard]},
  {path:'user/edit-details',component:EditUserDetailsComponent,canActivate:[AuthGaurdGuard]},
  {path:'Aboutus',component:AboutUsComponent},
  {path:'user/orders',component:OrderslistComponent,canActivate:[AuthGaurdGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
