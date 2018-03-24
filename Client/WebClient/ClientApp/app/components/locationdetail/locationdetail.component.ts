import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'location-detail',
    templateUrl: './locationdetail.component.html'
})
export class LocationDetailComponent implements OnInit {
    public location: Location;
    private sub: any;
    private id: string;

    constructor(private route: ActivatedRoute) { }

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this.id = params['id'];
            console.dir(this.id);
        });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}