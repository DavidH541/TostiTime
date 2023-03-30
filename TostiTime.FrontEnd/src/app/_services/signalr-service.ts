import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import { environment } from 'src/environments/environment.development';
import { Office } from '../_models/office';
import { TostiTimeApiService } from './tostitime-api-service';

@Injectable()
export class SignalrService {

  private hubConnection: signalR.HubConnection;
  currentOffice: Office | undefined;

  constructor(private apiService: TostiTimeApiService) {

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.baseUrl}/RefreshOffice`)
      .build();

    this.hubConnection
      .start()
      .catch(err => alert(`Something went wrong with the connection, please try again later`));

    this.apiService.office$.subscribe((office: Office) => {
      if (this.currentOffice) {
        this.hubConnection?.off(this.currentOffice.city);
      }
      this.currentOffice = office;

      this.hubConnection?.on(this.currentOffice.city, () => {
        this.apiService.navigateTo(this.currentOffice!.city);
      });
    })
  }
}
