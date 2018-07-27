export enum ProductStatus {
  NotStart = 1,
  InBid = 2,
  End = 4
}

export interface ProductModel {
  id: string;
  name: string;
  startTime: string;
  closeTime: string;
  status: ProductStatus;
}

export interface BidModel {
  userId: string;
  productId: string;
  amount: number;
  bidTime: Date;
}

export interface ProductBidModel {
  product: ProductModel;
  highestBid: BidModel;
}
