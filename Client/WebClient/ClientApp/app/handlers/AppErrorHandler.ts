import { ErrorHandler, Injectable } from '@angular/core';
import { LogService } from "../services/log.service";
import { LogMessage } from "../entities/LogMessage";

@Injectable()
export class AppErrorHandler implements ErrorHandler {

    constructor(private service: LogService) {}

    handleError(error: any) {
        
        console.dir(error.message);
        var message = new LogMessage();
        message.logLevel = 4;
        message.message = error.message;
        this.service.writeError(message);
    }
}