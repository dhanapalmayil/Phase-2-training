import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-sampbind',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './sampbind.component.html',
  styleUrl: './sampbind.component.css'
})
export class SampbindComponent {
  fname:string ="Payoda"
  lname:string ="Organization"
  imgpath:string="./../../../public/pickachu.jpg";
  txt:string="";
  value:string="";

  c:number=0;
  count(){
    this.c++;
  }
  show(event:any){
    this.txt=(event.target.value)
  }


}
