import React from "react";
import api, { SuccesStatus } from "../../api";
import { UseErrorContext } from "../ErrorPresenter";
import { ActionFormType } from "../pages/FormPage";

const AddingForm : React.FC<ActionFormType> = ({uri, Form}) => {
    
    const {ShowErrors} = UseErrorContext()

    const Add = (formData : object) => {
        console.log(formData);
        
        api(uri, {
            method: 'POST', 
            body: formData
        }, undefined, SuccesStatus.Created)
        .then(responce => window.location.href = window.location.pathname.replace('/add',''))
        .catch(async failure =>{
            const errorResponce = await failure
            ShowErrors(errorResponce.errors)
        });  
    }

    return <Form sendHandler={Add}/>
}

export default AddingForm