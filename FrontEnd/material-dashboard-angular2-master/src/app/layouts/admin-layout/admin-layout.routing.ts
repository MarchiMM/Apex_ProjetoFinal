import { Routes } from '@angular/router';
import { CompaniesComponent } from 'app/companies/companies.component';
import { EquipmentsComponent } from 'app/equipments/equipments.component';
import { PeopleComponent } from 'app/people/people.component';
import { RequestsComponent } from 'app/requests/requests.component';
import { TaxationsComponent } from 'app/taxations/taxations.component';


export const AdminLayoutRoutes: Routes = [
    {
      path: '',
      children: [ {
        path: 'requests',
        component: RequestsComponent
    }]}, {
    path: '',
    children: [ {
      path: 'equipments',
      component: EquipmentsComponent
    }]
    }, {
      path: '',
      children: [ {
        path: 'people',
        component: PeopleComponent
        }]
    }, {
        path: '',
        children: [ {
            path: 'companies',
            component: CompaniesComponent
        }]
    }, {
        path: '',
        children: [ {
            path: 'taxations',
            component: TaxationsComponent
        }]
    }
];
