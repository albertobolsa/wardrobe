import { Component, OnInit } from '@angular/core';
import { ClothingItem } from "../../entities/ClothingItem";
import { ClothingItemService } from "../../services/clothingItemService";

@Component({
    selector: 'all-items',
    templateUrl: './allitems.component.html',
    styleUrls: ['./allitems.component.css']
})
export class AllItemsComponent {

    public isLoading: boolean = true;
    public isNewItemOpen: boolean = false;
    public clothingItems: ClothingItem[];
    public newItem: ClothingItem = new ClothingItem();

    constructor(private service: ClothingItemService) { }

    ngOnInit() {
        this.loadViewData();
    }

    private loadViewData() {
        this.isLoading = true;
        this.service.getAllClothingItems().subscribe(result => {
            this.clothingItems = result;
            this.isLoading = false;
        }, error => {
            console.error(error);
            this.isLoading = false;
        });
    }

    newItemClick(event: object) {
        this.isNewItemOpen = true;
        this.newItem = new ClothingItem();
    }
}
