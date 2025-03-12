export interface CheckOutResponse {
  checkedInAt: Date;
  checkedOutAt: Date;
  hourlyFee: number;
  parkDurationInHours: number;
  totalFee: number;
}
