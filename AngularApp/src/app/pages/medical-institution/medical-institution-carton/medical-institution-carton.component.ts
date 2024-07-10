import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-medical-institution-carton',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './medical-institution-carton.component.html',
  styleUrl: './medical-institution-carton.component.css'
})
export class MedicalInstitutionCartonComponent {
  appointments = [
    { name: 'Pacijent 1', date: '01.01.2023 9:00h' },
    { name: 'Pacijent 2', date: '15.01.2023 10:30h' },
    { name: 'Pacijent 3', date: '30.01.2023 14:00h' },
    { name: 'Pacijent 4', date: '05.02.2023 8:30h' },
    { name: 'Pacijent 5', date: '20.02.2023 11:00h' },
  ];

  patientRecords = [
    {
      year: 2023,
      details: [
        '1.1.2023 - Pregled',
        '15.3.2023 - Konsultacija',
        '20.5.2023 - Kontrola',
      ]
    },
    {
      year: 2022,
      details: [
        '10.2.2022 - Pregled',
        '25.5.2022 - Kontrola',
        '30.9.2022 - Hitna posjeta',
      ]
    },
    {
      year: 2021,
      details: [
        '5.1.2021 - Prva posjeta',
        '12.4.2021 - Redovni pregled',
        '22.12.2021 - Godišnja revizija',
      ]
    }
  ];
}
