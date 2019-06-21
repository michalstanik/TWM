import { Component, OnInit, Input } from '@angular/core';
import { TripCountryWithAssessment } from 'src/app/shared/models/country/trip-country-with-assessment.model';

@Component({
  selector: 'app-my-country-thumbnail',
  templateUrl: './my-country-thumbnail.component.html',
  styleUrls: ['./my-country-thumbnail.component.scss']
})
export class MyCountryThumbnailComponent implements OnInit {
    @Input() country: TripCountryWithAssessment; 

  constructor() { }

  ngOnInit() {
  }

}
