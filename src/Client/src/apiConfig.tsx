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

export const selfUri : string = userUri + 'self/'

export const selfProfileUri : string = selfUri + 'profile'

export const createdStatus = 'created'
export const sentStatus = 'sent'
export const withdrawnStatus = 'withdrawn'
export const cancelledStatus = 'cancelled'
export const approvedStatus = 'approved'
export const disapprovedStatus = 'disapproved'
export const allowedStatus = 'allowed'
export const disallowedStatus = 'disallowed'




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

