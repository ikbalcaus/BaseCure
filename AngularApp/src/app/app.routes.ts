import { Routes } from '@angular/router';
import { LandingComponent } from './pages/landing/landing.component';
import { SearchComponent } from './pages/search/search.component';
import { CartComponent } from './pages/cart/cart.component';
import { AboutComponent } from './pages/about/about.component';
import { UserInfoComponent } from './pages/user-info/user-info.component';

export const routes: Routes = [
    { path: "", component: LandingComponent },
    { path: "pretrazi", component: SearchComponent },
    { path: "korpa", component: CartComponent },
    { path: "korisnik-info", component: UserInfoComponent },
    { path: "detalji", component: AboutComponent }
];
