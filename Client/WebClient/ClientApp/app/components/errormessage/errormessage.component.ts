import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { ErrorService } from "../../services/error.service";
import { ProgressState } from "../../entities/ProgressState";

@Component({
    selector: 'error-message',
    templateUrl: 'errormessage.component.html',
    styleUrls: ['errormessage.component.css']
})
export class ErrorMessageComponent implements OnInit {

    private show: boolean = false;
    private message: string = '';
    private subscription: Subscription;

    constructor(private service: ErrorService) { }

    ngOnInit() {
        this.subscription = this.service.state
            .subscribe((state: ProgressState) => {
                this.show = state.show;
                this.message = state.message;
            });
    }
    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}