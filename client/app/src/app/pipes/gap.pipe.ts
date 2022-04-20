import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'gap',
})
export class GapPipe implements PipeTransform {
  transform(value: number, lapDiff?: number): string {
    if (lapDiff > 0) return '+' + lapDiff + ' okr.';
    let seconds = (value / 1000) % 60 ?? 0;
    let minutes = Math.floor((value / (1000 * 60)) % 60) ?? 0;
    let hours = Math.floor(value / (1000 * 60 * 60)) ?? 0;
    let result = '';
    if (hours > 0) result = hours + ':';
    if (minutes > 0) result = result + minutes + ':';
    return '+'+result + seconds.toFixed(3);
  }
}
