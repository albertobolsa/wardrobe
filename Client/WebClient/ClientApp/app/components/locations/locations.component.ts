import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'locations',
    templateUrl: './locations.component.html'
})
export class LocationsComponent {
    public locations: Location[];

    constructor(http: Http) {
        http.get('http://localhost/Wardrobe.Service/api/location').subscribe(result => {
            console.dir(result.json());

            this.locations = result.json() as Location[];

            console.dir(this.locations);
        }, error => console.error(error));
    }
}

interface Location {
    name: string;
    latitude: number;
    longitude: number;
}
