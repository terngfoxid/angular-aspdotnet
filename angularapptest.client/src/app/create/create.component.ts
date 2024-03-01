import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  title: string = 'Create Form';

  CreateForm = new FormGroup({
    Name: new FormControl('', Validators.required),
  });

  constructor(private http: HttpClient) { }

  async onSubmit() {
    await this.http.post('/crud', this.CreateForm.value).subscribe(
      (result) => {
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
