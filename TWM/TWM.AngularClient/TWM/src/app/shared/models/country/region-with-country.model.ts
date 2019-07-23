import { TripCountry } from './trip-country.model';

export class RegionWithCountryModel {
  id: number
  countries: TripCountry[]
  visitedCountryCount: number
  statsCountryCount: number
}
