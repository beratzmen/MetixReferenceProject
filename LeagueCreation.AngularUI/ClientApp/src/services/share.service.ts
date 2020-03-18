import { Injectable } from '@angular/core';
import { FixtureService } from '../services/fixture.service';


@Injectable({
    providedIn: 'root'
})

export class ShareService {

    public fixtureList: Fixture[];


    constructor(private fixtureService: FixtureService) { }
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
