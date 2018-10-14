import {Component, OnInit} from '@angular/core';
import {Movie} from '../../models/movie';
import {MovieService} from '../../Services/movie.service';
import {Router} from '@angular/router';

@Component({selector: 'app-movie-edit', templateUrl: './movie-edit.component.html', styleUrls: ['./movie-edit.component.css']})
export class MovieEditComponent implements OnInit {

  model : Movie
  constructor(private router : Router, private service : MovieService) {}

  onSubmit() {
    console.log(this.model)
    if (this.model.title && this.model.year) {
      this.service.addMovie(this.model).subscribe(id => {
          if(id) {
            this
              .router
              .navigateByUrl("/movie")
          }
        })
    }

  }

  ngOnInit() {
    if (!this.model) {
      this.model = new Movie()
    }
    
  }

}
