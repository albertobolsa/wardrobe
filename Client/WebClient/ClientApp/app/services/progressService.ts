import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { ProgressState } from "../entities/ProgressState";

@Injectable()
export class ProgressService {

    private loaderSubject = new Subject<ProgressState>();
    loaderState = this.loaderSubject.asObservable();

    show(message: string) {
        this.loaderSubject.next(<ProgressState>{ show: true, message: message });
    }

    hide() {
        this.loaderSubject.next(<ProgressState>{ show: false });
    }
}