import { PositionPoints } from './../../interfaces/positionPoints';
import { EventListenerFocusTrapInertStrategy } from '@angular/cdk/a11y';
import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-event-points',
  templateUrl: './event-points.component.html',
  styleUrls: ['./event-points.component.css'],
})
export class EventPointsComponent implements OnInit {
  ngOnInit(): void {}
  isAdmin: boolean
  editField: string;
  points: Array<PositionPoints> = [
    { id: 1, points: 100, position: 1, raceId: 1 },
    { id: 2, points: 80, position: 2, raceId: 1 },
    { id: 3, points: 60, position: 3, raceId: 1 },
    { id: 4, points: 40, position: 4, raceId: 1 },
    { id: 5, points: 20, position: 5, raceId: 1 },
  ];
  editDialog: boolean = false;
  submitted: boolean = false;
  item: PositionPoints;

  items: MenuItem[];

  Point: any = { id: 0, points: 0, place: 0 };

  changeValue(id: number, property: string, event: any) {
    this.editField = event.target.textContent;
  }
  edit(positionPoints: PositionPoints) {
    this.item = positionPoints;
    this.editDialog = true;
  }
  remove(positionPoints: PositionPoints) {
    this.points.splice(this.points.indexOf(positionPoints), 1);
    console.log(this.points);
  }
  add() {
    this.item = {
      id: 0,
      points: 0,
      position:
        this.points.reduce(
          (op, item) => (op = op > item.position ? op : item.position),
          0
        ) + 1,
      raceId: 1,
    };
    console.log(this.item);
    this.editDialog = true;
  }
  cancel() {
    this.editDialog = false;
    this.submitted = false;
  }

  save() {
    this.submitted = true;
    this.points.push(this.item);
  }
}
