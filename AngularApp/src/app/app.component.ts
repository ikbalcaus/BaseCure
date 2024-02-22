import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from "./components/navbar/navbar.component";
import { trigger, query, style, transition, animate } from '@angular/animations';
import { AlertService } from './services/alert.service';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [CommonModule, RouterOutlet, NavbarComponent],
  animations: [
    trigger("routerTransition", [
      transition("* <=> *", [
        query(":enter", [
          style({ opacity: 0 })
        ], { optional: true } ),
        query(":leave", [
          animate(50, style({ opacity: 1 }))
        ], { optional: true } )
      ])
    ])
  ]
})
export class AppComponent {
  constructor(private alertService: AlertService) {}

  protected alert = this.alertService.alert;
    
  prepareRoute(outlet: RouterOutlet) {
    return outlet;
  }
}
