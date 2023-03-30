import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LastReservationComponent } from './last-reservation.component';

describe('LastReservationComponent', () => {
  let component: LastReservationComponent;
  let fixture: ComponentFixture<LastReservationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LastReservationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LastReservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
