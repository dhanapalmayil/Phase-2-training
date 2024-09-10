import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import{ SampbindComponent } from './sampbind/sampbind.component';
import { MovieComponent } from './movie/movie.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SampbindComponent, MovieComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'first_angular_app';
}
