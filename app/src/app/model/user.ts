export class User {
  userAccountId: number;
  emailAddress: string;
  password: string;
  dateOfBirth: Date;
  firstName: string;
  lastName: string;
  fullName: string;
  role: string;
  isAdmin: boolean;
  token?: string;
}
