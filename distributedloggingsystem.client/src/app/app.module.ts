import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { AuthInterceptor } from 'src/interceptors/auth-interceptor.service';
import { AppComponent } from './app.component';
import { DistributedLoggingListComponent } from './components/distributed-logging-list/distributed-logging-list.component';

@NgModule({
  declarations: [AppComponent, DistributedLoggingListComponent],
  imports: [BrowserModule, HttpClientModule, NgbModule, NgxDatatableModule],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
