import { Component, Input, OnInit, Output } from '@angular/core';
import { DropdownValue } from 'app/_models/dropdown';
import { DropdownService } from 'app/_services/dropdown.service';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.css']
})
export class DropdownComponent implements OnInit {
  @Input() endpoint: string;
  @Output() selected : DropdownValue
  values: DropdownValue[];
  constructor(private dropdownService: DropdownService) { }

  ngOnInit() {
    this.dropdownService.get(this.endpoint).subscribe(x => this.values = x);
  }

}
