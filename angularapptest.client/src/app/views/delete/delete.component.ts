import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { School } from '../../models';
import { CRUDService } from '../../services/crud.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class DeleteComponent {
  title: string = 'Delete Form';

  public result = "-";
  public school: School | null = null;

  DeleteForm = new FormGroup({
    ID: new FormControl('', Validators.required),
  });

  constructor(private crud: CRUDService) { }

  async onSubmit() {
    await this.crud.deleteSchool(this.DeleteForm.value.ID).subscribe(
      (result) => {
        console.log(result);
        this.school = result.school
        if (this.school != null) {
          console.log(this.school)
          this.result = "ลบ"+this.school.name+"แล้ว";
        }
        
      },
      (error) => {
        console.error(error);
        this.result = "error";
      }
    );
  }
}
