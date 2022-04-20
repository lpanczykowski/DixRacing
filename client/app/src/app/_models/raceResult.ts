import { Lap } from './Lap';
import { Position } from './position';

export interface RaceResult {
  name: string;
  surname: string;
  nick: string;
  userId: number;
  teamName: string;
  carNumber: number;
  car : string;
  raceId: number;
  position: Position;
  bestLap: Lap;
  time: number;
  gap: number;
  laps: Lap[];
}
