import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any[], filterString:string, propertyName:string): any[] {

    const resultArray = [];

    if(value.length == 0 || filterString == '' || propertyName == '' || filterString == null || filterString == undefined){
      return value
    }
    for (const item of value) {
      if (item[propertyName] === filterString) {
        resultArray.push(item);
      }
    }
    return resultArray;
  }

}
