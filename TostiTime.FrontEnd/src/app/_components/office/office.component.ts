import { Component, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Office } from '../../_models/office';
import { SignalrService } from '../../_services/signalr-service';
import { TostiTimeApiService } from '../../_services/tostitime-api-service';

@Component({
  selector: 'app-office',
  templateUrl: './office.component.html',
  styleUrls: ['./office.component.css']
})
@Injectable()
export class OfficeComponent implements OnInit {
  selectedOffice: string | undefined;
  offices: Office[] | undefined;
  office: Office | undefined;

  constructor(
    private apiService: TostiTimeApiService,
    private route: ActivatedRoute,
    private signalr: SignalrService,
  ) { }

  ngOnInit() {
    this.apiService.getOffices().subscribe((offices: Office[]) => {
      this.offices = offices;
    });

    this.apiService.office$.subscribe((office: Office) => {
      this.office = office;
      this.selectedOffice = office.city;
    });

    this.route.paramMap.subscribe(params => {
      this.selectedOffice = params.get('selectedOffice')!;      
    })

    this.apiService.navigateTo(this.selectedOffice!);
  }

  navigateToOffice(event: any) {
    this.apiService.navigateTo(event.target.value);
  }
}
