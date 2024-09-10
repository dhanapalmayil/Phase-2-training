import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-movie',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent {
  movielst: movie[] = [
    {MovieId: 1, MovieName: "Goat", MovieLanguage: "Tamil", Price: 250, Img: "./../../../public/goat.png", Stock: 5, Rating: 1},
    {MovieId: 2, MovieName: "Kanguva", MovieLanguage: "Tamil", Price: 1500, Img: "./../../../public/kanguva.webp", Stock: 3, Rating: 2},
    {MovieId: 3, MovieName: "Interstellar", MovieLanguage: "English", Price: 1000, Img: "./../../../public/inter.jpg", Stock: 0, Rating: 3},
    {MovieId: 4, MovieName: "Fast and Furious", MovieLanguage: "English", Price: 700, Img: "./../../../public/furious.jfif", Stock: 3, Rating: 5},
  ];

  cart: movie[] = [];  
  totalPrice: number = 0; 
  addToCart(movie: movie) {
    if (movie.Stock && movie.Stock > 0) {
      movie.Stock--; 
      this.cart.push(movie);  
      this.totalPrice += movie.Price ? movie.Price : 0; 
      alert(`${movie.MovieName} has been added to the cart! Remaining stock: ${movie.Stock}`);
    }
  }

  buyNow(movie: movie) {
    if (movie.Stock && movie.Stock > 0) {
      movie.Stock--;  // Decrease stock by 1
      alert(`${movie.MovieName} has been purchased! Remaining stock: ${movie.Stock}`);
      console.log("Movie Details:");
      console.log(`MovieId: ${movie.MovieId}`);
      console.log(`MovieName: ${movie.MovieName}`);
      console.log(`MovieLanguage: ${movie.MovieLanguage}`);
      console.log(`Price: ${movie.Price}`);
      console.log(`Stock: ${movie.Stock}`);
      console.log(`Rating: ${movie.Rating}`);
    }
  }

  getStars(rating: number): string {
    const filledStars = '★'.repeat(rating); 
    const emptyStars = '☆'.repeat(5 - rating);
    return filledStars + emptyStars;
  }
}

class movie {
  MovieId?: number;
  MovieName?: string;
  MovieLanguage?: string;
  Price?: number;
  Img?: string;
  Stock?: number;
  Rating: number=0;
}
