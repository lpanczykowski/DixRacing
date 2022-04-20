import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'time',
})
export class TimePipe implements PipeTransform {
  transform(value: number, ...args: unknown[]): string {
    let seconds = (value / 1000) % 60 | 0;
    let minutes = Math.floor((value / (1000 * 60)) % 60) | 0;
    let hours = Math.floor(value / (1000 * 60 * 60)) | 0;
    return hours + ':' + minutes + ':' + seconds.toFixed(3);
  }
}
