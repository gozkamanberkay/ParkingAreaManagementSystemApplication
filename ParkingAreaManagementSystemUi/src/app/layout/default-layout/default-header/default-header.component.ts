import { NgTemplateOutlet } from '@angular/common';
import { Component, computed, inject, input } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

import {
  BreadcrumbRouterComponent,
  ColorModeService,
  ContainerComponent,
  HeaderComponent,
  HeaderNavComponent,
  HeaderTogglerDirective,
  NavItemComponent,
  NavLinkDirective,
  SidebarToggleDirective,
} from '@coreui/angular';

import { IconDirective } from '@coreui/icons-angular';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-default-header',
  templateUrl: './default-header.component.html',
  imports: [
    ContainerComponent,
    HeaderTogglerDirective,
    SidebarToggleDirective,
    IconDirective,
    HeaderNavComponent,
    NavItemComponent,
    NavLinkDirective,
    RouterLink,
    RouterLinkActive,
    NgTemplateOutlet,
    BreadcrumbRouterComponent,
  ],
})
export class DefaultHeaderComponent extends HeaderComponent {
  readonly #colorModeService = inject(ColorModeService);
  readonly colorMode = this.#colorModeService.colorMode;

  readonly colorModes = [
    { name: 'light', text: 'Light', icon: 'cilSun' },
    { name: 'dark', text: 'Dark', icon: 'cilMoon' },
    { name: 'auto', text: 'Auto', icon: 'cilContrast' },
  ];

  readonly icons = computed(() => {
    const currentMode = this.colorMode();
    return (
      this.colorModes.find((mode) => mode.name === currentMode)?.icon ??
      'cilSun'
    );
  });

  constructor(private readonly authService: AuthService) {
    super();
  }

  sidebarId = input('sidebar1');

  logout() {
    this.authService.logout();
  }
}
