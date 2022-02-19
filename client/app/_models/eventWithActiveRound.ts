 export interface EventWithActiveRound {
      eventId: number;
      eventName: string;
      amountOfRounds: number;
      roundDay: Date;
      roundId: number;
      photo: string;
  }

  export interface Events {
      events: EventWithActiveRound[];
  }

