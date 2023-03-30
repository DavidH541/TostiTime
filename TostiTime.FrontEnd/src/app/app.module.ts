import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OfficeComponent } from './_components/office/office.component';
import { IronComponent } from './_components/iron/iron.component';
import { SlotComponent } from './_components/slot/slot.component';
import { HttpClientModule } from '@angular/common/http';
import { TostiTimeApiService } from './_services/tostitime-api-service';
import { LastReservationComponent } from './_components/last-reservation/last-reservation.component';
import { SignalrService } from './_services/signalr-service';
import { AddTostiPopupComponent } from './_components/add-tosti-popup/add-tosti-popup.component';
import { OrderModule } from 'ngx-order-pipe';
import { OccupationService } from './_services/occupation-service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    OfficeComponent,
    IronComponent,
    SlotComponent,
    LastReservationComponent,
    AddTostiPopupComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule,
    OrderModule,
    FormsModule,
  ],
  providers: [TostiTimeApiService, SignalrService, OccupationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
