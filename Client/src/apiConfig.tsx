import React from "react";
import { Option } from "./components/forms/Select";

export const baseApiUri : string = 'https://localhost:44347/'

export const formUri : string = baseApiUri + 'form/'

export const loginFormUri : string = formUri + 'login'

export const userFormUri : string = formUri + 'user'

export const selfFormUri : string = formUri + 'self'

export const loginUri : string = baseApiUri + 'auth/login'

export const userUri : string = baseApiUri + 'user/'

export const requestUri : string = baseApiUri + 'request/'

export const requestTypesUri : string = requestUri + 'types'

export const selfProfileUri : string = userUri + 'self'

export const requestTypeOptions : Array<Option> = [
    {
        text: 'На отпуск',
        value: 'vacationRequest'
    },
    {
        text: 'На выходной в счет отпуска',
        value: 'weekendVacationRequest'
    },
    {
        text: 'В выходной за счет отработки',
        value: 'weekendWorkOffRequest'
    },
    {
        text: 'На отгул',
        value: 'dayOffRequest'
    },
    {
        text: 'На удаленную работу',
        value: 'remoteWorkRequest'
    }
]

