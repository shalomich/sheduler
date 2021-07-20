import React from "react";

export const baseApiUri : string = 'https://localhost:44347/'

const formUri = baseApiUri + 'form/'

export const loginFormUri = formUri + 'login'

export const userFormUri = formUri + 'user'

export const selfFormUri = formUri + 'self'

export const loginUri : string = baseApiUri + 'auth/login'

export const userUri : string = baseApiUri + 'user/'

export const requestUri : string = baseApiUri + 'request/'

export const selfProfileUri : string = userUri + 'self'

