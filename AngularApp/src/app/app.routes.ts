import { Routes } from '@angular/router';
import { IndexPageComponent } from './pages/index-page/index-page.component';
import { UserSearchComponent } from './pages/user/user-search-medical-institucions/user-search-medical-institucions.component';
import { UserCartComponent } from './pages/user/user-cart/user-cart.component';
import { UserAboutMedicalInstitutionComponent } from './pages/user/user-about-medical-institucion/user-about-medical-institucion.component';
import { UserDataComponent } from './pages/user/user-data/user-data.component';
import { AdminLoginComponent } from './pages/admin/admin-login/admin-login.component';
import { AdminDashboardComponent } from './pages/admin/admin-dashboard/admin-dashboard.component';
import { MedicalInstitutionCartonComponent } from './pages/medical-institution/medical-institution-carton/medical-institution-carton.component';
import { UserMedicinesComponent } from './pages/user/user-medicines/user-medicines.component';
import { GuardService } from './services/guard.service';
import { RedirectService } from './services/redirect.service';
import { PharmacyManageMedicinesComponent } from './pages/pharmacy/pharmacy-manage-medicines/pharmacy-manage-medicines.component';
import { PharmacyAddMedicineComponent } from './pages/pharmacy/pharmacy-add-medicine/pharmacy-add-medicine.component';
import { PharmacyEditMedicineComponent } from './pages/pharmacy/pharmacy-edit-medicine/pharmacy-edit-medicine.component';
import { PatientPrescriptionComponent } from './pages/doctor/patient-prescription/patient-prescription.component';
import { PharmacyOrdersComponent } from './pages/pharmacy/pharmacy-orders/pharmacy-orders.component';
import { PharmacyOrdersDetailsComponent } from './pages/pharmacy/pharmacy-orders-details/pharmacy-orders-details.component';
import { UserAboutDoctorComponent } from './pages/user/user-about-doctor/user-about-doctor.component';
import { UserDoctorsComponent } from './pages/user/user-search-doctors/user-search-doctors.component';
import { UserChatComponent } from './pages/user/user-chat/user-chat.component';
import { PharmacyDataComponent } from './pages/pharmacy/pharmacy-data/pharmacy-data.component';
import { SetMapComponent } from './components/set-map/set-map.component';

export const routes: Routes = [
    { path: "", component: IndexPageComponent, canActivate: [RedirectService] },
    { path: "pretrazi", component: UserSearchComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "pretrazi/:id", component: UserAboutMedicalInstitutionComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "pretrazi/lijekovi/:id", component: UserMedicinesComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "pretrazi/ljekari/:id", component: UserDoctorsComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "ljekar/:id", component: UserAboutDoctorComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "korpa", component: UserCartComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "kontakt/:id", component: UserChatComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "podaci", component: UserDataComponent, canActivate: [GuardService], data: { role: "korisnik" } },
    { path: "ustanova-zdravstva/karton", component: MedicalInstitutionCartonComponent, canActivate: [GuardService], data: { role: "ustanova-zdravstva" } },
    { path: "apoteka/lijekovi", component: PharmacyManageMedicinesComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "apoteka/dodaj", component: PharmacyAddMedicineComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "apoteka/uredi/:id", component: PharmacyEditMedicineComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "apoteka/narudzbe", component: PharmacyOrdersComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "apoteka/narudzbe/:redniBroj/:status", component: PharmacyOrdersDetailsComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "apoteka/podaci", component: PharmacyDataComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "apoteka/lokacija", component: SetMapComponent, canActivate: [GuardService], data: { role: "apoteka" } },
    { path: "ustanova-zdravstva/lokacija", component: SetMapComponent, canActivate: [GuardService], data: { role: "ustanova-zdravstva" } },
    { path: "ljekar/uputnice", component: PatientPrescriptionComponent, canActivate: [GuardService], data: { role: "ljekar" } },
    { path: "basecure-admin", component: AdminLoginComponent, canActivate: [RedirectService] },
    { path: "basecure-admin/dashboard", component: AdminDashboardComponent, canActivate: [GuardService], data: { role: "admin" } }
];
