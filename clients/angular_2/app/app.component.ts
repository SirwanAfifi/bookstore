import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    templateUrl: 'app/app.component.html' 
})
export class AppComponent { 
    
    title: string = "Customer App";
    name = "Sirwan";
    color = "blue";

    ChangeSuitColor() {
        if (this.color === "red")
            this.color = "blue";
        else
            this.color = "red";
    }
}
