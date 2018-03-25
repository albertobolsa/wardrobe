import { Component, OnInit } from '@angular/core';
import { ClothingItem } from "../../entities/ClothingItem";
import { ClothingItemService } from "../../services/clothingItemService";

@Component({
    selector: 'all-items',
    templateUrl: './allitems.component.html'
})
export class AllItemsComponent {

    public isLoading: boolean = true;
    public clothingItems: ClothingItem[];

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
}
