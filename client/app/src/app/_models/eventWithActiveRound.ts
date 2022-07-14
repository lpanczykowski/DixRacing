 export interface EventWithActiveRound {
      eventId: number;
      name: string;
      amountOfRounds: number;
      roundDay: Date;
      roundId: number;
      photo: string;
  }

  export interface Events {
      events: EventWithActiveRound[];
  }

