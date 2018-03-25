import { Component, OnInit } from '@angular/core';
import { } from '@types/googlemaps';
import { WardrobeLocation } from "../../entities/location";
import { WardrobeService } from "../../services/wardrobeservice";
import { Router } from '@angular/router';

@Component({
    selector: 'locations',
    templateUrl: './locations.component.html',
    styleUrls: ['./locations.component.css']
})
export class LocationsComponent implements OnInit {
    public locations: WardrobeLocation[];
    public newLocation: WardrobeLocation;
    public isNewLocationOpen: boolean = false;
    public isLoading: boolean = true;
    public isProcessingRequest: boolean = false;

    constructor(private service: WardrobeService, private router: Router) { }

    ngOnInit() {
        this.loadViewData();
    }

    newLocationClick(event: object) {
        this.isNewLocationOpen = true;
        this.newLocation = new WardrobeLocation();
    }

    saveLocationClick(event: object) {
        this.isNewLocationOpen = false;
        this.isProcessingRequest = true;
        this.service.addLocation(this.newLocation).subscribe(
            res => {
                this.loadViewData();
                this.isProcessingRequest = false;
            },
            err => {
                console.error(err);
                alert("Error occured");
                this.isProcessingRequest = false;
            });
    }

    discardLocationClick(event: object) {
        this.isNewLocationOpen = false;
    }

    deleteLocationClick(event: object, locationId: string) {
        this.isProcessingRequest = true;
        this.service.deleteLocation(locationId).subscribe(
            res => {
                this.loadViewData();
                this.isProcessingRequest = false;
            },
            err => {
                console.error(err);
                alert("Error occured");
                this.isProcessingRequest = false;
            });
    }

    private loadViewData() {
        this.isLoading = true;
        this.service.getLocations().subscribe(result => {
            this.locations = result;

            setTimeout(() => {
                for (let location of this.locations) {
                    var map = new google.maps.Map(document.getElementById('map-' + location.id), {
                        center: { lat: location.latitude, lng: location.longitude },
                        zoom: 12, disableDefaultUI: true
                    });
                }

                this.isLoading = false;
            }, 50);
        }, error => {
            console.error(error);
            this.isLoading = false;
        });
    }
}