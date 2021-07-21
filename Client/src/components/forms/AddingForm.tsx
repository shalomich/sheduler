import React from "react";
import api, { SuccesStatus } from "../../api";
import { UseAuthorizedContext } from "../Account";
import { UseErrorContext } from "../ErrorPresenter";
import { ActionFormType } from "../pages/FormPage";

const AddingForm : React.FC<ActionFormType> = ({uri, Form}) => {
    
    const {ShowErrors} = UseErrorContext()

    const {authorizedData} = UseAuthorizedContext()
    const Add = (formData : object) => {
        console.log(formData);
        
        api(uri, {
            method: 'POST', 
            body: formData
        }, authorizedData?.token, SuccesStatus.Created)
        .then(responce => window.location.href = window.location.pathname.replace('/add',''))
        .catch(async failure =>{
            const errorResponce = await failure
            ShowErrors(errorResponce.errors)
        });  
    }

    return <Form sendHandler={Add}/>
}

export default AddingForm