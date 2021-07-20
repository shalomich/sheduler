import axios from "axios";
import React from "react";
import { baseApiUri } from "../../apiConfig";
import GenerateForm, { FormType } from "../../HOCs/GenerateForm";
import ErrorPresenter from "../ErrorPresenter";
import { FormFieldTemplate } from "../forms/FormField";
import Loading from "../Loading";

export type ActionFormType = {
    uri : string,
    Form : React.FC<FormType>
}

type FormPageType = {
    formUri: string,
    actionUri: string,
    FormComponent: React.FC<ActionFormType>,
    match? : any 
}

const FormPage : React.FC<FormPageType> = ({formUri,actionUri, FormComponent, match}) => {

    const [template, setTemplate] = React.useState<Array<FormFieldTemplate>>()
    
    React.useEffect(() => {
        axios.get(formUri)
            .then(async responce => {
                const template : Array<FormFieldTemplate> = responce.data.template
    
                for (var fieldTemplate of template){
                    const metadataPath : string = fieldTemplate.metadata
                    if (metadataPath) {
                        const responce = await axios.get(baseApiUri + metadataPath)
                        fieldTemplate.metadata = responce.data
                    }
                }
                setTemplate(template) 
            }) 
    },[])

    const id = match?.params?.id
    
    if (id != undefined)
        actionUri = `${actionUri}${id}`
    
    if (template) {
        const form = GenerateForm(template)
        return (
            <ErrorPresenter>
                <FormComponent Form={form} uri={actionUri}/>
            </ErrorPresenter>
        )  
    } else return <Loading/>
}

export default FormPage