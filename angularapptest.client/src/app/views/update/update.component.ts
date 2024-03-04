import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CRUDService } from '../../services/crud.service';
import { School } from '../../models';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrl: './update.component.css'
})
export class UpdateComponent {
  title: string = 'Update Form';
  public school: School = new School();

  UpdateForm = new FormGroup({
    Name: new FormControl('', Validators.required),
    Id: new FormControl('', Validators.required)
  });

  constructor(private crud: CRUDService) { }

  async onSubmit() {
    this.school.name = this.UpdateForm.value.Name
    this.school.id = this.UpdateForm.value.Id
    await this.crud.putSchool(this.school).subscribe(
      (result) => {
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
