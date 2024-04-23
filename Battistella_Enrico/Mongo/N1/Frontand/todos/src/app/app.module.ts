import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { TodoService } from './service/todo.service'; // Assicurati di importare correttamente il servizio
import { FormsModule } from '@angular/forms'; // Importa FormsModule per utilizzare ngModel

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    HttpClientModule, // Importa HttpClientModule per utilizzare HttpClient
    FormsModule, // Importa FormsModule per utilizzare ngModel
  ],
  providers: [
    TodoService, // Aggiungi il servizio ai provider
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
