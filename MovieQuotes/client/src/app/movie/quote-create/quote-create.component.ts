import { Component, OnInit, Input } from '@angular/core';
import { MovieService } from '../../Services/movie.service';

@Component({
  selector: 'app-quote-create',
  templateUrl: './quote-create.component.html',
  styleUrls: ['./quote-create.component.css']
})
export class QuoteCreateComponent implements OnInit {

  private _id:Number
  @Input() movieId:Number

  constructor(service:MovieService) { }

  ngOnInit() {
    
  }

}
