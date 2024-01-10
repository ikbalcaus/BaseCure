import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { myCofnig } from '../../myconfig';
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
  link = "";
  @Input() link1 = "";
  @Input() link2 = "";
  @Input() searchUrl = "";
  input = "";
  resultsList = "";
  @Output() searchOptions = new EventEmitter<Array<string>>();

  getAutoComplete(filter: number) {

    if(filter == 1) this.input="input1", this.link=this.link1, this.resultsList="results1";
    else this.input="input2", this.link=this.link2, this.resultsList="results2";

    if((<HTMLInputElement>document.getElementById(this.input)).value == "") document.getElementById(this.resultsList)!.innerText = "";
    if((<HTMLInputElement>document.getElementById(this.input)).value != "" && this.link != "") {
      this.httpClient.get<Array<string>>(myCofnig.backendAddress + this.link + (<HTMLInputElement>document.getElementById(this.input)).value).subscribe(
        res => {
          document.getElementById(this.resultsList)!.innerText = "";
          for(let i of res) {
            document.getElementById(this.resultsList)!.innerHTML += `
              <li class='list-group-item p-1' style="cursor: pointer"
                onmouseover="this.style.backgroundColor='#eee'"
                onmouseout="this.style.backgroundColor='#fff'"
                onclick="document.getElementById('${this.resultsList}').innerText=''; document.getElementById('${this.input}').value=this.innerText"
              >${i}</li>`;
          }
        }
      );
    }
  }

  searchSubmit() {
    this.searchOptions.emit([
      (<HTMLInputElement>document.getElementById("input1")).value,
      (<HTMLInputElement>document.getElementById("input2")).value
    ]);
  }
}
