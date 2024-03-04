import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './views/test/test.component';
import { CreateComponent } from './views/create/create.component';
import { ReadComponent } from './views/read/read.component';
import { UpdateComponent } from './views/update/update.component';
import { DeleteComponent } from './views/delete/delete.component';

const routes: Routes = [
  { path: 'test', component: TestComponent },
  { path: 'create', component: CreateComponent},
  { path: 'read', component: ReadComponent },
  { path: 'update', component: UpdateComponent },
  { path: 'delete', component: DeleteComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
