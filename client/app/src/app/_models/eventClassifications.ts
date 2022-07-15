export interface EventClassifications{
  eventClassifications:EventParticipantClassification[];
}
export interface EventParticipantClassification {
  eventId: number;
  number: number;
  name: string;
  surname: string;
  teamName?: string;
  car:number;
  roundsPoints: RoundsPoints[];
  summedPoints: number;
  pointPenalty: number;
  points:number;
}

export interface RoundsPoints{
  roundId:number;
  racePoints:RacePoints[];
}

export interface RacePoints{
  raceId:number;
  position:number;
  points:number;
}

