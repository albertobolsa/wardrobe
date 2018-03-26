import { Component, Input } from '@angular/core';
import { ClothingItem } from "../../entities/ClothingItem";
import { ImageService } from "../../services/image.service";
import { ClothingItemService } from "../../services/clothingItem.service";
import { environment } from "../../environments/environment";

@Component({
    selector: 'clothing-item-card',
    templateUrl: './clothingitemcard.component.html',
    styleUrls: ['./clothingitemcard.component.css']
})
export class ClothingItemCardComponent {
    @Input()
    item: ClothingItem;
    @Input()
    isEdit: boolean = false;
    baseImageUrl: string = environment.serviceUrl + '/image/';

    constructor(private imageService: ImageService, private clothingItemService: ClothingItemService) {}

    fileChange(event: any) {
        this.imageService.uploadAndLinkFiles(this.item.id, event.target.files);
    }

    unlinkImage(imageId: string, clothingItemId: string) {

        this.imageService.unlinkImage(imageId, clothingItemId);
    }

    saveClothingItem() {

        if (!this.item.id) {
            this.clothingItemService.addClothingItem(this.item).subscribe(
                res => {
                    this.isEdit = false;
                },
                err => {
                    console.error(err);
                    alert("Error occured");
                });
        } else {
            this.clothingItemService.updateClothingItem(this.item).subscribe(
                res => {
                    this.isEdit = false;
                },
                err => {
                    console.error(err);
                    alert("Error occured");
                });
        }
    }

    deleteClothingItem() {
        this.clothingItemService.deleteClothingItem(this.item.id).subscribe(
            res => {
                this.isEdit = false;
            },
            err => {
                console.error(err);
                alert("Error occured");
            });
    }
}