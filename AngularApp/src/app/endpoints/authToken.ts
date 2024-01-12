import { Korisnik } from './korisnik';

export interface AuthToken {
  authTokenID: number;
  vrijednost: string;
  korisnik?: Korisnik;
  vrijemeEvidentiranja: Date;
  ipAdresa?: string;
  code2F: string;
  is2FOtkljucan: boolean;
}
