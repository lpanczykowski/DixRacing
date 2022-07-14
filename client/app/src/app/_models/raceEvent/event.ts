import { Round } from "../round";


interface Event {
  id: number;
  name: string;
  rules:string;
  rounds: Round[]
}
export interface EventDto {
  event: Event;
}
