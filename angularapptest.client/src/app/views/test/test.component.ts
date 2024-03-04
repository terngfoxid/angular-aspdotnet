import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

interface TestModel {
  Name: string;
  SomeValue: number;
}

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrl: './test.component.css'
})
export class TestComponent {
  title: string = 'Test Form';

  public testx = 1;

  TestForm = new FormGroup({
    Name: new FormControl('', Validators.required),
    SomeValue: new FormControl('', Validators.required)
  });

  constructor(private http: HttpClient) { }

  async onSubmit() {
    await this.http.post('/weatherforecast', this.TestForm.value).subscribe(
      (result) => {
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );

    this.http.delete('/crud/test').subscribe(
      (result) => {
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );

    this.testx = Math.random()*100;
  }
}
