import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductStatus, BidModel } from '../models';
import { LoginService } from '../../login/login.service';
import * as moment from 'moment';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @Input() productId: string;
  @Input() productName: string;
  @Input() closeTime: string;
  @Input() startTime: string;
  @Input() status: ProductStatus;
  @Input() highestBid: BidModel;

  @Output() doBid = new EventEmitter();

  newPrice: number;

  constructor(private loginService: LoginService) { }

  ngOnInit() {
  }

  getStatus(): string {
    const closeMoment = moment(this.closeTime);
    const startMoment = moment(this.startTime);

    if (moment().isBefore(closeMoment) && moment().isAfter(startMoment)) {
      return 'IN BID';
    }
    
    if (moment().isAfter(closeMoment)) {
      return 'END';
    }

    

    switch (this.status) {
      case ProductStatus.End:
        return 'END';
      case ProductStatus.InBid:
        return 'IN BID';
      case ProductStatus.NotStart:
        return 'NOT STARTED';
      default:
        return '';
    }

  }

  getPrice() {
    if (this.highestBid) {
      return this.highestBid.amount;
    }
    return 0;
  }

  isLoggedIn() {
    return this.loginService.isLoggedIn();
  }

  bid() {
    this.doBid.emit(<BidModel>{
      productId: this.productId,
      amount: this.newPrice
    });
  }

  canBid(): boolean {
    return this.loginService.isLoggedIn() &&
      ((this.status === ProductStatus.InBid) ||
        (moment().isBefore(moment(this.closeTime)) && moment().isAfter(moment(this.startTime))));
  }


}
