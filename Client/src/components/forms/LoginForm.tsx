import React from 'react'
import { FormType } from '../../HOCs/GenerateForm'
import axios from 'axios'
import {UseAuthorizedContext} from '../Account'
import { UseErrorContext } from '../ErrorPresenter'


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
    const {SetErrors} = UseErrorContext()

    const Login = (formData : LoginFormData) => {
        axios.post(uri,formData)
            .then(responce => UpdateToken(responce.data))
            .catch(failure =>{
               console.log(failure);
            });
            
    }

    return <Form sendHandler={Login}/>
}

export default LoginForm