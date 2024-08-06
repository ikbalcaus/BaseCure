import { Routes } from '@angular/router';
import { IndexPageComponent } from './pages/index-page/index-page.component';
import { UserCartComponent } from './pages/user/user-cart/user-cart.component';
import { UserDataComponent } from './pages/user/user-data/user-data.component';
import { AdminLoginComponent } from './pages/admin/admin-login/admin-login.component';
import { AdminDashboardComponent } from './pages/admin/admin-dashboard/admin-dashboard.component';
import { MedicalInstitutionCartonComponent } from './pages/medical-institution/medical-institution-carton/medical-institution-carton.component';
import { UserSearchMedicationsComponent } from './pages/user/user-search-medications/user-search-medications.component';
import { GuardService } from './services/guard.service';
import { RedirectService } from './services/redirect.service';
import { PharmacyManageMedicationsComponent } from './pages/pharmacy/pharmacy-manage-medications/pharmacy-manage-medications.component';
import { PharmacyAddMedicationComponent } from './pages/pharmacy/pharmacy-add-medication/pharmacy-add-medication.component';
import { PharmacyEditMedicationComponent } from './pages/pharmacy/pharmacy-edit-medication/pharmacy-edit-medication.component';
import { PatientPrescriptionComponent } from './pages/doctor/patient-prescription/patient-prescription.component';
import { PharmacyOrdersComponent } from './pages/pharmacy/pharmacy-orders/pharmacy-orders.component';
import { PharmacyOrdersDetailsComponent } from './pages/pharmacy/pharmacy-orders-details/pharmacy-orders-details.component';
import { UserAboutDoctorComponent } from './pages/user/user-about-doctor/user-about-doctor.component';
import { UserSearchDoctorsComponent } from './pages/user/user-search-doctors/user-search-doctors.component';
import { UserChatComponent } from './pages/user/user-chat/user-chat.component';
import { SetMapComponent } from './components/set-map/set-map.component';
import { EditMedicalInstitutionComponent } from './components/edit-medical-institution/edit-medical-institution.component';
import { UserSearchMedicalInstitutionComponent } from './pages/user/user-search-medical-institutions/user-search-medical-institutions.component';
import { UserAboutMedicalInstitutionComponent } from './pages/user/user-about-medical-institution/user-about-medical-institution.component';

export const routes: Routes = [
    { path: "", component: IndexPageComponent, canActivate: [RedirectService] },
    { path: "pretrazi", component: UserSearchMedicalInstitutionComponent, canActivate: [GuardService], data: { roles: ["korisnik", "ljekar"] } },
    { path: "pretrazi/:id", component: UserAboutMedicalInstitutionComponent, canActivate: [GuardService], data: { roles: ["korisnik", "ljekar"] } },
    { path: "pretrazi/lijekovi/:id", component: UserSearchMedicationsComponent, canActivate: [GuardService], data: { roles: ["korisnik", "ljekar"] } },
    { path: "pretrazi/ljekari/:id", component: UserSearchDoctorsComponent, canActivate: [GuardService], data: { roles: ["korisnik", "ljekar"] } },
    { path: "ljekar/:id", component: UserAboutDoctorComponent, canActivate: [GuardService], data: { roles: ["korisnik", "ljekar"] } },
    { path: "korpa", component: UserCartComponent, canActivate: [GuardService], data: { roles: ["korisnik", "ljekar"] } },
    { path: "kontakt/:id", component: UserChatComponent, canActivate: [GuardService], data: { roles: ["korisnik", "ljekar"] } },
    { path: "podaci", component: UserDataComponent, canActivate: [GuardService], data: { roles: ["korisnik", "ljekar"] } },
    { path: "apoteka/lijekovi", component: PharmacyManageMedicationsComponent, canActivate: [GuardService], data: { roles: ["apoteka"] } },
    { path: "apoteka/dodaj", component: PharmacyAddMedicationComponent, canActivate: [GuardService], data: { roles: ["apoteka"] } },
    { path: "apoteka/uredi/:id", component: PharmacyEditMedicationComponent, canActivate: [GuardService], data: { roles: ["apoteka"] } },
    { path: "apoteka/narudzbe", component: PharmacyOrdersComponent, canActivate: [GuardService], data: { roles: ["apoteka"] } },
    { path: "apoteka/narudzbe/:redniBroj/:status", component: PharmacyOrdersDetailsComponent, canActivate: [GuardService], data: { roles: ["apoteka"] } },
    { path: "ustanova-zdravstva/podaci", component: EditMedicalInstitutionComponent, canActivate: [GuardService], data: { roles: ["bolnica", "apoteka"] } },
    { path: "ustanova-zdravstva/lokacija", component: SetMapComponent, canActivate: [GuardService], data: { roles: ["bolnica", "apoteka"] } },
    { path: "ustanova-zdravstva/karton", component: MedicalInstitutionCartonComponent, canActivate: [GuardService], data: { roles: "bolnica" } },
    { path: "ljekar/uputnice", component: PatientPrescriptionComponent, canActivate: [GuardService], data: { roles: "ljekar" } },
    { path: "basecure-admin", component: AdminLoginComponent, canActivate: [RedirectService] },
    { path: "basecure-admin/dashboard", component: AdminDashboardComponent, canActivate: [GuardService], data: { roles: "admin" } }
];
