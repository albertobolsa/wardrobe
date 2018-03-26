import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { ProgressState } from "../entities/ProgressState";

@Injectable()
export class ProgressService {

    private subject = new Subject<ProgressState>();
    state = this.subject.asObservable();

    show(message: string) {
        this.subject.next(<ProgressState>{ show: true, message: message });
    }

    hide() {
        this.subject.next(<ProgressState>{ show: false });
    }
}