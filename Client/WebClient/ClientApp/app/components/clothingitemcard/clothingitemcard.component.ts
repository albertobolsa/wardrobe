import { Component, Input } from '@angular/core';
import { ClothingItem } from "../../entities/ClothingItem";

@Component({
    selector: 'clothing-item-card',
    templateUrl: './clothingitemcard.component.html',
    styleUrls: ['./clothingitemcard.component.css']
})
export class ClothingItemCardComponent {
    @Input() item: ClothingItem;
}