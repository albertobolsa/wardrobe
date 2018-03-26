import { Component, OnInit } from '@angular/core';
import { ClothingItem } from "../../entities/ClothingItem";
import { ClothingItemService } from "../../services/clothingItemService";
import { ProgressService } from "../../services/progressService";

@Component({
    selector: 'all-items',
    templateUrl: './allitems.component.html',
    styleUrls: ['./allitems.component.css']
})
export class AllItemsComponent {

    public isNewItemOpen: boolean = false;
    public clothingItems: ClothingItem[];
    public newItem: ClothingItem = new ClothingItem();

    constructor(private service: ClothingItemService, private progress: ProgressService) { }

    ngOnInit() {
        this.loadViewData();
    }

    private loadViewData() {

        this.progress.show('Loading clothing items');
        this.service.getAllClothingItems().subscribe(result => {
            this.clothingItems = result;
            this.progress.hide();
        }, error => {
            console.error(error);
            this.progress.hide();
        });
    }

    newItemClick(event: object) {
        this.isNewItemOpen = true;
        this.newItem = new ClothingItem();
    }
}
