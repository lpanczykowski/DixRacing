export interface RaceIncidentById {
  id: number;
  raceId: number;
  reportedUserId: number;
  userId: number;
  description?: string;
  isSolved:number;
  time: number;
  lap:number;
  pointPenalty:number;
  timePenalty:number;
  penalty?:string;
}
export interface RoundIncidents{
  roundIncidents:RaceIncidents[];
}
export interface RaceIncidents{
  roundId:number;
  raceIncidents:RaceIncidentById[];
}
