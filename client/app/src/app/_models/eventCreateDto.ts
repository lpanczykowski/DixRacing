import { Round } from "./round";

export class EventCreateDto{
  name: string;
  gameId:number;
  photo:string;
  rounds : RoundCreateDto[]
  constructor(
  ){this.rounds = []}
}

export class RoundCreateDto{
  trackId : number;
  roundDay : Date;
  serverName : string;
  serverPassowrd : string;
  races : RaceCreateDto[]
  constructor(){this.races = []}
}

export class RaceCreateDto{
  practiceDate : Date;
  praticeLength : number;
  qualiDate : Date;
  qualiLength : number;
  raceLength : number;
  raceDate : Date;
  constructor(){}
}
