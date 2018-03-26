import { Component, OnInit } from '@angular/core';
import { ClothingItem } from "../../entities/ClothingItem";
import { ClothingItemService } from "../../services/clothingItem.service";
import { ProgressService } from "../../services/progress.service";
import { ErrorService } from "../../services/error.service";

@Component({
    selector: 'all-items',
    templateUrl: './allitems.component.html',
    styleUrls: ['./allitems.component.css']
})
export class AllItemsComponent {

    public isNewItemOpen: boolean = false;
    public clothingItems: ClothingItem[];
    public newItem: ClothingItem = new ClothingItem();

    constructor(private service: ClothingItemService, private progress: ProgressService, private errorService: ErrorService) { }

    ngOnInit() {
        this.loadViewData();
    }

    loadViewData() {
        this.progress.show('Loading clothing items');
        this.service.getAllClothingItems().subscribe(
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
    }
}
