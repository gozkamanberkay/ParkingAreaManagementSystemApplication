import { CommonModule } from '@angular/common';
import { ApiService } from './../../services/api.service';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {
  TextColorDirective,
  CardComponent,
  CardHeaderComponent,
  CardBodyComponent,
  AlertComponent,
} from '@coreui/angular';
import { CheckInRequest } from '../../models/requests/check-in-request';
import { BaseResponseStatusEnum } from '../../models/responses/base-response';

@Component({
  templateUrl: 'check-in.component.html',
  styleUrls: ['check-in.component.scss'],
  imports: [
    TextColorDirective,
    CardComponent,
    CardHeaderComponent,
    CardBodyComponent,
    FormsModule,
    AlertComponent,
    CommonModule,
  ],
})
export class CheckInComponent {
  alertVisible = false;
  requestIsSuccess = false;
  responseMessage: string | null = null;

  plateNumberToCheckIn: string | null = null;
  vehicleSizeToCheckIn: number = 0;

  constructor(private readonly apiService: ApiService) {}

  checkIn() {
    let request = <CheckInRequest>{
      plateNumber: this.plateNumberToCheckIn,
      allowedVehicleSize: Number(this.vehicleSizeToCheckIn),
    };

    this.apiService.checkIn(request).subscribe(
      (response) => {
        let message = response.message!;

        if (response.status == BaseResponseStatusEnum.Ok) {
          message = `${response.data.parkingSpotName} spot has been reserved from ${response.data.parkingZoneName}, please direct the vehicle to that area.`;
        }

        this.handleRequestForAlert(true, message!);
      },
      (error) => {
        this.handleRequestForAlert(false, error.message);
      }
    );
  }

  private handleRequestForAlert(success: boolean, message: string) {
    this.requestIsSuccess = success;
    this.responseMessage = message;
    this.alertVisible = true;

    setTimeout(() => {
      this.alertVisible = false;
    }, 5000);
  }
}
