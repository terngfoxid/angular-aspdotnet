import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { School } from '../../models';
import { CRUDService } from '../../services/crud.service';

@Component({
  selector: 'app-read',
  templateUrl: './read.component.html',
  styleUrl: './read.component.css'
})
export class ReadComponent {
  title: string = 'Read Form';

  public schoolName: string | null|undefined = "-";
  public school: School | null = null;

  ReadForm = new FormGroup({
    ID: new FormControl('', Validators.required),
  });

  constructor(private crud: CRUDService) { }

  async onSubmit() {
    await this.crud.getSchool(this.ReadForm.value.ID).subscribe(
      (result) => {
        console.log(result);
        this.school = result.school
        if (this.school != null) {
          console.log(this.school)
          this.schoolName = this.school.name;
        }
      },
      (error) => {
        this.schoolName = "ไม่พบข้อมูล";
        console.error(error);
      }
    );
  }
}
