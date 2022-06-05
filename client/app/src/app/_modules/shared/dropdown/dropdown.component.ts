import { Component, Input, OnInit, Output } from '@angular/core';
import { DropdownValue } from 'app/_models/dropdown';
import { DropdownService } from 'app/_services/dropdown.service';
import { EventEmitter } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.css']
})
export class DropdownComponent implements OnInit {
  @Input() endpoint: string;
  @Input() labelId: string;
  @Input() labelValue: string;
  @Output() selectedValueEmitter = new EventEmitter<Number>();

  values: SelectItem[];
  selectedValue: DropdownValue;

  constructor(private dropdownService: DropdownService) {
    this.values = [
      {label: 'New York', value: 'NY'},
      {label: 'Rome', value: 'RM'},
      {label: 'London', value: 'LDN'},
      {label: 'Istanbul', value: 'IST'},
      {label: 'Paris', value: 'PRS'}
  ];
   }

  ngOnInit() {
// this.loadData();
  }

  loadData() {
    this.dropdownService.get(this.endpoint).pipe(map((items:DropdownValue[])=>{
      return items.map((item)=>({
        label:item.value,
        value:item.id,
      }))
    })).subscribe(x=>this.values=x);
  }

  onChangeEmitter(){
    this.selectedValueEmitter.emit(this.selectedValue.id);
  }

}
