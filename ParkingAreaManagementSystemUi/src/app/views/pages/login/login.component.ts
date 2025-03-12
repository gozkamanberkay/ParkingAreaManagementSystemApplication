import { FormsModule } from '@angular/forms';
import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

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

import { AuthService } from './../../../services/auth.service';
import { LoginRequest } from './../../../models/requests/login-request';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
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
export class LoginComponent {
  email: string | null = null;
  password: string | null = null;

  constructor(
    private readonly authService: AuthService,
    private router: Router
  ) {}

  login() {
    let request = <LoginRequest>{
      email: this.email,
      password: this.password,
    };

    this.authService.login(request).subscribe((response) => {
      if (response) {
        this.router.navigate(['/dashboard']);
      }
    });
  }
}
