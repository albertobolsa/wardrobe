import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

    ngOnInit() {
        this.loadMapsScript(environment.googleMapsApiKey);
    }

    private loadMapsScript(apiKey: string) {
        let node = document.createElement('script');
        node.src = 'https://maps.googleapis.com/maps/api/js?key=' + apiKey;
        node.type = 'text/javascript';
        node.async = false;
        node.charset = 'utf-8';
        document.getElementsByTagName('head')[0].appendChild(node);
    }
}
