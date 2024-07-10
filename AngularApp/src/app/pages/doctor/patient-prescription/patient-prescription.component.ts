import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../../server-settings';
import { ParseDateTimePipe } from './parse-date-time';

@Component({
  selector: 'app-patient-prescription',
  templateUrl: './patient-prescription.component.html',
  styleUrl: './patient-prescription.component.css',
})
export class PatientPrescriptionComponent {
  patients: any;
  selectedPatientName: string = ""; 
  medicines: any; 
  selectedPatient: any;
  selectedTherapy: any;
  patientData: any;
  editMode: boolean = false;
  editedTherapy: any = {};

  toggleEditMode() {
    this.editMode = !this.editMode;
    if (this.editMode) {
      this.editedTherapy = { ...this.selectedTherapy }; 
    } else {
      this.editedTherapy = {};
    }
  }

  confirmEditTherapy() {
    this.editMode = false;

    this.httpClient.put(serverSettings.address + '/terapije/' + this.selectedTherapy.therapyId, this.editedTherapy).subscribe(() => {
      this.selectedTherapy = this.editedTherapy;
    });

    this.editedTherapy = {};
    this.toggleEditMode();
  }

  constructor(private httpClient: HttpClient) {}

  ngOnInit() {
    // Fetch patients upon component initialization
    this.httpClient
      .get(serverSettings.address + '/uputnice')
      .subscribe((list) => {
        this.patients = list;

        if (this.patients.length > 0) {
          // Select the first patient by default
          this.selectPatient(this.patients[0]);
        }
      });
  }

  selectPatient(patient: any) {
    this.selectedPatient = patient;
    this.selectedPatientName = patient.patientName || '';
    this.selectedTherapy = null;
    // Fetch patient data when a new patient is selected
    this.fetchPatientData();
  }

  fetchPatientData() {
    if (this.selectedPatient) {
      const apiUrl = `${serverSettings.address}/pacijenti?id=${this.selectedPatient.patientId}`;
      this.httpClient.get(apiUrl).subscribe((data) => {
        this.patientData = data;
      });
    }
  }

  selectTherapy(therapy: any) {
    this.selectedTherapy = therapy;
    this.editedTherapy = { ...therapy };
  }

  showPatientData(patient: any) {
    const apiUrl = `${serverSettings.address}/pacijenti?id=${this.selectedPatient.patientId}`;
    this.httpClient.get(apiUrl).subscribe((data) => {
      this.patientData = data;
      const modal = document.getElementById('patientDataModal');
      modal?.classList.add('show');
      modal?.setAttribute('style', 'display: block;');
      modal?.setAttribute('aria-modal', 'true');
    });
  }

  showModal() {
    const modal = document.getElementById('patientDataModal');
    modal?.classList.add('show');
    modal?.setAttribute('style', 'display: block;');
    modal?.setAttribute('aria-modal', 'true');
  }

  closeModal() {
    const modal = document.getElementById('patientDataModal');
    modal?.classList.remove('show');
    modal?.removeAttribute('style');
    modal?.removeAttribute('aria-modal');
  }

  editTherapy() {
    if (!this.selectedTherapy || !this.selectedPatient) {
      return;
    }
    const therapyId = this.selectedTherapy.therapyId;
    const apiUrl = `${serverSettings.address}/uputnice/?id=${therapyId}`;
    this.httpClient.put(apiUrl, this.selectedTherapy).subscribe(() => {
      console.log('Therapy updated successfully.');
    });
  }

  deleteTherapy() {
    if (!this.selectedTherapy || !this.selectedPatient) {
      return;
    }
    const therapyId = this.selectedTherapy.therapyId;
    const apiUrl = `${serverSettings.address}/?id=${therapyId}`;
    this.httpClient.delete(apiUrl).subscribe(() => {
      // Assuming therapy is deleted successfully
      console.log('Therapy deleted successfully.');
      if (this.selectedPatient && this.selectedPatient.therapies) {
        const index = this.selectedPatient.therapies.findIndex((t: any) => t.therapyId === therapyId);
        if (index !== -1) {
          this.selectedPatient.therapies.splice(index, 1);
        }
      }
      this.selectedTherapy = null;
    });
  }

}

@NgModule({
  declarations: [
    PatientPrescriptionComponent,
    ParseDateTimePipe // Declare the pipe here
  ],
  imports: [CommonModule, FormsModule],
  providers: [],
})
export class PatientPrescriptionComponentModule { }