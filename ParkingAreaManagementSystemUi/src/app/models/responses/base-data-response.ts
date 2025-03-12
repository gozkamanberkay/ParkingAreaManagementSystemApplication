import { BaseResponse } from './base-response';

export interface BaseDataResponse<T> extends BaseResponse {
  data: T;
}
