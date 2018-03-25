import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClothingItem } from "../../entities/ClothingItem";
import { WardrobeLocation } from "../../entities/location";
import { WardrobeService } from "../../services/wardrobeservice";
import { ClothingItemService } from "../../services/clothingItemService";

@Component({
    selector: 'location-detail',
    templateUrl: './locationdetail.component.html'
})
export class LocationDetailComponent implements OnInit {
    public location: WardrobeLocation;
    public clothingItems: ClothingItem[];

    constructor(private route: ActivatedRoute, private locationService: WardrobeService, private clothingItemService: ClothingItemService ) { }

    ngOnInit() {
        var sub = this.route.params.subscribe(params => {
            var locationId = params['id'];
            this.loadLocation(locationId);
            this.loadItems(locationId);
        });
    }

    private loadLocation(locationId: string) {
        this.locationService.getLocationById(locationId).subscribe(result => {
            this.location = result;
        }, error => {
            console.error(error);
        });
    }

    private loadItems(locationId: string) {
        
        this.clothingItemService.getClothingItemsForLocation(locationId).subscribe(result => {
            this.clothingItems = result;
            console.dir(result);
        }, error => {
            console.error(error);
        });
    }
}