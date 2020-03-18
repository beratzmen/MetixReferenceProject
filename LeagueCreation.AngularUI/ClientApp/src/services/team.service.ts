import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable()
export class TeamService {

    constructor(private httpClient: HttpClient, @Inject("url") private url: string) { }

    GetAll() {
        return this.httpClient.get(this.url + "api/teams/");
    }
    GetSingle(id: number) {
        return this.httpClient.get(this.url + "api/team/getsingle/" + id);
    }
    PostAdd(team: Team) {
        return this.httpClient.post(this.url + "api/teams/post", team);
    }
    PutUpdate(team: Team) {
        return this.httpClient.put(this.url + "api/teams/put", team);
    }
    Remove(id: number) {
        return this.httpClient.delete(this.url + "api/teams/" + id);
    }
}

interface Team {
    Id?: number;
    Name?: string;
}
