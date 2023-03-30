import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Office } from '../_models/office';
import { environment } from 'src/environments/environment.development';
import { Observable, Subject } from 'rxjs';
import { Person } from '../_models/person';
import { Router } from '@angular/router';

@Injectable()
export class TostiTimeApiService {
  private officeSource = new Subject<Office>();
  office$ = this.officeSource.asObservable();

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  navigateTo(officeName: string) {
    this.getOffice(officeName).subscribe((office: Office) => {
      this.officeSource.next(office);
      this.router.navigate(['office', officeName]);
    });
  }

  getOffice(officeName: string): Observable<Office> {
    console.log(`Sending GET request with office name: ${officeName}`);
    return this.http.get<Office>(`${environment.baseUrl}/offices/${officeName}/irons`);
  }
  
  getOfficePersons(officeName: string | undefined): Observable<Office> {
    console.log(`Sending GET request for all persons within office: ${officeName}`);
    return this.http.get<Office>(`${environment.baseUrl}/offices/${officeName}/persons`);
  }
  
  getOffices(): Observable<Office[]> {
    console.log(`Sending GET request to get all offices`);
    return this.http.get<Office[]>(`${environment.baseUrl}/offices`);
  }

  reserveSlot(officeId: number | undefined, slotId: number | undefined, firstName: string | undefined) {
    console.log(`Sending POST request with office id: ${officeId}, slot id: ${slotId} and first name: ${firstName}`);
    return this.http.post(`${environment.baseUrl}/offices/${officeId}/createReservation/${slotId}?firstName=${firstName}`, null);
  }

  completeReservation(officeId: number | undefined, slotId: number | undefined) {
    console.log(`Sending PUT request with slot id ${slotId}`);
    return this.http.put(`${environment.baseUrl}/offices/${officeId}/completeReservation/${slotId}`, null);
  }

  getPerson(personId: number | undefined): Observable<Person> {
    console.log(`Sending GET request with person id: ${personId}`);
    return this.http.get<Person>(`${environment.baseUrl}/persons/${personId}`);
  }
}