﻿import { Injectable } from '@angular/core';
import { Http} from '@angular/http';
import { Observable } from 'rxjs';
import { environment } from "../environments/environment";
import { LogMessage } from "../entities/LogMessage";
import 'rxjs/add/operator/map';

@Injectable()
export class LogService {

    constructor(private http: Http) { }

    getLogs(): Observable<LogMessage[]> {

        return this.http.get(environment.serviceUrl + '/api/Logging').map(res => {
            return res.json() as LogMessage[];
        });
    }

    writeError(message: LogMessage) {

        return this.http.post(environment.serviceUrl + '/api/Logging', message).map(res => {
            return res.json() as LogMessage[];
        }).subscribe(
            data => {},
            error => console.error(error)
        );
    }
}