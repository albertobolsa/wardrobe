import { Component, OnInit } from '@angular/core';
import { WardrobeLocation } from "../../entities/location";
import { ClothingItem } from "../../entities/ClothingItem";
import { WardrobeService } from "../../services/wardrobe.service";
import { ClothingItemService } from "../../services/clothingItem.service";
import { ProgressService } from "../../services/progress.service";
import { ErrorService } from "../../services/error.service";

@Component({
    selector: 'transfer',
    templateUrl: './transfer.component.html'
})
export class TransferComponent implements OnInit {

    public locations: WardrobeLocation[];
    public clothingItems: ClothingItem[];
    public selectedItem: string;
    public selectedLocation: string;
    public shouldDisable: boolean = false;

    constructor(private locationService: WardrobeService, private clothingService: ClothingItemService, private progress: ProgressService, private errorService: ErrorService) { }

    ngOnInit() {
        this.progress.show('Loading data');
        this.locationService.getLocations().subscribe(
            result => {
                this.locations = result;
                if (result.length > 0) {
                    this.selectedLocation = result[0].id;
                }
                if (this.shouldDisable) {
                    this.progress.hide();
                } else {
                    this.shouldDisable = true;
                }
            },
            response => {
                this.progress.hide();
                this.errorService.showResponseError('Error loading locations', response);
            });

        this.clothingService.getAllClothingItems().subscribe(
            result => {
                this.clothingItems = result;
                if (result.length > 0) {
                    this.selectedItem = result[0].id;
                }
                if (this.shouldDisable) {
                    this.progress.hide();
                } else {
                    this.shouldDisable = true;
                }
            },
            response => {
                this.progress.hide();
                this.errorService.showResponseError('Error loading clothing items', response);
            });
    }



    transferClick(event: object) {
        this.progress.show('Transferring item');
        this.clothingService.transferItem(this.selectedItem, this.selectedLocation).subscribe(
            result => {
                this.progress.hide();
            },
            response => {
                this.progress.hide();
                this.errorService.showResponseError('Error loading clothing items', response);
            });
    }
}