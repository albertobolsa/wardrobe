import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { LocationsComponent } from './components/locations/locations.component';
import { LocationDetailComponent } from './components/locationdetail/locationdetail.component';
import { AllItemsComponent } from './components/allitems/allitems.component';
import { TransferComponent } from './components/transfer/transfer.component';
import { ClothingItemCardComponent } from "./components/clothingitemcard/clothingitemcard.component";
import { WardrobeService } from "./services/wardrobeservice";
import { ClothingItemService } from "./services/clothingItemService";

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        LocationsComponent,
        LocationDetailComponent,
        AllItemsComponent,
        TransferComponent,
        ClothingItemCardComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'locations', component: LocationsComponent },
            { path: 'location-detail/:id', component: LocationDetailComponent },
            { path: 'all-items', component: AllItemsComponent },
            { path: 'transfer', component: TransferComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        WardrobeService,
        ClothingItemService
    ]
})
export class AppModuleShared {
}
