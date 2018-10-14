import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Movie } from '../models/movie';
const baseUrl="https://localhost:5001"
@Injectable({
  providedIn: 'root'
})

export class MovieService {
  constructor(private http:HttpClient) { 

  }
  getMovies(params=null):Observable<Movie[]>
  {
    return this.http.get<Movie[]>("/api/movies",{params}).pipe(
      tap(items=>console.log(items),
    ))
  }
  addMovie(movie:Movie):Observable<Number>{
    return this.http.post<Number>("/api/movies",movie)
  }
  deleteMovie(id:Number):Observable<Object>{
    return this.http.delete(`/api/movies/${id}`)
  }
}
