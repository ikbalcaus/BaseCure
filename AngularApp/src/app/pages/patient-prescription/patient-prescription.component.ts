import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { backendSettings } from '../../backend-settings';

@Component({
  selector: 'app-patient-prescription',
  standalone: true,
  templateUrl: './patient-prescription.component.html',
  styleUrl: './patient-prescription.component.css',
  imports: [CommonModule, FormsModule]
})
export class PatientPrescriptionComponent {
  patients: any;
  selectedPatientName: string = ""; 
  medicines: any; 
  selectedPatient: any;
  selectedTherapy: any;

  constructor(private httpClient: HttpClient) {}

  ngOnInit() {
    // Fetch patients upon component initialization
    this.httpClient
      .get(backendSettings.address + '/uputnice')
      .subscribe((list) => {
        this.patients = list;

        if (this.patients.length > 0) {
          this.selectPatient(this.patients[0]);
        }
      });
  }

  selectPatient(patient: any) {
    this.selectedPatient = patient;
    this.selectedPatientName = patient.patientName || '';
    this.selectedTherapy = null;
  }

  selectTherapy(therapy: any) {
    this.selectedTherapy = therapy;
  }

  editTherapy() {
    if (!this.selectedTherapy || !this.selectedPatient) {
      return;
    }
    const therapyId = this.selectedTherapy.therapyId;
    const apiUrl = `${backendSettings.address}/uputnice/${this.selectedPatient.patientId}/terapije/${therapyId}`;
    this.httpClient.put(apiUrl, this.selectedTherapy).subscribe(() => {
      // Assuming therapy is updated successfully
      console.log('Therapy updated successfully.');
    });
  }

  deleteTherapy() {
    if (!this.selectedTherapy || !this.selectedPatient) {
      return;
    }
    const therapyId = this.selectedTherapy.therapyId;
    const apiUrl = `${backendSettings.address}/uputnice/${this.selectedPatient.patientId}/terapije/${therapyId}`;
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
