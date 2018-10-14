import { Component, OnInit, NgZone } from '@angular/core';
import { MovieService } from 'src/app/Services/movie.service';
import { Quote } from 'src/app/models/quote';
declare var $:any
@Component({
  selector: 'app-random-quote',
  templateUrl: './random-quote.component.html',
  styleUrls: ['./random-quote.component.css']
})
export class RandomQuoteComponent implements OnInit {

  quotes:Quote[]
  constructor(private service:MovieService,private ngZone: NgZone) { }

  ngOnInit() {
    $('#random').on('shown.bs.modal', (e)=> {
      this.loadQuote()
    })
  }
  loadQuote(){
    this.service.getRandomQuotes().subscribe(quotes=>{
      this.ngZone.run( () => {
        console.log(quotes)
        this.quotes=quotes
      })
    })
  }

}
