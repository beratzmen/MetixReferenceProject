import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { TeamService } from '../services/team.service';
import { FixtureService } from '../services/fixture.service';
//import { ShareService } from '../services/share.service';

//-----
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { fixtureComponent } from './fixture/fixture.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        fixtureComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'fixture', component: fixtureComponent },
        ])
    ],
    providers: [{ provide: "url", useValue: "http://localhost:55601/" }, TeamService, FixtureService],
    bootstrap: [AppComponent]
})
export class AppModule { }
