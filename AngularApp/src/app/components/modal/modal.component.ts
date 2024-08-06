import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [CommonModule, TranslateModule],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent {
  @Output() onSubmit = new EventEmitter();
  @Output() closeModal = new EventEmitter();

  closeModalHandler() {
    this.closeModal.emit();
  }

  onSubmitHandler() {
    this.onSubmit.emit();
    this.closeModal.emit();
  }
}
