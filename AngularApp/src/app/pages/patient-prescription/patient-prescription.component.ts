import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { backendSettings } from '../../backend-settings';
import { Therapy, Uputnica } from '../../endpoints/uputnica';

@Component({
  selector: 'app-patient-prescription',
  standalone: true,
  templateUrl: './patient-prescription.component.html',
  styleUrl: './patient-prescription.component.css',
  imports: [CommonModule, FormsModule]
})
export class PatientPrescriptionComponent {
  patients: Uputnica[] = [];
  selectedPatient: number = 1; 
  selectedPatientName: string = ''; 
  medicines: Therapy[] = []; 

  constructor(private httpClient: HttpClient) {}

  ngOnInit() {
    // Fetch patients upon component initialization
    this.httpClient
      .get<Uputnica[]>(backendSettings.address + '/uputnice')
      .subscribe((list) => {
        this.patients = list;

        if (this.patients.length > 0) {
          this.selectPatient(this.patients[0]);
        }
      });
  }

  selectPatient(patient: Uputnica) {
    this.selectedPatient = patient.patientId;
    this.selectedPatientName = patient.patientName || '';
    this.medicines = patient.therapies || [];
  }
}
