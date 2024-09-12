import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';
import { response } from 'express';
import { Organization } from './Organization';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-org-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './org-details.component.html',
  styleUrl: './org-details.component.css'
})
export class OrgDetailsComponent {
  
  Orgdata:Organization|undefined

  constructor(private apiser:ApiService,private route:ActivatedRoute)
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

}
