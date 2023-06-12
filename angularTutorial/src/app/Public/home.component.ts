import { Component, OnInit } from '@angular/core';
import { JobService } from '../Core/Services/job.service';
import { Job } from '../Shared/Models/Job';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  /**
   *
   */
  availableJobs:Job[] = [];
  exampleVariable:string = 'example string';

  // dependency injection
  constructor(private jobService:JobService) { }

  ngOnInit(): void {
    
    // setTimeout(() => {
    //   this.exampleVariable = "The new data"
    // }, 2000);
    console.log("\nHere we go:");
    this.jobService.getAllJobs().subscribe(data => {
      this.availableJobs = data;
      
        console.log("\nHere we go Jobs:");
        console.log(this.availableJobs);
       
      }
    );

  }

}
