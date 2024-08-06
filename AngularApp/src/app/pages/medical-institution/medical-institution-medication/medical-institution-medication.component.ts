import { Component } from '@angular/core';
import { FilterComponent } from '../../../components/filter/filter.component';
import { ItemListComponent } from "../../../components/item-list/item-list.component";
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-medical-institution-medication',
    standalone: true,
    templateUrl: './medical-institution-medication.component.html',
    styleUrl: './medical-institution-medication.component.css',
    imports: [FilterComponent, ItemListComponent, CommonModule]
})
export class MedicalInstitutionMedicationComponent {
  medications: any[] = []; // Define type according to your medication model
  currentPage: number = 1;
  itemsPerPage: number = 5;

  //constructor(private medicationService: MedicationService) { }

  ngOnInit(): void {
    this.loadMedications();
  }

  loadMedications() {
    /*this.medicationService.getMedications(this.currentPage, this.itemsPerPage)
      .subscribe((medications: any[]) => {
        this.medications = medications;
      }); */
  }

  dummyDataFirstSection = [
    { name: 'Medication 1', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '10KM' },
    { name: 'Medication 2', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '15KM' },
    { name: 'Medication 3', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '20KM' },
    { name: 'Medication 4', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '25KM' },
    { name: 'Medication 5', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '30KM' }
  ];

  dummyDataSecondSection = [
    { name: 'Medication 6', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '10KM' },
    { name: 'Medication 7', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '15KM' },
    { name: 'Medication 8', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '20KM' },
    { name: 'Medication 9', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '25KM' },
    { name: 'Medication 10', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '30KM' }
  ];

  dummyPaginationData = Array(9).fill(0).map((x, i) => i + 1);
  get totalPages() {
    return Array(Math.ceil(this.medications.length / this.itemsPerPage)).fill(0).map((x, i) => i + 1);
  }
}
