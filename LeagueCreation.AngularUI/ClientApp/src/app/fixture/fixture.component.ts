import { Component, ElementRef, ViewChild } from '@angular/core';
import { FixtureService } from '../../services/fixture.service';
import { ShareService } from "../../services/share.service";
import { TeamService } from "../../services/team.service";
import { HttpClient } from "@angular/common/http";
import { Injectable, Inject } from '@angular/core';
import { HostListener } from '@angular/core';

@Component({
    selector: 'app-fixture-component',
    templateUrl: './fixture.component.html'
})

export class fixtureComponent  {
    key: string;
    public teamList: Team[];

    public teamPointList: Team[];
    public fixtureList: Fixture[];
    public fixtureList2: Fixture[];

    constructor(private shareService: ShareService, private teamPointService: TeamService,
        private httpClient: HttpClient, private teamService: TeamService,
        @Inject("url") private url: string, private fixtureService: FixtureService) {
        this.httpClient.get(this.url + "api/fixtures/get/1")
            .subscribe((response: string) => this.fixtureList = JSON.parse(response));
        this.teamPointService.GetAll().subscribe((response: string) => this.teamPointList = JSON.parse(response));
        //((<HTMLInputElement>document.getElementById("spanId")).value) = spanIdText;
    }

    @HostListener('window:keyup', ['$event'])
    keyEvent(event: KeyboardEvent) {

        var id = parseInt((<HTMLInputElement>document.getElementById("weekId")).value);
        //alert(id);
        //buraya bir bakıcam week son hafta sayısı konrolü eklenecek
        if (event.keyCode === KEY_CODE.RIGHT_ARROW) {
            id++;
            return this.httpClient.get(this.url + "api/fixtures/get/" + id).subscribe((response: string) => this.fixtureList = JSON.parse(response));
        }

        if (event.keyCode === KEY_CODE.LEFT_ARROW) {
            if (id > 1) {
                id--;
                return this.httpClient.get(this.url + "api/fixtures/get/" + id).subscribe((response: string) => this.fixtureList = JSON.parse(response));
            }
        }
    }

    PutUpdate(fixture: Fixture) {
        return this.httpClient.put(this.url + "api/fixtures/put", fixture);
    }

    inputValue(fixtureId: number, value1: number, value2: number, homeId: number, awayId: number, pointHome: number, pointAway: number) {
        let putFixture: Fixture = {
            Id: fixtureId,
            Away: awayId,
            Home: homeId,
            HomeScore: value1,
            AwayScore: value2,
            PointHome: pointHome,
            PointAway: pointAway
        };

        this.fixtureService.PutUpdate(putFixture).subscribe((response: Fixture) => {
            this.teamPointService.GetAll().subscribe((response: string) => this.teamPointList = JSON.parse(response));
        });

    }

}

export enum KEY_CODE {
    RIGHT_ARROW = 39,
    LEFT_ARROW = 37
}
interface Fixture {
    Id?: number;
    HomeName?: string;
    Home?: number;
    AwayName?: string;
    Away?: number;
    Week?: number;
    HomeScore?: number;
    AwayScore?: number;
    PointHome?: number;
    PointAway?: number;
}
interface Team {
    Id?: number;
    Name?: string;
    Point?: number;
}
