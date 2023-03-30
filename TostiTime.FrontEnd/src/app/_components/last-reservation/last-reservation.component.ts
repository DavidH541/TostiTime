import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Person } from 'src/app/_models/person';
import { Reservation } from 'src/app/_models/reservation';
import { OccupationService } from 'src/app/_services/occupation-service';
import { TostiTimeApiService } from 'src/app/_services/tostitime-api-service';

@Component({
  selector: 'app-last-reservation',
  templateUrl: './last-reservation.component.html',
  styleUrls: ['./last-reservation.component.css']
})
export class LastReservationComponent implements OnInit {
  @Input() lastReservation: Reservation | undefined;
  reservator: Person | undefined;
  secondsSince: number = 0;
  minutesSince: number = 0;
  isOccupied: boolean = false;
  @Output() cookedState = new EventEmitter<number>();

  constructor(private apiService: TostiTimeApiService, private occupationService: OccupationService) { }

  async ngOnInit() {
    if (this.lastReservation) {
      this.isOccupied = this.occupationService.isOccupied(this.lastReservation);

      if (this.isOccupied) {
        this.cookedState.emit(this.minutesSince);

        const occupiedSinceString = this.lastReservation!.occupiedSince.toString();
        const occupiedSince = new Date(occupiedSinceString);

        setInterval(() => {
          const timeSince = this.occupationService.calculateTimeSinceOccupation(occupiedSince);
          this.minutesSince = timeSince[0];
          this.secondsSince = timeSince[1];
          this.cookedState.emit(this.minutesSince);
        }, 1000);

        this.apiService.getPerson(this.lastReservation?.personId)
          .subscribe((person: Person) => {
            this.reservator = person;
          });
      }
    }
  }
}