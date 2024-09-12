import { Component } from '@angular/core';
import { Organization } from '../org-details/Organization';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-add-organization',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-organization.component.html',
  styleUrl: './add-organization.component.css'
})
export class AddOrganizationComponent {
   org:Organization = {orgId:0,orgName:''};

   constructor(private apiser:ApiService,private router:Router){

   }
   onSubmit():void{
    this.apiser.postcomp(this.org).subscribe(
      (response) =>{
        console.log('org added successfully',response);
        this.router.navigate(['/']);
      }
    )
   };

}
