import { Component } from '@angular/core';
import { FilterComponent } from '../../../components/filter/filter.component';
import { ItemListComponent } from "../../../components/item-list/item-list.component";
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-medical-institution-medicine',
    standalone: true,
    templateUrl: './medical-institution-medicine.component.html',
    styleUrl: './medical-institution-medicine.component.css',
    imports: [FilterComponent, ItemListComponent, CommonModule]
})
export class MedicalInstitutionMedicineComponent {
  medicines: any[] = []; // Define type according to your medicine model
  currentPage: number = 1;
  itemsPerPage: number = 5;

  //constructor(private medicineService: MedicineService) { }

  ngOnInit(): void {
    this.loadMedicines();
  }

  loadMedicines() {
    /*this.medicineService.getMedicines(this.currentPage, this.itemsPerPage)
      .subscribe((medicines: any[]) => {
        this.medicines = medicines;
      }); */
  }

  dummyDataFirstSection = [
    { name: 'Medicine 1', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '10KM' },
    { name: 'Medicine 2', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '15KM' },
    { name: 'Medicine 3', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '20KM' },
    { name: 'Medicine 4', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '25KM' },
    { name: 'Medicine 5', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '30KM' }
  ];

  dummyDataSecondSection = [
    { name: 'Medicine 6', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '10KM' },
    { name: 'Medicine 7', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '15KM' },
    { name: 'Medicine 8', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '20KM' },
    { name: 'Medicine 9', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '25KM' },
    { name: 'Medicine 10', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', price: '30KM' }
  ];

  dummyPaginationData = Array(9).fill(0).map((x, i) => i + 1);
  get totalPages() {
    return Array(Math.ceil(this.medicines.length / this.itemsPerPage)).fill(0).map((x, i) => i + 1);
  }
}
