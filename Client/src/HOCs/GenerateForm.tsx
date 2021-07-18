import React, {Fragment} from "react";
import FormField ,{ FormFieldTemplate } from "../components/forms/FormField";

export type FormType = {
    formData? : any
    sendHandler : (formData : any) => void
}

const GenerateForm = (template: Array<FormFieldTemplate>) => {
    const Form : React.FC<FormType> = ({sendHandler, formData}) => {
        const UpdateFormData = (name : string, value : any)  => {

            if (value)
                formData[name] = value
            else formData[name] = null   
        }
    
        return ( 
                
            <form>
            {
                template.map( formField => {
    
                    const name = formField.name 
                    return <Fragment key={name}>
                        <div>
                            <span>{name}: </span>
                        </div>
                        <div>
                            <FormField onValueChange={UpdateFormData} value={formData[name]} template={formField}/>
                        </div>
                    </Fragment>
                }) 
            }
            <button onClick={(event) => {event.preventDefault(); sendHandler(formData)}}>Send</button>
            </form>
        ) 
    }

    return Form;
}

export default GenerateForm