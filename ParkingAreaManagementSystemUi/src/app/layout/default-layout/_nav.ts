import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' },
  },
  {
    title: true,
    name: 'Check In / Check Out',
  },
  {
    name: 'Check In',
    url: '/checks/check-in',
    iconComponent: { name: 'cilArrowThickToLeft' },
  },
  {
    name: 'Check Out',
    url: '/checks/check-out',
    iconComponent: { name: 'cilArrowThickFromLeft' },
  },
];
