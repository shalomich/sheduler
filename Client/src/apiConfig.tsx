import React from "react";

export const baseApiUri : string = 'https://localhost:44347/'

const formUri = baseApiUri + "form/"

export const loginFormUri = formUri + "login"

export const loginUri : string = baseApiUri + 'auth/login'

const profileUri : string = baseApiUri + 'user/self'