export interface Korisnik {
  korisnikId: number;
  korisnickoIme?: string;
  hashLozinke?: string;
  ime?: string;
  prezime?: string;
  adresa?: string;
  datumRodjenja: Date;
  mailAdresa?: string;
  uloga?: string;
}
