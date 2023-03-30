import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Person } from 'src/app/_models/person';
import { TostiTimeApiService } from 'src/app/_services/tostitime-api-service';

@Component({
  selector: 'app-add-tosti-popup',
  templateUrl: './add-tosti-popup.component.html',
  styleUrls: ['./add-tosti-popup.component.css']
})

export class AddTostiPopupComponent implements OnInit {
  @Input() officeId: number | undefined;
  @Input() officeName: string | undefined;
  @Input() slotId: number | undefined;
  persons: Person[] | undefined;
  filteredPersons: Person[] | undefined;
  reservator: Person | undefined;

  constructor(
    public apiService: TostiTimeApiService,
    public activeModal: NgbActiveModal
    ) { }

  ngOnInit(): void {   
    this.apiService.getOfficePersons(this.officeName).subscribe((office) => {
      this.officeName = office.city;
      this.persons = office.persons;
      this.filteredPersons = office.persons;
    });
  }

  filterPersons(filterString: string | undefined) {
    if (!filterString) {
      this.filteredPersons = this.persons;
    }

    filterString = filterString!.toLowerCase();
    this.filteredPersons = this.persons!.filter((person: Person) => (person.firstName.toLowerCase().indexOf(filterString!) > -1));
  }

  reserveSlot(firstName: string) {
    this.apiService.reserveSlot(this.officeId, this.slotId, firstName).subscribe(() => {
      this.activeModal.close();
    });
  }
}