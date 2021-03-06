import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'time',
})
export class TimePipe implements PipeTransform {
  transform(value: number, ...args: unknown[]): string {
    let seconds = (value / 1000) % 60 ?? 0;
    let minutes = Math.floor((value / (1000 * 60)) % 60) ?? 0;
    let hours = Math.floor(value / (1000 * 60 * 60)) ?? 0;
    let result = '';
    if (hours > 0) result = hours + ':';
    if (minutes > 0 || hours > 0) result += minutes + ':';
    return result + seconds.toFixed(3);
  }
}
