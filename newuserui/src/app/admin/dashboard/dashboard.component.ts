import { Component } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { ChartData, ChartOptions } from 'chart.js';
import { AdminService } from '../Services/admin.service';
import { Order } from '../Model/Order';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  /** Based on the screen size, switch from standard to one column per row */
  cardLayout = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(({ matches }) => {
      if (matches) {
        return {
          columns: 1,
          miniCard: { cols: 1, rows: 1 },
          chart: { cols: 1, rows: 2 },
          table: { cols: 1, rows: 4 },
        };
      }

      return {
        columns: 4,
        miniCard: { cols: 1, rows: 1 },
        chart: { cols: 2, rows: 2 },
        table: { cols: 4, rows: 4 },
      };
    })
  );

  salesData: ChartData<'line'> = {
    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May'],
    datasets: [
      { label: 'Mobiles', data: [1000, 1200, 1050, 2000, 500], tension: 0.5 },
      { label: 'Laptop', data: [200, 100, 400, 50, 90], tension: 0.5 },
      { label: 'AC', data: [500, 400, 350, 450, 650], tension: 0.5 },
      { label: 'Headset', data: [1200, 1500, 1020, 1600, 900], tension: 0.5 },
    ],
  };
  chartOptions: ChartOptions = {
    responsive: true,
    plugins: {
      title: {
        display: true,
        text: 'Monthly Sales Data',
      },
    },
  };


  orders: Order[];
  
  cardsContent = { 'Orders Placed': 0,'Orders Deliverd': 0, 'Products Sold': 0, 'Revenue Generated': 0 }
  constructor(private breakpointObserver: BreakpointObserver, private admin: AdminService) {
    this.ordersStatistics()
  }

  ordersStatistics() {
    this.admin.GetOrders().subscribe(res => {
      if (res) {
        this.orders = res;
        this.orders.forEach(e => {
            if (e.orderStatus == 'Deliverd') {
  
              this.cardsContent['Orders Deliverd'] += 1
            }
            if (e.orderStatus == "Placed") {
              this.cardsContent['Orders Placed'] += 1
            };
            this.cardsContent['Products Sold'] += e.totalProducts
            this.cardsContent['Revenue Generated'] += e.totalPrice
        })
      }
    })
  }
}
