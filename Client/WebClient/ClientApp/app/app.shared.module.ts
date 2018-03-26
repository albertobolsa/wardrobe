import { NgModule, ErrorHandler } from '@angular/core';
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
import { LogsComponent } from "./components/logs/logs.component";
import { ProgressComponent } from "./components/progress/progress.component";
import { ErrorMessageComponent } from "./components/errormessage/errormessage.component";

import { WardrobeService } from "./services/wardrobe.service";
import { ClothingItemService } from "./services/clothingItem.service";
import { ImageService } from "./services/image.service";
import { LogService } from "./services/log.service";
import { ProgressService } from "./services/progress.service";
import { ErrorService } from "./services/error.service";

import { AppErrorHandler } from "./handlers/AppErrorHandler";
import { LogFilterPipe } from "./pipes/LogMessagePipe";
import { ClothingItemFilterPipe } from "./pipes/ClothingItemPipe";
import { LocationFilterPipe } from "./pipes/LocationPipe";

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        LocationsComponent,
        LocationDetailComponent,
        AllItemsComponent,
        TransferComponent,
        ClothingItemCardComponent,
        LogsComponent,
        ProgressComponent,
        ErrorMessageComponent,
        LogFilterPipe, ClothingItemFilterPipe, LocationFilterPipe
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
            { path: 'logs', component: LogsComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        WardrobeService,
        ClothingItemService,
        ImageService,
        LogService,
        ProgressService,
        ErrorService,
        { provide: ErrorHandler, useClass: AppErrorHandler }
    ]
})
export class AppModuleShared {
}
