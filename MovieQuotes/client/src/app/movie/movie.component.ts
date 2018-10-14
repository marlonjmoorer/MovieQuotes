import { Component, OnInit } from '@angular/core';
import { Movie } from '../models/movie';
import { MovieService } from '../Services/movie.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  movies=[]
  movie:Movie=null
  search={title:null,year:null}
  constructor(private service:MovieService) { 
      
  }
  
  findByTitle(title){
    this.loadMovies({title})
  }
  findByYear(year){
    this.loadMovies({year})
  }

  ngOnInit() {
    this.loadMovies()
  }
  loadMovies(params=null){
    this.service.getMovies(params).subscribe(results=>this.movies=results)
  }
  deleteMovie(id){
    if(confirm("Delete this movie?")){
      this.service.deleteMovie(id).subscribe(_=>{
        this.loadMovies()
        this.movie=null
      })
    }
  }
  selectMovie(movie:Movie){
    console.log(movie)
    this.movie=movie
  }

}
