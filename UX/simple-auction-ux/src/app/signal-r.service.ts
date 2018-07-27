import { BidsService } from './bids/bids.service';
import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { initChangeDetectorIfExisting } from '../../node_modules/@angular/core/src/render3/instructions';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  connection = null;
  constructor(private bidsService: BidsService) {
    this.init();
    this.setHandler();
  }

  init() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(environment.baseUrl + 'bidsHub')
      .configureLogging(signalR.LogLevel.Information)
      .build();
    this.connection
    .start()
    .then(() => console.log('Connection started!'))
    .catch(err => console.error(err.toString()));
  }

  setHandler() {
    this.connection.on('SignalRNotify', (eventName, eventParam) => {
      if (eventName === 'NewBidCreated') {
        this.bidsService.updateHighestBid(eventParam.bidModel);
        console.log(eventParam);
      }


    });
  }
}
