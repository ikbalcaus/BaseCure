interface Korisnik {
  ime: string;
  // other properties...
}


export interface ZdravstveniKarton {
    kartonId: number;
    datumIzdavanja: Date;
    sadrzaj?: string;
    korisnik: Korisnik;
    pacijentId?: string;
    pregledId?: string;
  }