import { User } from '../types';
import defaultUser from '../utils/default-user';
import { ShantiApiPost } from './shantiajax';

export async function signIn(login: string, password: string) {
  try {
    var answer = ShantiApiPost("/api/login/signin", {login, password});
    if((await answer).success){
      storeTokenInLocalStorage((await answer).data, {email: login});
      return {
        isOk: true,
        data: {email: login}
      };
    }  else {
      return {
        isOk: false,
        message: (await answer).errorMessages
      };
    }    
  }
  catch {
    return {
      isOk: false,
      message: "Authentication failed"
    };
  }
}

export async function getUser() {
  try {
    const token = getTokenFromLocalStorage();
    if (!token) {
      return { 
        isOk: false,
        data: undefined
      }
    } else return {
      isOk: true,
      data: getUserFromLocalStorage()
    };
  }
  catch {
    return {
      isOk: false
    };
  }
}

export async function createAccount(login: string, password: string) {
  try {
    var answer = ShantiApiPost("/api/login/signup", {login, password});
    if((await answer).success){
      return {
        isOk: true,
      };
    }
    else {
      return {
        isOk: false,
        message: (await answer).errorMessages
      };
    }

  }
  catch {
    return {
      isOk: false,
      message: "Failed to create account"
    };
  }
}

export async function changePassword(email: string, recoveryCode?: string) {
  try {
    // Send request
    console.log(email, recoveryCode);

    return {
      isOk: true
    };
  }
  catch {
    return {
      isOk: false,
      message: "Failed to change password"
    }
  }
}

export async function resetPassword(email: string) {
  try {
    // Send request
    console.log(email);

    return {
      isOk: true
    };
  }
  catch {
    return {
      isOk: false,
      message: "Failed to reset password"
    };
  }
}

export function storeTokenInLocalStorage(token, user: User) {
  localStorage.setItem('token', token);
  localStorage.setItem('user', JSON.stringify(user));
}

export function getTokenFromLocalStorage() {
  return localStorage.getItem('token');
}

export function getUserFromLocalStorage() {
  return JSON.parse(localStorage.getItem('user'));
}
