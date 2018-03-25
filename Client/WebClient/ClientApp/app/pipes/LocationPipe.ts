import { Pipe, PipeTransform } from '@angular/core';
import { WardrobeLocation } from "../entities/location";

@Pipe({ name: 'locationFilter' })
export class LocationFilterPipe implements PipeTransform {

    transform(items: WardrobeLocation[], searchText: string): WardrobeLocation[] {
        if (!items) return [];
        if (!searchText) return items;

        searchText = searchText.toLowerCase();
        return items.filter(it => {
            if (!it.name) {
                return false;
            }
            return it.name.toLowerCase().includes(searchText);
        });
    }
}