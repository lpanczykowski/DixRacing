export class RaceIncidentDto {
  userId: number;
  reportedUserId: number;
  lap: number;
  time: string;
  description: string;
  isSolved: boolean;
  raceId: number;
  id:number;
  constructor() {}
}
