import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderslistComponent } from './orderslist.component';

describe('OrderslistComponent', () => {
  let component: OrderslistComponent;
  let fixture: ComponentFixture<OrderslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderslistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
