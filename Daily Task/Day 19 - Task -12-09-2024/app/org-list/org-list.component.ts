import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';

import { CommonModule } from '@angular/common';
import { Organization } from '../org-details/Organization';

@Component({
  selector: 'app-org-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './org-list.component.html',
  styleUrl: './org-list.component.css'
})
export class OrgListComponent {

  orgs: Organization[] = [];

  constructor(private apiser:ApiService,private router:Router)
  {

  }
  // ngOnInit():void{
  //   this.apiser.get().subscribe(
  //     (response) => {
  //      this.data=response;
  //     }
  //   )
  // }
  ngOnInit(): void {
    this.loadCompanies();
  }

  loadCompanies(): void {
    this.apiser.get().subscribe(
      (data) => this.orgs = data,
      (error) => console.error('Error loading companies', error)
    );
  }


  viewDetails(id: number): void {
    this.router.navigate(['/Organization', id]);
  }

  updateCompany(id: number): void {
    this.router.navigate(['/update', id]);
  }
  addCompany(): void {
    this.router.navigate(['/add']);
  }
  deleteCompany(id: number): void {
    if (confirm('Are you sure you want to delete this company?')) {
      this.apiser.delete(id).subscribe(
        () => {
          console.log('Company deleted successfully');
          this.loadCompanies(); 
        },
        (error) => console.error('Error deleting company', error)
      );
    }
  }
}
