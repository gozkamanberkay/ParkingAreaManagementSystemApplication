import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import {
  AlertComponent,
  TextColorDirective,
  CardComponent,
  CardHeaderComponent,
  CardBodyComponent,
} from '@coreui/angular';
import { CheckOutRequest } from 'src/app/models/requests/check-out-request';
import { BaseResponseStatusEnum } from 'src/app/models/responses/base-response';
import { ApiService } from 'src/app/services/api.service';

import {
  ButtonCloseDirective,
  ButtonDirective,
  ModalBodyComponent,
  ModalComponent,
  ModalFooterComponent,
  ModalHeaderComponent,
  ModalTitleDirective,
  ThemeDirective,
} from '@coreui/angular';
import { CheckOutResponse } from 'src/app/models/responses/check-out-response';

@Component({
  templateUrl: 'check-out.component.html',
  styleUrls: ['check-out.component.scss'],
  imports: [
    TextColorDirective,
    CardComponent,
    CardHeaderComponent,
    CardBodyComponent,
    FormsModule,
    CommonModule,
    AlertComponent,
    ButtonDirective,
    ModalComponent,
    ModalHeaderComponent,
    ModalTitleDirective,
    ThemeDirective,
    ButtonCloseDirective,
    ModalBodyComponent,
    ModalFooterComponent,
  ],
})
export class CheckOutComponent {
  alertVisible = false;
  visible = false;

  plateNumberToCheckOut: string = '';
  checkOutSummary: CheckOutResponse | null = null;

  constructor(private readonly apiService: ApiService) {}

  checkOut() {
    let request = <CheckOutRequest>{
      plateNumber: this.plateNumberToCheckOut,
    };

    this.apiService.checkOut(request).subscribe(
      (response) => {
        if (response.status == BaseResponseStatusEnum.Ok) {
          this.changeVisible();
          this.checkOutSummary = response.data;
        }
      },
      (error) => {
        this.alertVisible = true;

        setTimeout(() => {
          this.alertVisible = false;
        }, 3000);
      }
    );
  }

  changeVisible() {
    this.visible = !this.visible;
  }

  handleVisibleChange(event: any) {
    this.visible = event;
  }
}
