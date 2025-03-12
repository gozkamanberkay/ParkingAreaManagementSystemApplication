export interface CheckInRequest {
  plateNumber: string;
  allowedVehicleSize: number;
}

export enum AllowedWhicleSizeEnum {
  Small = 5,
  Medium = 10,
  Big = 15,
}
