import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'parseDateTime' })

export class ParseDateTimePipe implements PipeTransform {
  transform(value: string): string {
    if (value) {
        return value.split('T')[0];
    }
    return '';
  }
}