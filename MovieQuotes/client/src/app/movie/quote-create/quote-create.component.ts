import { Component, OnInit, Output,Input, EventEmitter } from '@angular/core';
import { MovieService } from '../../Services/movie.service';
import { Quote } from 'src/app/models/quote';
declare var $: any;


@Component({
  selector: 'app-quote-create',
  templateUrl: './quote-create.component.html',
  styleUrls: ['./quote-create.component.css']
})
export class QuoteCreateComponent implements OnInit {

  private model:Quote
  @Input()
  set movieId(id){
    this.model.movieId=id
  }
  @Output() created = new EventEmitter<Number>();


  constructor(private service:MovieService) { 
    this.model= new Quote()
  }

  ngOnInit() {
  }
  addQuote(){
    console.log(this.model)
    this.service.addQuote(this.model).subscribe(id=>{
      $("#QuoteModal").modal('toggle')
      this.created.emit(this.model.movieId)
      this.model.text=null
    })
  }

}
