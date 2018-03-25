import { Component, Input } from '@angular/core';
import { ClothingItem } from "../../entities/ClothingItem";
import { ImageService } from "../../services/imageService";

@Component({
    selector: 'clothing-item-card',
    templateUrl: './clothingitemcard.component.html',
    styleUrls: ['./clothingitemcard.component.css']
})
export class ClothingItemCardComponent {
    @Input() item: ClothingItem;
    private isEdit: boolean = false;

    constructor(private imageService: ImageService) { }

    fileChange(event: any) {

        this.imageService.uploadAndLinkFiles(this.item.id, event.target.files);
    }  

    unlinkImage(imageId: string, clothingItemId: string) {

        this.imageService.unlinkImage(imageId, clothingItemId);
    }  
}