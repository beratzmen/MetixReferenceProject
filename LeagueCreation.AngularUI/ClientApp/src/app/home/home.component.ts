import { Component } from '@angular/core';
import { TeamService } from '../../services/team.service';
import { FixtureService } from '../../services/fixture.service';
import { Router } from "@angular/router";
import { ShareService } from "../../services/share.service";


@Component({
    selector: 'app-home',
    templateUrl: './home.component.html'
})

export class HomeComponent {

    public teamList: Team[];
    team: Team;
    scoreCheck: boolean;
    //teamListCount: number;
    public fixtureList: Fixture[];

    constructor(private router: Router, private fixtureService: FixtureService,
        private shareService: ShareService, private teamService: TeamService) {
        this.teamService.GetAll().subscribe((response: string) => this.teamList = JSON.parse(response));
        this.fixtureService.GetAll().subscribe((response: boolean) => this.scoreCheck = response);
    }
    //ngOnInit() { this.scoreCheck = this.fixtureList[0].ScoreCheck; alert("a"); }

    GetAll() {
        this.teamService.GetAll().subscribe((response: string) => this.teamList = JSON.parse(response));
    }

    PostAdd(txtTeamName: HTMLInputElement) {

        let postTeam: Team = {
            Name: txtTeamName.value
        };

        this.teamService.PostAdd(postTeam).subscribe((response: Team) => {
            if (response) {
                this.team = response;
                this.GetAll();
            }
        });
    }

    PutUpdate(id: number, txtTeamName: HTMLInputElement) {

        let putTeam: Team = {
            Id: id,
            Name: txtTeamName.value
        };
        this.teamService.PutUpdate(putTeam).subscribe((response: Team) => {
            if (response) {
                //this.GetAll();                
                this.team = response;
                this.GetAll();
            }
        });
    }


    Remove(id: number) {
        this.teamService.Remove(id).subscribe(response => {
            this.GetAll();
        });
    }

    public CreateFixture(teamList) {
        this.fixtureService.PostAdd(teamList).subscribe((response: string) => {

            if (response) {
                this.fixtureService.GetSingle(1).subscribe((response: string) => this.shareService.fixtureList = JSON.parse(response));
                this.router.navigate(['/fixture'])
            }
        });
    }

}


interface Team {
    Id?: number;
    Name?: string;
}
interface Fixture {
    Id?: number;
    Home?: string;
    HomeId?: number;
    Away?: string;
    AwayId?: number;
    Week?: number;
    HomeScore?: number;
    AwayScore?: number;
    PointHome?: number;
    PointAway?: number;
    ScoreCheck?: boolean;
}
