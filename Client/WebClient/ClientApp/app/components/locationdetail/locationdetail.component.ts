import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClothingItem } from "../../entities/ClothingItem";
import { WardrobeLocation } from "../../entities/location";
import { WardrobeService } from "../../services/wardrobe.service";
import { ClothingItemService } from "../../services/clothingItem.service";
import { ProgressService } from "../../services/progress.service";
import { ErrorService } from "../../services/error.service";

@Component({
    selector: 'location-detail',
    templateUrl: './locationdetail.component.html'
})
export class LocationDetailComponent implements OnInit {
    public location: WardrobeLocation;
    public clothingItems: ClothingItem[];
    public isNewItemOpen: boolean = false;
    public newItem: ClothingItem = new ClothingItem();

    constructor(
        private route: ActivatedRoute,
        private locationService: WardrobeService,
        private clothingItemService: ClothingItemService,
        private progress: ProgressService,
        private errorService: ErrorService) { }

    ngOnInit() {
        var sub = this.route.params.subscribe(params => {
            var locationId = params['id'];
            this.loadLocation(locationId);
            this.loadItems(locationId);
        });
    }

    loadLocation(locationId: string) {
        this.locationService.getLocationById(locationId).subscribe(
            result => {
                this.location = result;
            },
            response => {
                this.errorService.showResponseError(response);
            });
    }

    loadItems(locationId: string) {
        this.progress.show('Loading items');
        this.clothingItemService.getClothingItemsForLocation(locationId).subscribe(
            result => {
                this.progress.hide();
                this.clothingItems = result;
            },
            response => {
                this.progress.hide();
                this.errorService.showResponseError(response);
            });
    }

    newItemClick(event: object) {
        this.isNewItemOpen = true;
        this.newItem = new ClothingItem();
        this.newItem.locationId = this.location.id;
    }
}