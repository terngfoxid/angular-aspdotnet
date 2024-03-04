import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CRUDService } from '../../services/crud.service';
import { School } from '../../models';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  title: string = 'Create Form';
  public school: School = new School();

  CreateForm = new FormGroup({
    Name: new FormControl('', Validators.required),
  });

  constructor(private crud: CRUDService) { }

  async onSubmit() {
    this.school.name = this.CreateForm.value.Name
    await this.crud.postSchool(this.school).subscribe(
      (result) => {
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
