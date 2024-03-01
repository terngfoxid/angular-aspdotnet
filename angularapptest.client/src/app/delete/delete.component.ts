import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class DeleteComponent {
  title: string = 'Delete Form';

  public result = "-";

  DeleteForm = new FormGroup({
    ID: new FormControl('', Validators.required),
  });

  constructor(private http: HttpClient) { }

  async onSubmit() {
    await this.http.delete<{school:{name:string}}>('/crud?ID='+this.DeleteForm.value.ID).subscribe(
      (result) => {
        console.log(result);
        this.result = "ลบ"+result.school.name+"แล้ว";
      },
      (error) => {
        console.error(error);
        this.result = "error";
      }
    );
  }
}
