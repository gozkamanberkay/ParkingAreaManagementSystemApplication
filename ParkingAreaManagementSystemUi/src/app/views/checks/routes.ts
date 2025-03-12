import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Checks',
    },
    children: [
      {
        path: '',
        redirectTo: 'check-in',
        pathMatch: 'full',
      },
      {
        path: 'check-in',
        loadComponent: () =>
          import('./check-in.component').then((m) => m.CheckInComponent),
        data: {
          title: 'Check In',
        },
      },
      {
        path: 'check-out',
        loadComponent: () =>
          import('./check-out.component').then((m) => m.CheckOutComponent),
        data: {
          title: 'Check Out',
        },
      },
    ],
  },
];
