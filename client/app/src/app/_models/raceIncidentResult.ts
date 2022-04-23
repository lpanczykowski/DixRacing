export interface RaceIncidentResult {
  incidentId: number;
  reportingDriver: number;
  reportedDriver: number;
  incidentLap: number;
  incidentTime: string;
  incidentDescription:string;
  result: string;
  solved:boolean;
}
