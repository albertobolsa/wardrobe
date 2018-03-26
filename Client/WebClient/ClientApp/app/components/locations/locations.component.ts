import { Component, OnInit } from '@angular/core';
import { } from '@types/googlemaps';
import { WardrobeLocation } from "../../entities/location";
import { WardrobeService } from "../../services/wardrobe.service";
import { ProgressService } from "../../services/progress.service";
import { ErrorService } from "../../services/error.service";
import { Router } from '@angular/router';

@Component({
    selector: 'locations',
    templateUrl: './locations.component.html',
    styleUrls: ['./locations.component.css']
})
export class LocationsComponent implements OnInit {

    public locations: WardrobeLocation[];
    public newLocation: WardrobeLocation = new WardrobeLocation();
    public isNewLocationOpen: boolean = false;

    constructor(private service: WardrobeService, private router: Router, private progress: ProgressService, private errorService: ErrorService) { }

    ngOnInit() {
        this.loadViewData();
    }

    newLocationClick(event: object) {
        this.isNewLocationOpen = true;
        this.newLocation = new WardrobeLocation();
    }

    saveLocationClick(event: object) {
        this.isNewLocationOpen = false;
        this.progress.show('Writing Location');
        this.service.addLocation(this.newLocation).subscribe(
            res => {
                this.progress.hide();
                this.loadViewData();
            },
            response => {
                this.errorService.showResponseError('Error writing location', response);
                this.progress.hide();
            });
    }

    deleteLocationClick(event: object, locationId: string) {
        this.progress.show('Deleting Location');
        this.service.deleteLocation(locationId).subscribe(
            res => {
                this.progress.hide();
                this.loadViewData();
            },
            response => {
                this.errorService.showResponseError('Error deleting location', response);
                this.progress.hide();
            });
    }

    loadViewData() {
        this.progress.show('Loading locations');
        this.service.getLocations().subscribe(
            result => {
                this.locations = result;
                setTimeout(() => {
                    for (let location of this.locations) {
                        var map = new google.maps.Map(document.getElementById('map-' + location.id), {
                            center: { lat: location.latitude, lng: location.longitude },
                            zoom: 12, disableDefaultUI: true
                        });
                    }
                    this.progress.hide();
                }, 50);
            }, 
            response => {
                this.errorService.showResponseError('Error loading locations', response);
                this.progress.hide();
            });

        var map = new google.maps.Map(document.getElementById('map-new'), {
            center: { lat: 47.366670, lng: 47.366670 },
            zoom: 12, disableDefaultUI: true
        });
        google.maps.event.addListener(map, "click", (e: any) => {
            this.newLocation.latitude = e.latLng.lat();
            this.newLocation.longitude = e.latLng.lng();
        });
    }
}