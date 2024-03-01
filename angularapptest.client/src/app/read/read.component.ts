import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-read',
  templateUrl: './read.component.html',
  styleUrl: './read.component.css'
})
export class ReadComponent {
  title: string = 'Read Form';

  public schoolName = "-";

  ReadForm = new FormGroup({
    ID: new FormControl('', Validators.required),
  });

  constructor(private http: HttpClient) { }

  async onSubmit() {
    await this.http.get<{school:{name:string}}>('/crud?ID='+this.ReadForm.value.ID).subscribe(
      (result) => {
        console.log(result);
        this.schoolName = result.school.name;
      },
      (error) => {
        console.error(error);
        this.schoolName = "ไม่พบข้อมูล";
      }
    );
  }
}
