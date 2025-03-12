import { RegisterRequest } from './../../../models/requests/register-request';
import { Component } from '@angular/core';
import { IconDirective } from '@coreui/icons-angular';
import {
  ContainerComponent,
  RowComponent,
  ColComponent,
  TextColorDirective,
  CardComponent,
  CardBodyComponent,
  FormDirective,
  InputGroupComponent,
  InputGroupTextDirective,
  FormControlDirective,
  ButtonDirective,
} from '@coreui/angular';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  imports: [
    ContainerComponent,
    RowComponent,
    ColComponent,
    TextColorDirective,
    CardComponent,
    CardBodyComponent,
    FormDirective,
    InputGroupComponent,
    InputGroupTextDirective,
    IconDirective,
    FormControlDirective,
    ButtonDirective,
    FormsModule,
    RouterLink,
  ],
})
export class RegisterComponent {
  email: string | null = null;
  password: string | null = null;

  constructor(
    private readonly authService: AuthService,
    private router: Router
  ) {}

  register() {
    let request = <RegisterRequest>{
      email: this.email,
      password: this.password,
    };

    this.authService.register(request).subscribe({
      next: (response) => {
        if (response) {
          this.router.navigate(['/dashboard']);
        }
      },
      error: (error) => {
        console.error('Registration failed', error);
      },
      complete: () => {},
    });
  }
}
