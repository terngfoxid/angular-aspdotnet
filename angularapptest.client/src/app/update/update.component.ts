import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrl: './update.component.css'
})
export class UpdateComponent {
  title: string = 'Update Form';

  UpdateForm = new FormGroup({
    Name: new FormControl('', Validators.required),
    Id: new FormControl('', Validators.required)
  });

  constructor(private http: HttpClient) { }

  async onSubmit() {
    await this.http.put('/crud', this.UpdateForm.value).subscribe(
      (result) => {
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
