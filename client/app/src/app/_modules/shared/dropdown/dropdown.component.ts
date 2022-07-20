import { Component, Input, OnInit, Output } from '@angular/core';
import { DropdownValue } from 'app/_models/dropdown';
import { DropdownService } from 'app/_services/dropdown.service';
import { EventEmitter } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { map } from 'rxjs/operators';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.css']
})
export class DropdownComponent implements OnInit {
  @Input() endpoint: string;
  @Input() queryParams: HttpParams;
  @Input() labelId: string;
  @Input() labelValue: string;
  @Output() selectedValueEmitter = new EventEmitter<Number>();

  values: SelectItem[];
  selectedValue:SelectItem;

  constructor(private dropdownService: DropdownService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.dropdownService.get(this.endpoint,this.queryParams).subscribe(data=>{
      this.values = data.dropdownValues.map(res=> {return {value:res.id,label:res.value}})});
  }

  onChangeEmitter() {
    this.selectedValueEmitter.emit(this.selectedValue.value);
  }

}
