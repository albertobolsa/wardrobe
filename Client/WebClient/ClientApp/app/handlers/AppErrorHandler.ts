import { ErrorHandler, Injectable } from '@angular/core';
import { ErrorService } from "../services/error.service";

@Injectable()
export class AppErrorHandler implements ErrorHandler {

    constructor(private service: ErrorService) {}

    handleError(error: any) {

        this.service.showError('Unexpected error happened', error.message);
    }
}