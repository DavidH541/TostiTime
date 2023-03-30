import { Component, Input, OnInit } from '@angular/core';
import { OccupationService } from 'src/app/_services/occupation-service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Slot } from '../../_models/slot';
import { TostiTimeApiService } from '../../_services/tostitime-api-service';
import { AddTostiPopupComponent } from '../add-tosti-popup/add-tosti-popup.component';
import { environment } from 'src/environments/environment.development';
import { ActivatedRoute } from '@angular/router';

const cookedStateMap = new Map([
  [9, "nine"],
  [8, "eight"],
  [7, "seven"],
  [6, "six"],
  [5, "five"],
  [4, "four"],
  [3, "three"],
  [2, "two"],
  [1, "one"],
  [0, "zero"],
]);

@Component({
  selector: 'app-slot',
  templateUrl: './slot.component.html',
  styleUrls: ['./slot.component.css']
})
export class SlotComponent implements OnInit {
  @Input() slot: Slot | undefined;
  @Input() officeId: number | undefined;
  currentDate: Date = new Date();
  tostiCookedState: string | undefined;
  isOccupied: boolean = false;
  firstName: string = environment.firstName;
  officeName: string | undefined;

  constructor(
    private apiService: TostiTimeApiService, 
    private occupationService: OccupationService, 
    private modalService: NgbModal,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    if (this.slot) {
      this.isOccupied = this.occupationService.isOccupied(this.slot.lastReservation);
    }

    this.route.paramMap.subscribe(params => {
      this.officeName = params.get('selectedOffice')!;      
    })
  }

  setTostiCookedState(cookedState: number) {
    this.tostiCookedState = cookedStateMap.get(cookedState) || "burned";
  }

  reserveSlot(): void {
    this.apiService.reserveSlot(this.officeId, this.slot?.id, this.firstName)
      .subscribe();
  }

  completeReservation(): void {
    if (confirm(`Are you sure you want to delete this reservation? \n ${this.firstName}`)) {
      this.apiService.completeReservation(this.officeId, this.slot?.id).subscribe();
    }
  }

  openAddTostiComponent() {
    const modalRef = this.modalService.open(AddTostiPopupComponent);
    modalRef.componentInstance.officeId = this.officeId;
    modalRef.componentInstance.officeName = this.officeName;
    modalRef.componentInstance.slotId = this.slot!.id;
  }
}
