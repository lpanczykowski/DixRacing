export interface Team {
  teamId :number,
  teamName:string,
  teamMembers:TeamMember[],
  teamCar: number,
  teamPoints:number
}

export interface EventTeamsWithDrivers{
  eventTeamsWithDrivers: Team[],
}

export interface TeamMember{
  summedPoints:number;
  userName: string;
  userSurname: string;
}
