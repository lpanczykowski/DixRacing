export interface EventResult {
  position: number;
  driverNumber: number;
  driverName: string;
  driverSurname: string;
  teamName?: string;
  car: number;
  carNumber: number;
  racePoints?: number[];
  penaltyPoints: number;
  points: number;
}
