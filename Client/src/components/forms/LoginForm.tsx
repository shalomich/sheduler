import React from 'react'
import axios from 'axios'
import {UseAuthorizedContext} from '../Account'
import { UseErrorContext } from '../ErrorPresenter'
import {ActionFormType} from '../pages/FormPage'
import api from '../../api'

type LoginFormData = {
    email : string,
    password : string
}



const LoginForm : React.FC<ActionFormType> = ({uri, Form}) => {

    const {UpdateToken} = UseAuthorizedContext()
    const {ShowErrors} = UseErrorContext()

    const Login = (formData : LoginFormData) => {
        
        api(uri, {
            method: 'POST', 
            body: formData
        })
        .then(responce => UpdateToken(responce as string))
        .catch(async failure =>{
            const errorResponce = await failure
            ShowErrors(errorResponce.errors)
        });  
    }

    return <Form sendHandler={Login}/>
}

export default LoginForm