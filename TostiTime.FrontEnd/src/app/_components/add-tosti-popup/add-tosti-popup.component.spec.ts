import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTostiPopupComponent } from './add-tosti-popup.component';

describe('AddTostiPopupComponent', () => {
  let component: AddTostiPopupComponent;
  let fixture: ComponentFixture<AddTostiPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTostiPopupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddTostiPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
