﻿import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import { ClothingItem } from "../entities/ClothingItem";
import { environment } from "../environments/environment";
import 'rxjs/add/operator/map';

@Injectable()
export class ClothingItemService {

    constructor(private http: Http) {}

    getAllClothingItems(): Observable<ClothingItem[]> {

        return this.http.get(environment.serviceUrl + '/api/ClothingItem').map(res => {
            return res.json() as ClothingItem[];
        });
    }

    getClothingItemsForLocation(locationId: string): Observable<ClothingItem[]> {
        console.log(locationId);
        return this.http.get(environment.serviceUrl + '/api/ClothingItem/location/' + locationId).map(res => {
            console.dir(res.json());
            return res.json() as ClothingItem[];
        });
    }

    addClothingItem(clothingItem: ClothingItem): Observable<object> {
        return this.http.post(environment.serviceUrl + '/api/ClothingItem', clothingItem);
    }

    deleteClothingItem(clothingItemId: string): Observable<object> {
        return this.http.delete(environment.serviceUrl + '/api/ClothingItem/' + clothingItemId);
    }
}