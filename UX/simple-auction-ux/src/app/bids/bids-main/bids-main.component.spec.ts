import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BidsMainComponent } from './bids-main.component';

describe('BidsMainComponent', () => {
  let component: BidsMainComponent;
  let fixture: ComponentFixture<BidsMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BidsMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BidsMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
