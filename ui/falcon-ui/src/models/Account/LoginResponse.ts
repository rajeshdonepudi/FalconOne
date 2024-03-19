export interface LoginResponse {
  id: string;
  email: string;
  firstName: string;
  lastName: string;
  accessToken: string;
  tenants: string;
  refreshToken: string;
  profilePicture: string;
}
