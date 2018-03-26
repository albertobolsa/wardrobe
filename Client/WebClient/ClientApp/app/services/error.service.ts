import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { ProgressState } from "../entities/ProgressState";
import { LogMessage } from "../entities/LogMessage";
import { LogService } from "./log.service";

@Injectable()
export class ErrorService {

    private subject = new Subject<ProgressState>();
    state = this.subject.asObservable();

    constructor(private logService: LogService) { }

    showError(message: string) {
        console.error(message);
        var log = new LogMessage();
        log.logLevel = 4;
        log.message = message;
        this.logService.writeError(log);
        this.subject.next(<ProgressState>{ show: true, message: message });
    }

    showResponseError(response: Response) {
        console.error(response);
        var log = new LogMessage();
        log.logLevel = 4;
        log.message = response.status + ': ' + response.statusText;
        this.logService.writeError(log);
        this.subject.next(<ProgressState>{ show: true, message: log.message });
    }

    hideError() {
        this.subject.next(<ProgressState>{ show: false });
    }
}