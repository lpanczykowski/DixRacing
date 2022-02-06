import { Participant } from "./participant";

export interface Driver {
    participantDto: Participant;
    number: number;
    team: string;
    car: number;
}
