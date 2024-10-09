import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  user = {
    firstName: '',
    lastName: '',
    phone: '',
    email: '',
    dateOfBirth: ''
  };
  constructor(private http: HttpClient) { }

  onSubmit(form: any) {
    console.log('Formulario enviado:', form);
    console.log('Datos del usuario:', this.user);

    if (form.valid) {
      // Envía los datos al servidor
      this.http.post('https://localhost:7100/api/users/CreateUserUI', this.user).subscribe(
        response => {
          console.log('Datos enviados con éxito:', response);
          // Restablecer el formulario
          form.reset();
        },
        error => {
          console.error('Error al enviar los datos:', error);
        }
      );
    } else {
      console.log('Formulario inválido');
    }
  }
}
