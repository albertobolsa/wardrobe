﻿import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { ProgressService } from "../../services/progress.service";
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
        this.subscription = this.loaderService.state
            .subscribe((state: ProgressState) => {
                this.show = state.show;
                this.message = state.message;
            });
    }
    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}