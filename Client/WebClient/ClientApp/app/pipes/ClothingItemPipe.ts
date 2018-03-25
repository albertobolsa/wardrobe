import { Pipe, PipeTransform } from '@angular/core';
import { ClothingItem } from "../entities/ClothingItem";

@Pipe({ name: 'clothingItemFilter' })
export class ClothingItemFilterPipe implements PipeTransform {

    transform(items: ClothingItem[], searchText: string): ClothingItem[] {
        if (!items) return [];
        if (!searchText) return items;

        searchText = searchText.toLowerCase();
        return items.filter(it => {
            if (!it.type) {
                return false;
            }
            return it.type.toLowerCase().includes(searchText);
        });
    }
}