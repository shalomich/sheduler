import { react } from "@babel/types";
import axios from "axios";
import React from "react";
import { baseApiUri, formUri, requestTypeOptions, requestTypesUri, requestUri } from "../../apiConfig";
import AddingForm from "../forms/AddingForm";
import FormField, { FormFieldTemplate } from "../forms/FormField";
import FormPage from "./FormPage";

const RequestAddingPage : React.FC = () => {

    const [requestType, setRequestType] = React.useState<string>()

    const typeSelectTemplate : FormFieldTemplate = {
        name: 'status',
        type: 'select',
        isRequired: true,
        text: 'Тип заявки',
        metadata: requestTypeOptions
    }
    
    const requestFormUri = formUri + requestType
    
    const requestAddingUri = baseApiUri + `request?type=${requestType}`
    console.log(requestAddingUri);
     

    return (
        <div>
            <FormField template={typeSelectTemplate} onValueChange={(name,value) => setRequestType(value)}/>
            {requestType && <FormPage key={requestType} formUri={requestFormUri} actionUri={requestAddingUri} FormComponent={AddingForm}/>} 
        </div>
    )
}

export default RequestAddingPage