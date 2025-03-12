export interface BaseResponse {
  message: string | null;
  status: BaseResponseStatusEnum;
}

export enum BaseResponseStatusEnum {
  Ok = 10,
  Error = 20,
}
