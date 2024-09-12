import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-delete-org',
  standalone: true,
  imports: [],
  templateUrl: './delete-org.component.html',
  styleUrl: './delete-org.component.css'
})
export class DeleteOrgComponent {
  

  constructor(private apiser:ApiService,private route:ActivatedRoute)
  {

  }
  ngOnInit():void{
    const id= +this.route.snapshot.params['id'];
    this.apiser.delete(id).subscribe() 
  }

}
