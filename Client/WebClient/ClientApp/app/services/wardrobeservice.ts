import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import { WardrobeLocation } from "../entities/location";
import { environment } from "../environments/environment";
import 'rxjs/add/operator/map';

@Injectable()
export class WardrobeService {

    constructor(private http: Http) {}

    getLocations(): Observable<WardrobeLocation[]> {

        return this.http.get(environment.serviceUrl + '/api/location').map(res => {
            return res.json() as WardrobeLocation[];
        });
    }

    getLocationById(locationId: string): Observable<WardrobeLocation> {
        return this.http.get(environment.serviceUrl + '/api/location/' + locationId).map(res => {
            return res.json() as WardrobeLocation;
        });
    }

    addLocation(location: WardrobeLocation): Observable<object> {
        return this.http.post(environment.serviceUrl + '/api/location', location);
    }

    deleteLocation(locationId: string): Observable<object> {
        return this.http.delete(environment.serviceUrl + '/api/location/' + locationId);
    }
}