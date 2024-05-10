import { Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { UserSearchComponent } from './pages/user/user-search/user-search.component';
import { UserCartComponent } from './pages/user/user-cart/user-cart.component';
import { UserAboutComponent } from './pages/user/user-about/user-about.component';
import { UserInfoComponent } from './pages/user/user-info/user-info.component';
import { AdminLoginComponent } from './pages/admin/admin-login/admin-login.component';
import { AdminDashboardComponent } from './pages/admin/admin-dashboard/admin-dashboard.component';
import { MedicalInstitutionCartonComponent } from './pages/medical-institution/medical-institution-carton/medical-institution-carton.component';
import { UserMedicinesComponent } from './pages/user/user-medicines/user-medicines.component';
import { GuardService } from './services/guard.service';
import { RedirectService } from './services/redirect.service';
import { PharmacyManageMedicinesComponent } from './pages/pharmacy/pharmacy-manage-medicines/pharmacy-manage-medicines.component';
import { PharmacyAddMedicineComponent } from './pages/pharmacy/pharmacy-add-medicine/pharmacy-add-medicine.component';
import { PharmacyEditMedicineComponent } from './pages/pharmacy/pharmacy-edit-medicine/pharmacy-edit-medicine.component';
import { PatientPrescriptionComponent } from './pages/patient-prescription/patient-prescription.component';
import { PharmacyOrdersComponent } from './pages/pharmacy/pharmacy-orders/pharmacy-orders.component';
import { PharmacyOrdersDetailsComponent } from './pages/pharmacy/pharmacy-orders-details/pharmacy-orders-details.component';

export const routes: Routes = [
    { path: "", component: LandingPageComponent, canActivate: [RedirectService] },
    { path: "pretrazi", component: UserSearchComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "pretrazi/:id", component: UserAboutComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "lijekovi/:id", component: UserMedicinesComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "korpa", component: UserCartComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "korisnik-info", component: UserInfoComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "ustanova-zdravstva/karton", component: MedicalInstitutionCartonComponent, canActivate: [GuardService], data: { role: "ustanova-zdravstva" } },
    { path: "apoteka/lijekovi", component: PharmacyManageMedicinesComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "apoteka/dodaj", component: PharmacyAddMedicineComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "apoteka/uredi/:id", component: PharmacyEditMedicineComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "apoteka/narudzbe", component: PharmacyOrdersComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "apoteka/narudzbe/:korisnikId/:status", component: PharmacyOrdersDetailsComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "ljekar/uputnice", component: PatientPrescriptionComponent, canActivate: [GuardService], data: { role: "ljekar" }},
    { path: "basecure-admin", component: AdminLoginComponent, canActivate: [RedirectService] },
    { path: "basecure-admin/dashboard", component: AdminDashboardComponent, canActivate: [GuardService], data: { role: "admin" } }
];
