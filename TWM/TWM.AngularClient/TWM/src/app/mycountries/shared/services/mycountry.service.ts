import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { Subject, Observable, of } from 'rxjs';

import { catchError } from 'rxjs/operators';
import { TripCountry } from 'src/app/shared/models/country/trip-country.model';
import { TripCountryWithAssessment } from 'src/app/shared/models/country/trip-country-with-assessment.model';
import { BaseService } from 'src/app/shared/services/base.service';


@Injectable()
export class MyCountryService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  getCountriesForTrip(id: number): Observable<TripCountry> {
    return this.http.get<TripCountry>(`${this.apiUrl}/geo/GetCountriesForTrip/' + id`)
      .pipe(catchError(this.handleError<TripCountry>('getCountriesForTrip')))
  }

  GetCountriesForAllTrips(): Observable<TripCountry[]> {
    return this.http.get<TripCountry[]>(`${this.apiUrl}/geo/GetCountriesForAllTrips/`)
      .pipe(catchError(this.handleError<TripCountry[]>('GetCountriesForAllTrips')))
  }

  GetCountriesForAllTripsWithAssessment(): Observable<TripCountryWithAssessment[]> {
    return this.http.get<TripCountryWithAssessment[]>(`${this.apiUrl}/geo/GetCountriesForAllTripsWithAssessments/`)
      .pipe(catchError(this.handleError<TripCountryWithAssessment[]>('GetCountriesForAllTripsWithAssessment')))
  }

  GetCountriesForUserWithAssessments(): Observable<TripCountryWithAssessment[]> {
    return this.http.get<TripCountryWithAssessment[]>(`${this.apiUrl}/geo/GetCountriesForUserWithAssessments/`)
      .pipe(catchError(this.handleError<TripCountryWithAssessment[]>('GetCountriesForUserWithAssessments')))
  }


  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    }
  }

}
