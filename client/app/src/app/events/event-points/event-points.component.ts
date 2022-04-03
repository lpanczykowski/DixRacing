import { EventListenerFocusTrapInertStrategy } from '@angular/cdk/a11y';
import { Component, OnInit } from '@angular/core';
import { EventRace } from '_models/eventRace';
import { EventResult } from '_models/eventResult';
import { RaceService } from '_services/race.service';

@Component({
  selector: 'app-event-points',
  templateUrl: './event-points.component.html',
  styleUrls: ['./event-points.component.css']
})

export class EventPointsComponent{

  editField: string;
  pointsList: Array<any> = [
    { id: 1, points: 100, place: 1 },
    { id: 2, points: 80, place: 2 },
    { id: 3, points: 60, place: 3 },
    { id: 4, points: 40, place: 4 },
    { id: 5, points: 20, place: 5 },
  ];


  Point: any =
    { id: 0, points: 0, place: 0 };

  updateList(id: number, property: string, event: any) {
    const editField = event.target.textContent;
    this.pointsList[id][property] = editField;
  }

  remove(id: any) {
    this.pointsList.splice(id, 1);
  }

  add() {
      const point = this.Point;
      this.pointsList.push(point);
  }

  changeValue(id: number, property: string, event: any) {
    this.editField = event.target.textContent;
  }

}
