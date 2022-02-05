import { Round } from "./round";

export interface EventsWithActiveRound {
    eventId: number;
    name: string;
    roundCounter: number;
    activeRound: Round;
    photo: string;
}
