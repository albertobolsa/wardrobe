import { Pipe, PipeTransform } from '@angular/core';
import { LogMessage } from "../entities/LogMessage";

@Pipe({ name: 'logFilter' })
export class LogFilterPipe implements PipeTransform {

    transform(items: LogMessage[], searchText: string): LogMessage[] {
        if (!items) return [];
        if (!searchText) return items;

        searchText = searchText.toLowerCase();
        return items.filter(it => {
            if (!it.message) {
                return false;
            }
            return it.message.toLowerCase().includes(searchText)
                || it.stacktrace.toLowerCase().includes(searchText)
                || it.source.toLowerCase().includes(searchText);
        });
    }
}