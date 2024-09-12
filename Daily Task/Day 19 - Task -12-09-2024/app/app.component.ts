import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { OrgListComponent } from "./org-list/org-list.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, OrgListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AngularApiIntegration';
}
