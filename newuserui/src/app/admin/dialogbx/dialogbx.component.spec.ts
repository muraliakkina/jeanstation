import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogbxComponent } from './dialogbx.component';

describe('DialogbxComponent', () => {
  let component: DialogbxComponent;
  let fixture: ComponentFixture<DialogbxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogbxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogbxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
