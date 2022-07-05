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
  selectedValue: DropdownValue;

  constructor(private dropdownService: DropdownService) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    console.log("i don't know")
    this.dropdownService.get(this.endpoint,this.queryParams).pipe(map((items:DropdownValue[])=>{
      items.map((item)=>
        console.log(item)
      )
    })).subscribe(x=>console.log(x));
  }

  onChangeEmitter(){
    this.selectedValueEmitter.emit(this.selectedValue.id);
  }

}
