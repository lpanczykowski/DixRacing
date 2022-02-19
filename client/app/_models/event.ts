import { Round } from "./round";


interface Event {
  id: number;
  name: string;
  rounds: Round[]
}
export interface EventDto {
  event: Event;
}
