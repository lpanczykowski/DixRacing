import { Round } from "./round";

export interface RaceEvent {
    eventId: number;
    name: string;
    gameId: number;
 //   game: Games;
    rounds: Round[];
    photo: string;
}
