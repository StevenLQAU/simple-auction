import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { BidModel, ProductBidModel } from './models';
import { HttpClient } from '@angular/common/http';
import { ValueTransformer } from '../../../node_modules/@angular/compiler/src/util';
import * as moment from 'moment';
@Injectable({
  providedIn: 'root'
})
export class BidsService {

  public products: ProductBidModel[] = [];
  constructor(private httpClient: HttpClient) { }

  public getProductsWithCurrentBid(): Observable<Object> {
    const url = environment.apiUrl + 'Bids/Products';
    return this.httpClient.get(url);
  }

  public createBid(model: BidModel): Observable<Object> {
    const url = environment.apiUrl + 'Bids';
    return this.httpClient.post(url, model);
  }

  public updateHighestBid(model: BidModel) {
    const index = this.products.findIndex(value => value.product.id === model.productId);
    if (index === -1) {
      return;
    }
    const currentProductBid = this.products[index];
    if (moment(model.bidTime).isAfter(moment(currentProductBid.product.startTime)) &&
      moment(model.bidTime).isBefore(moment(currentProductBid.product.closeTime)) &&
      model.amount > currentProductBid.highestBid.amount
    ) {
      this.products[index].highestBid = model;
    }
  }
}
