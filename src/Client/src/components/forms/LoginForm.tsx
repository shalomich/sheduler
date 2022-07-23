import React from 'react'
import axios from 'axios'
import {UseAuthorizedContext} from '../Account'
import { UseErrorContext } from '../ErrorPresenter'
import {ActionFormType} from '../pages/FormPage'
import api from '../../api'
import { InitialPagePath } from '../../appConfig'

type LoginFormData = {
    email : string,
    password : string
}



const LoginForm : React.FC<ActionFormType> = ({uri, Form}) => {

    const {SignIn} = UseAuthorizedContext()
    const {ShowErrors} = UseErrorContext()

    const Login = (formData : LoginFormData) => {
        console.log('login');
        
        api(uri, {
            method: 'POST', 
            body: formData
        })
        .then(responce => {
            const token : string = responce as any
            console.log(token);
            
            SignIn(token)
            window.location.href = InitialPagePath
        })
        .catch(async failure =>{
            const errorResponce = await failure
            ShowErrors(errorResponce.errors)
        });  
    }

    return <Form sendHandler={Login}/>
}

export default LoginForm