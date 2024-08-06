import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

@Component({
    selector: 'app-card',
    standalone: true,
    imports: [RouterLink, TranslateModule],
    templateUrl: './card.component.html',
    styleUrl: './card.component.css'
})
export class CardComponent {
    @Input() img: any;
    @Input() title: any;
    @Input() description: any;
    @Input() btn_text1: any;
    @Input() btn_link1: any;
    @Input() btn_text2: any;
    @Input() btn_link2: any;
}
