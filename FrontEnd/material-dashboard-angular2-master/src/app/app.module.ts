import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';

import {
  AgmCoreModule
} from '@agm/core';
import { CompaniesComponent } from './companies/companies.component';
import { PeopleComponent } from './people/people.component';
import { TaxationsComponent } from './taxations/taxations.component';
import { EquipmentsComponent } from './equipments/equipments.component';
import { RequestsComponent } from './requests/requests.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    AgmCoreModule.forRoot({
      apiKey: 'YOUR_GOOGLE_MAPS_API_KEY'
    })
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    CompaniesComponent,
    PeopleComponent,
    TaxationsComponent,
    EquipmentsComponent,
    RequestsComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
