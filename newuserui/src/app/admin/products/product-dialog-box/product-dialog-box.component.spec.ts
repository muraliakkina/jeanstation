import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDialogBoxComponent } from './product-dialog-box.component';

describe('ProductDialogBoxComponent', () => {
  let component: ProductDialogBoxComponent;
  let fixture: ComponentFixture<ProductDialogBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductDialogBoxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductDialogBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
