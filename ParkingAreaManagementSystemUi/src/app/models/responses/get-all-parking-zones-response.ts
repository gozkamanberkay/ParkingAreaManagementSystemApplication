import { AllowedWhicleSizeEnum } from './../requests/check-in-request';

export interface GetAllParkingZonesResponse {
  name: string;
  capacity: number;
  hourlyFee: number;
  parkingSpots: Array<ParkingSpot>;
}

export interface ParkingSpot {
  name: string;
  isOccupied: boolean;
  allowedVehicleSize: AllowedWhicleSizeEnum;
}
