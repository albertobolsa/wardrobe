import { Component, OnInit } from '@angular/core';
import { LogService } from "../../services/log.service";
import { LogMessage } from "../../entities/LogMessage";
import { ProgressService } from "../../services/progress.service";
import { ErrorService } from "../../services/error.service";

@Component({
    selector: 'logs',
    templateUrl: './logs.component.html',
    styleUrls: ['./logs.component.css']
})
export class LogsComponent implements OnInit {

    public logMessages: LogMessage[];

    constructor(private service: LogService, private progress: ProgressService, private errorService: ErrorService) {}

    ngOnInit() {
        this.progress.show('Loading Event logs');
        this.service.getLogs().subscribe(result => {
            this.logMessages = result;
            this.progress.hide();
        }, error => {
            this.errorService.showResponseError('Error loading event logs', error);
            this.progress.hide();
        });
    }
}