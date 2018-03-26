import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ClothingItem } from "../../entities/ClothingItem";
import { ImageService } from "../../services/image.service";
import { ClothingItemService } from "../../services/clothingItem.service";
import { ProgressService } from "../../services/progress.service";
import { ErrorService } from "../../services/error.service";
import { environment } from "../../environments/environment";

@Component({
    selector: 'clothing-item-card',
    templateUrl: './clothingitemcard.component.html',
    styleUrls: ['./clothingitemcard.component.css']
})
export class ClothingItemCardComponent {
    @Input() item: ClothingItem;
    @Input() isEdit: boolean = false;
    @Output() onDiscarded : EventEmitter<ClothingItem> = new EventEmitter<ClothingItem>();
    @Output() onSaved : EventEmitter<ClothingItem> = new EventEmitter<ClothingItem>();
    @Output() onDeleted : EventEmitter<ClothingItem> = new EventEmitter<ClothingItem>();
    @Output() onImagesChanged : EventEmitter<ClothingItem> = new EventEmitter<ClothingItem>();

    baseImageUrl: string = environment.serviceUrl + '/image/';

    constructor(private imageService: ImageService, private clothingItemService: ClothingItemService, private progress: ProgressService, private errorService: ErrorService) {}

    fileChange(event: any) {
        this.imageService.uploadAndLinkFiles(this.item.id, event.target.files);
        this.onImagesChanged.emit(this.item);
    }

    unlinkImage(imageId: string, clothingItemId: string) {
        this.imageService.unlinkImage(imageId, clothingItemId);
        this.onImagesChanged.emit(this.item);
    }

    saveClothingItem() {
        if (!this.item.id) {
            this.progress.show('Adding clothing item');
            this.clothingItemService.addClothingItem(this.item).subscribe(
                res => {
                    this.isEdit = false;
                    this.progress.hide();
                    this.onSaved.emit(this.item);
                },
                response => {
                    this.progress.hide();
                    this.errorService.showResponseError('Error adding clothing item', response);
                });
        } else {
            this.progress.show('Saving clothing item');
            this.clothingItemService.updateClothingItem(this.item).subscribe(
                res => {
                    this.isEdit = false;
                    this.progress.hide();
                    this.onSaved.emit(this.item);
                },
                response => {
                    this.progress.hide();
                    this.errorService.showResponseError('Error saving clothing item', response);
                });
        }
    }

    deleteClothingItem() {
        this.progress.show('Deleting clothing item');
        this.clothingItemService.deleteClothingItem(this.item.id).subscribe(
            res => {
                this.isEdit = false;
                this.onDeleted.emit(this.item);
            },
            response => {
                this.progress.hide();
                this.errorService.showResponseError('Error deleting clothing item', response);
            });
    }

    discardClothingItem() {
        this.isEdit = false;
        this.onDiscarded.emit(this.item);
    }
}