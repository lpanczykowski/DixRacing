import { Round } from "./round";

 export interface EventWithActiveRounds {
      id: number;
      name: string;
      photo: string;
      rounds : Round[]

  }

  export interface Events {
      events: EventWithActiveRounds[];
  }

