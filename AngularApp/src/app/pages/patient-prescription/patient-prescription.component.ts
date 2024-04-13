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
  selectedPatient: number = 1; 
  selectedPatientName: string = ""; 
  medicines: any; 

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
    this.selectedPatient = patient.patientId;
    this.selectedPatientName = patient.patientName || '';
    this.medicines = patient.therapies || [];
  }
}
