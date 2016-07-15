import { Component } from '@angular/core';
import { CustomersComponent } from './customer/customers.component';

@Component({
    selector: 'my-app',
    templateUrl: 'app/app.component.html',
    directives: [
        CustomersComponent
    ] 
})
export class AppComponent { 
    
    // [ ] means property binding - C to D
    // ( ) means event binding - D to C

    title: string = "Customer App";
    name = "Sirwan";
    color = "green";
    
    ChangeSuitColor() {
        if (this.color === "red")
            this.color = "blue";
        else
            this.color = "green";
    }
}
