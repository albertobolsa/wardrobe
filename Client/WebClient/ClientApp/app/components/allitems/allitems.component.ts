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

    public isEdit: boolean = true;
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
                this.errorService.showResponseError('Error loading clothing items', response);
            });
    }

    newItemClick(event: object) {
        this.isNewItemOpen = true;
        this.newItem = new ClothingItem();
        this.isEdit = true;
    }

    onDiscardedHandler(item: ClothingItem) {
        this.isNewItemOpen = false;
    }

    refreshViewHandler(item: ClothingItem) {
        this.isNewItemOpen = false;
        this.loadViewData();
    }
}
