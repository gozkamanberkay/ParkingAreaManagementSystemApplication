import { AllowedWhicleSizeEnum } from './../../models/requests/check-in-request';
import { GetAllParkingZonesResponse } from './../../models/responses/get-all-parking-zones-response';
import { ApiService } from './../../services/api.service';
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import {
  CardBodyComponent,
  CardComponent,
  TableDirective,
  TextColorDirective,
} from '@coreui/angular';
import { BaseResponseStatusEnum } from 'src/app/models/responses/base-response';

@Component({
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.scss'],
  imports: [
    TextColorDirective,
    CardComponent,
    CardBodyComponent,
    ReactiveFormsModule,
    TableDirective,
    CommonModule,
  ],
})
export class DashboardComponent implements OnInit {
  parkingZones: Array<GetAllParkingZonesResponse> | null = null;
  parkingSpots: Array<ParkingSpotWithParkingZone> | null = null;

  constructor(private readonly apiService: ApiService) {}

  ngOnInit(): void {
    this.getAllParkingZones();
  }

  getAllParkingZones() {
    this.apiService.getAllParkingZones().subscribe((response) => {
      if (response.status == BaseResponseStatusEnum.Ok) {
        this.parkingZones = response.data;

        this.parkingSpots = response.data.flatMap((parkingZone) => {
          return parkingZone.parkingSpots.map((parkingSpot) => {
            return {
              parkingSpotName: parkingSpot.name,
              parkingSpotIsOccupied: parkingSpot.isOccupied,
              parkingSpotAllowedVehicleSize: parkingSpot.allowedVehicleSize,
              parkingZoneName: parkingZone.name,
              parkingZoneCapacity: parkingZone.capacity,
              parkingZoneHourlyFee: parkingZone.hourlyFee,
            };
          });
        });
      }
    });
  }
}

export interface ParkingSpotWithParkingZone {
  parkingSpotName: string;
  parkingSpotIsOccupied: boolean;
  parkingSpotAllowedVehicleSize: AllowedWhicleSizeEnum;
  parkingZoneName: string;
  parkingZoneCapacity: number;
  parkingZoneHourlyFee: number;
}
