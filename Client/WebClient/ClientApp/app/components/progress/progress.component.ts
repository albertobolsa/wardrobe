import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { ProgressService } from "../../services/progressService";
import { ProgressState } from "../../entities/ProgressState";

@Component({
    selector: 'progress-splash',
    templateUrl: 'progress.component.html',
    styleUrls: ['progress.component.css']
})
export class ProgressComponent implements OnInit {

    private show: boolean = false;
    private message: string = 'Loading';
    private subscription: Subscription;

    constructor(private loaderService: ProgressService) { }

    ngOnInit() {
        this.subscription = this.loaderService.loaderState
            .subscribe((state: ProgressState) => {
                this.show = state.show;
                this.message = state.message;
            });
    }
    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}