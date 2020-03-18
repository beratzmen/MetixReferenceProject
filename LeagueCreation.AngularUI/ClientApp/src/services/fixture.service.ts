import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";



@Injectable()
export class FixtureService {

    constructor(private httpClient: HttpClient, @Inject("url") private url: string) { }

    GetAll() {
        return this.httpClient.get(this.url + "api/fixtures/");
    }
    GetSingle(id: number) {
        return this.httpClient.get(this.url + "api/fixtures/get/" + id);
    }
    PostAdd(entity: Team[]) {
        return this.httpClient.post(this.url + "api/fixtures/post", entity);
    }
    Remove(id: number) {
        return this.httpClient.delete(this.url + "api/fixtures/" + id);
    }
    PutUpdate(team: Fixture) {
        return this.httpClient.put(this.url + "api/fixtures/put", team);
    }
}

interface Team {
    Id?: number;
    Name?: string;
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
    ScoreCheck?: boolean;
}

