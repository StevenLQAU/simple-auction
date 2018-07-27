import { BidsModule } from './bids.module';

describe('BidsModule', () => {
  let bidsModule: BidsModule;

  beforeEach(() => {
    bidsModule = new BidsModule();
  });

  it('should create an instance', () => {
    expect(bidsModule).toBeTruthy();
  });
});
