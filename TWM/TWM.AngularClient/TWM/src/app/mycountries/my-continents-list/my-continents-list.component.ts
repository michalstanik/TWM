
import { Component, OnInit } from '@angular/core';

//Services
import { MyCountryService } from '../shared/services/mycountry.service';

//Models
import { ContinentWithRegionsAndCountriesModel } from 'src/app/shared/models/country/continent-with-regions-and-countries.model';

@Component({
  selector: 'app-my-continent-list',
  templateUrl: './my-continent-list.component.html',
  styleUrls: ['./my-continent-list.component.scss']
})
export class MyContinentListComponent implements OnInit {

  myCountries: ContinentWithRegionsAndCountriesModel[];

  constructor(private myCountryService: MyCountryService) { }

  ngOnInit() {
    this.myCountryService.GetCountriesForUserByContinent().subscribe(myCountries => { this.myCountries = myCountries });
    
  }

  

}
