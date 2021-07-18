import React from 'react'
import { FormType } from '../../HOCs/GenerateForm'
import axios from 'axios'
import {UseAuthorizedContext} from '../Account'

type LoginFormType = {
    uri : string,
    Form : React.FC<FormType>
}

type LoginFormData = {
    email : string,
    password : string
}

const LoginForm : React.FC<LoginFormType> = ({uri, Form}) => {

    const {UpdateToken} = UseAuthorizedContext()

    const Login = (formData : LoginFormData) => {
        axios.post(uri,formData)
            .then(responce => responce.data)
            .then(token => UpdateToken(token))
    }

    return <Form sendHandler={Login}/>
}

export default LoginForm