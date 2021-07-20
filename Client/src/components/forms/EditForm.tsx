import React from "react";
import api, { SuccesStatus } from "../../api";
import { UseErrorContext } from "../ErrorPresenter";
import Loading from "../Loading";
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
        .then(responce => window.location.href = window.location.pathname.replace('/edit',''))
        .catch(async failure =>{
            const errorResponce = await failure
            const errors = errorResponce?.errors
            
            if(errors)
                ShowErrors(errorResponce.errors)
            else window.location.href = window.location.pathname.replace('/edit','')
        });  
    }

    console.log(model);
    
    if (model) 
        return <Form sendHandler={Edit} formData={model}/>
    else return <Loading/>
}

export default EditForm