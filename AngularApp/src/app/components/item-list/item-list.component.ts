import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-item-list',
  standalone: true,
  imports: [TranslateModule],
  templateUrl: './item-list.component.html',
  styleUrl: './item-list.component.css'
})
export class ItemListComponent {
  @Input() img: any;
  @Input() name: any;
  @Input() description: any;
  @Input() price: any;
  @Input() btnText: any;
  @Output() btnClick = new EventEmitter();

  btnClickHandler() {
    this.btnClick.emit();
  }
}
