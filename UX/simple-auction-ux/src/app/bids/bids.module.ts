import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BidsMainComponent } from './bids-main/bids-main.component';
import { BidsService } from './bids.service';
import { SharedModule } from '../shared/shared.module';
import { ProductComponent } from './product/product.component';

@NgModule({
  imports: [
    SharedModule
  ],
  exports: [BidsMainComponent],
  providers: [],
  declarations: [BidsMainComponent, ProductComponent]
})
export class BidsModule { }
