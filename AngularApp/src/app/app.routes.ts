import { Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { UserSearchComponent } from './pages/user/user-search/user-search.component';
import { UserCartComponent } from './pages/user/user-cart/user-cart.component';
import { UserAboutComponent } from './pages/user/user-about/user-about.component';
import { UserInfoComponent } from './pages/user/user-info/user-info.component';
import { AdminLoginComponent } from './pages/admin/admin-login/admin-login.component';
import { AdminDashboardComponent } from './pages/admin/admin-dashboard/admin-dashboard.component';

export const routes: Routes = [
    { path: "", component: LandingPageComponent },
    { path: "pretrazi", component: UserSearchComponent },
    { path: "pretrazi/:id", component: UserAboutComponent },
    { path: "korpa", component: UserCartComponent },
    { path: "korisnik-info", component: UserInfoComponent },
    { path: "basecure-admin", component: AdminLoginComponent },
    { path: "basecure-admin/dashboard", component: AdminDashboardComponent },
];
