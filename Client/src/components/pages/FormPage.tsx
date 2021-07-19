import axios from "axios";
import React from "react";
import { baseApiUri } from "../../apiConfig";
import GenerateForm, { FormType } from "../../HOCs/GenerateForm";
import ErrorPresenter from "../ErrorPresenter";
import { FormFieldTemplate } from "../forms/FormField";

export type ActionFormType = {
    uri : string,
    Form : React.FC<FormType>
}

type FormPageType = {
    formUri: string,
    actionUri: string,
    FormComponent: React.FC<ActionFormType> 
}

const FormPage : React.FC<FormPageType> = ({formUri,actionUri, FormComponent}) => {

    const [template, setTemplate] = React.useState<Array<FormFieldTemplate>>()
    
    React.useEffect(() => {
        axios.get(formUri)
            .then(responce => {
                const template : Array<FormFieldTemplate> = responce.data.template
                
                template.forEach(fieldTemplate => {
                    const metadataPath : string = fieldTemplate.metadata 
                    if (metadataPath)
                        axios.get(baseApiUri + metadataPath)
                            .then(responce => fieldTemplate.metadata = responce.data)
                })
                setTemplate(template) 
            }) 
    },[])
    
    if (template) {
        const form = GenerateForm(template)
        return (
            <ErrorPresenter>
                <FormComponent Form={form} uri={actionUri}/>
            </ErrorPresenter>
        )  
    }
    
    return null
}

export default FormPage