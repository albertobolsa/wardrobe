import { Component, OnInit } from '@angular/core';
import { LogService } from "../../services/log.service";
import { LogMessage } from "../../entities/LogMessage";

@Component({
    selector: 'logs',
    templateUrl: './logs.component.html',
    styleUrls: ['./logs.component.css']
})
export class LogsComponent implements OnInit {
    public logMessages: LogMessage[];

    constructor(private service: LogService) {}

    ngOnInit() {
        this.service.getLogs().subscribe(result => {
            this.logMessages = result;
        }, error => {
            console.error(error);
        });
    }
}