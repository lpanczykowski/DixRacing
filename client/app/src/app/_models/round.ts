import { Track } from "./track";

  export interface Round {
    id: number;
    track: Track;
    serverName: string;
    serverPassword: string;
    roundNumber: number;
    isActive: boolean;
    roundDay: Date;
}
