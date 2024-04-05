import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { backendSettings } from '../../backend-settings';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-filter',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './filter.component.html',
  styleUrl: './filter.component.css'
})
export class FilterComponent {
  constructor(private httpClient: HttpClient) {}

  @Input() placeholder1 = "";
  @Input() placeholder2 = "";
  @Input() link1 = "";
  @Input() link2 = "";
  @Input() searchUrl = "";
  @Output() searchOptions = new EventEmitter<any>();
  inputValue1: string = "";
  inputValue2: string = "";
  filteredList1: Array<string> = [];
  filteredList2: Array<string> = [];

  getAutoComplete1() {
    if(!this.inputValue1) this.filteredList1 = [];
    this.httpClient.get<Array<string>>(backendSettings.address + this.link1 + (this.inputValue1)).subscribe(
      res => { this.filteredList1 = res }
    );
  }

  getAutoComplete2() {
    if(!this.inputValue2) this.filteredList2 = [];
    this.httpClient.get<Array<string>>(backendSettings.address + this.link2 + (this.inputValue2)).subscribe(
      res => { this.filteredList2 = res }
    );
  }

  setValue1(value: string) {
    this.inputValue1 = value;
    this.filteredList1 = [];
  }

  setValue2(value: string) {
    this.inputValue2 = value;
    this.filteredList2 = [];
  }

  searchSubmit() {
    this.searchOptions.emit([this.inputValue1, this.inputValue2]);
  }
}
