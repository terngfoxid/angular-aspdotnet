import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestComponent } from './views/test/test.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CreateComponent } from './views/create/create.component';
import { ReadComponent } from './views/read/read.component';
import { UpdateComponent } from './views/update/update.component';
import { DeleteComponent } from './views/delete/delete.component';

@NgModule({
  declarations: [
    AppComponent,
    TestComponent,
    CreateComponent,
    ReadComponent,
    UpdateComponent,
    DeleteComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
