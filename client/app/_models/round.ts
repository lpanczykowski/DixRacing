
import { RaceEvent } from "./event";

export interface Round {
    roundId: number;
    eventId: number;
    serverName: string;
    serverPassword: string;
    trackId: number;
    roundDay: Date;
}
