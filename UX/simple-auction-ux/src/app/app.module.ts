import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { BidsModule } from './bids/bids.module';
import { LoginModule } from './login/login.module';
import { AuthInterceptor } from './auth-interceptor';
import { SharedModule } from './shared/shared.module';
import { LoginService } from './login/login.service';
import { BidsService } from './bids/bids.service';
import { SignalRService } from './signal-r.service';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BidsModule,
    LoginModule,
    SharedModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    LoginService,
    BidsService,
    SignalRService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
