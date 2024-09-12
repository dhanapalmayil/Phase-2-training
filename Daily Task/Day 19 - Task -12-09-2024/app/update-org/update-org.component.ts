import { Component } from '@angular/core';
import { Organization } from '../org-details/Organization';
import { ApiService } from '../api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-update-org',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './update-org.component.html',
  styleUrl: './update-org.component.css'
})
export class UpdateOrgComponent {
  Orgdata:Organization = {orgId:0,orgName:''}

  constructor(private apiser:ApiService,private route:ActivatedRoute,private router:Router)
  {

  }
  ngOnInit():void{
    const id= +this.route.snapshot.params['id'];
    this.apiser.getbyid(id).subscribe(
      (response) => {
        this.Orgdata=response
      }
    )
  }
  onSubmit():void{
    this.apiser.update(this.Orgdata.orgId,this.Orgdata).subscribe(
      (response) =>{
        console.log('updated added successfully',response);
        this.router.navigate(['/']);
      }
    )
   };

}
