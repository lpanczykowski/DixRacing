export interface EventResult {
  Position: number;
  DriverNumber: number;
  DriverName: string;
  DriverSurname: string;
  TeamName?: string;
  Car: number;
  RacePoints?: number[];
  PenaltyPoints: number;
  Points: number;
}
