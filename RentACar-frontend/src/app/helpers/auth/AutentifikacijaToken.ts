import {KorisnickiNalog} from "./KorisnickiNalog";


export interface AutentifikacijaToken {
  id: number
  vrijednost: string
  korisnickiNalogId: number
  korisnickiNalog: KorisnickiNalog
  vrijemeEvidentiranja: string
  ipAdresa: string
}
