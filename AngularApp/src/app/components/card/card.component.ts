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
    @Input() img: string = "";
    @Input() title: string = "";
    @Input() description: string = "";
    @Input() btn_text1: string = "";
    @Input() btn_link1: string = "";
    @Input() btn_text2: string = "";
    @Input() btn_link2: string = "";
}
