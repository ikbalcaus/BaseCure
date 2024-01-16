import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { myCofnig } from '../../../myconfig';
import { ZdravstveniKarton } from '../../../endpoints/zdravstveniKartoni';
import { CommonModule } from '@angular/common';
import { FormsModule} from '@angular/forms';

@Component({
  selector: 'app-medical-institution-carton',
  standalone: true,
  templateUrl: './medical-institution-carton.component.html',
  styleUrl: './medical-institution-carton.component.css',
  imports: [CommonModule,FormsModule]
})
export class MedicalInstitutionCartonComponent implements OnInit{
  editIndex: number | null = null;
  records: Array<ZdravstveniKarton> = [];

  constructor(private httpClient: HttpClient) {}

  ngOnInit() {
    this.loadMedicalRecords();
  }

  req: ZdravstveniKarton = {
    kartonId: 0, 
    sadrzaj: "", 
    korisnik: { ime: "" },
    pacijentId: "", 
    pregledId: "",
    datumIzdavanja: new Date() // Assign a valid Date value here
  };

   private loadMedicalRecords(){
    this.httpClient.get<any>(myCofnig.backendAddress + "/medicalRecords").subscribe({
      next: (res: any) => {
        console.log(res);
        console.log(res.kartoni);
        console.log(res.kartoni[0].korisnik.ime);
        this.records = res.kartoni as Array<ZdravstveniKarton>;
      },
      error: err => {
        console.log(err);
      }
    });
  }
  
  onSubmit() {
    this.httpClient.post<any>(myCofnig.backendAddress + '/medicalRecords', this.req).subscribe({
      next: (res) => {
        console.log(res);
        // After successful POST, reload the medical records
        this.loadMedicalRecords();
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  deleteRecord(index: number) {
    const recordId = this.records[index].kartonId; // Assuming the record has an 'id' property
    console.log(recordId);
    

    // Perform your HTTP DELETE request here using the recordId or appropriate identifier
    this.httpClient.delete<any>(myCofnig.backendAddress + '/medicalRecords/' + recordId).subscribe({
      next: (res) => {
        console.log(res);
        // Remove the record from the local array
        this.records.splice(index, 1);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
