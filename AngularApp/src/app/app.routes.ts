import { Routes } from '@angular/router';
import { LandingComponent } from './pages/landing/landing.component';
import { SearchComponent } from './pages/search/search.component';
import { CartComponent } from './pages/cart/cart.component';
import { AboutComponent } from './pages/about/about.component';

export const routes: Routes = [
    { path: "", component: LandingComponent },
    { path: "apoteke", component: SearchComponent },
    { path: "bolnice-ambulante", component: SearchComponent },
    { path: "poliklinike-ordinacije", component: SearchComponent },
    { path: "korpa", component: CartComponent },
    { path: "detalji", component: AboutComponent }
];
