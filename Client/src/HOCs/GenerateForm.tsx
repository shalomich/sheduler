import React, {Fragment} from "react";
import FormField ,{ FormFieldTemplate } from "../components/forms/FormField";

export type FormType = {
    formData? : any
    sendHandler : (formData : any) => void
}

const GenerateForm = (template: Array<FormFieldTemplate>) => {
    const Form : React.FC<FormType> = ({sendHandler, formData = {}}) => {
        
        const [data, setData] = React.useState(formData)
        
        const UpdateFormData = (name : string, value : any)  => {
            console.log(value);
            
            if (value !== undefined)
                data[name] = value
            else data[name] = null
            
            console.log(data);
            
        }
    
        return ( 
                
            <form>
            {
                template.map( formField => {
    
                    const {name,text} = formField
                    
                    return <Fragment key={name}>
                        <div>
                            <span>{text}: </span>
                        </div>
                        <div>
                            <FormField onValueChange={UpdateFormData} value={data[name]} template={formField}/>
                        </div>
                    </Fragment>
                }) 
            }
            <button onClick={(event) => {event.preventDefault(); sendHandler(data)}}>Send</button>
            </form>
        ) 
    }

    return Form;
}

export default GenerateForm