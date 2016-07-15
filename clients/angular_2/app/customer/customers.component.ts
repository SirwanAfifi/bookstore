import { Component, OnInit } from '@angular/core';
import { CustomerComponent } from './customer.component';


@Component({
    moduleId: module.id,
    selector: 'my-customers',
    templateUrl: 'customers.component.html',
    directives: [
        CustomerComponent
    ]
})
export class CustomersComponent implements OnInit {
    customers = [
        { id: 1, name: 'Sirwan' },
        { id: 2, name: 'Keyvan' },
        { id: 3, name: 'Omid' },
        { id: 4, name: 'Foad' }
    ];


    constructor() { }

    ngOnInit() { }

}