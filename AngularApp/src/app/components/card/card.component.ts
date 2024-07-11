import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
    selector: 'app-card',
    standalone: true,
    imports: [CommonModule, RouterLink],
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
