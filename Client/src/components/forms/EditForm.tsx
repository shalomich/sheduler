import React from "react";
import api, { SuccesStatus } from "../../api";
import { UseErrorContext } from "../ErrorPresenter";
import { ActionFormType } from "../pages/FormPage";

const EditForm : React.FC<ActionFormType> = ({uri, Form}) => {
    
    const [model, setModel] = React.useState<object>()

    React.useEffect(()=> {
        api(uri,{
            method: 'GET'
        })
        .then(responce => setModel(responce as object))
    },[])

    const {ShowErrors} = UseErrorContext()

    const Edit = (formData : object) => {
        console.log(formData);
        
        api(uri, {
            method: 'PUT', 
            body: formData
        }, undefined, SuccesStatus.NoContent)
        .then(responce => responce)
        .catch(async failure =>{
            console.log(failure.status);
            
            const errorResponce = await failure
        
            if (errorResponce.errors)
                ShowErrors(errorResponce.errors)
        });  
    }

    console.log(model);
    
    if (model) 
        return <Form sendHandler={Edit} formData={model}/>
    else return null
}

export default EditForm