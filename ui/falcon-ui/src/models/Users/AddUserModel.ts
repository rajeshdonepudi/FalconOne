export interface AddUserModel {
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  phone: string;
  password: string;
  confirmPassword: string;
  isEmailConfirmed: boolean;
  isPhoneConfirmed: boolean;
  isTwoFactorEnabled: boolean;
  isLockoutEnabled: boolean;
}
