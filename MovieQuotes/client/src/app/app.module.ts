import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { MovieComponent } from './movie/movie.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { MovieEditComponent } from './movie/movie-edit/movie-edit.component';
import { FormsModule } from '@angular/forms';
import { QuoteCreateComponent } from './movie/quote-create/quote-create.component';
import { RandomQuoteComponent } from './movie/random-quote/random-quote.component';
const appRoutes: Routes = [
  { path: 'movie', component: MovieComponent },
  { path: 'movie/new', component: MovieEditComponent },
  { path: '',
    redirectTo: '/movie',
    pathMatch: 'full'
  },
 // { path: '**', component: PageNotFoundComponent }
];
@NgModule({
  declarations: [
    AppComponent,
    MovieComponent,
    MovieEditComponent,
    QuoteCreateComponent,
    RandomQuoteComponent,
    
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(
      appRoutes
    ),
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
