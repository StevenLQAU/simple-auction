import { Component, OnInit } from '@angular/core';
import { ProductBidModel } from '../models';
import { BidsService } from '../bids.service';

@Component({
  selector: 'app-bids-main',
  templateUrl: './bids-main.component.html',
  styleUrls: ['./bids-main.component.css']
})
export class BidsMainComponent implements OnInit {

  constructor(private bidsService: BidsService) { }

  ngOnInit() {
    this.getProductsWithBids();
  }

  public get products() {
    return this.bidsService.products;
  }

  getProductsWithBids() {
    this.bidsService.getProductsWithCurrentBid()
      .subscribe((result: ProductBidModel[]) => {
        this.bidsService.products = result;
      });
  }
  doBid($event) {
    this.bidsService.createBid($event).subscribe(() => {
      this.getProductsWithBids();
    });
  }
}
