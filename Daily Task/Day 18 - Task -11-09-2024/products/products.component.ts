import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  prolst :product[]=[
    
     {ProId:1,Name:"Mac book pro",Price:300000,Stock:10,Category:"Laptop",Img: "./../../../public/mac.jfif"},
     {ProId:2,Name:"Iphone 12",Price:60000,Stock:70,Category:"Mobile",Img: "./../../../public/iphone.jfif"},
     {ProId:3,Name:"Samsung S20 Ultra",Price:100000,Stock:20,Category:"Mobile",Img: "./../../../public/samsung.jfif"},
     {ProId:4,Name:"Samsung 10kg washing machine",Price:40000,Stock:0,Category:"Washing Machine",Img: "./../../../public/washmachine.jfif"},
     {ProId:5,Name:"MI 4k OLED 55inch TV",Price:60000,Stock:50,Category:"Tv",Img: "./../../../public/tv1.jfif"},

    
  ]
  category:string[]=[
    "All","Tv","Mobile","Laptop","Washing Machine"
  ]
  val:string='All'
  onSubmit(val:any)
  {
      this.prolst.push(val.value)
  }

}
class product{
  ProId?:number
  Name?:string
  Price?:number
  Stock:number=0
  Category?:string
  Img?:string

}
