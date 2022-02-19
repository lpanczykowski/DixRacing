import { Participant } from "./participant";

export interface Driver {
    name :string,
    surname:string,
    nick:string,
    number: number;
    team: string;
    car: number;
}
