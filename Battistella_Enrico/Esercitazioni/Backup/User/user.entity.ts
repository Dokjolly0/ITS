export interface user_entity {
  id?: string;
  firstName: string;
  lastName: string;
  fullName?: string;
  picture: string;
}
export interface user_entityCredential {
  id?: string;
  provider: string;
  id_user: string;
  credential: {
    username: string;
    hash_password: string;
  };
}
