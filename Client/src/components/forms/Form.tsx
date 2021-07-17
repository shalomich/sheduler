import React, {Fragment} from 'react'
import FormField from '../forms/FormField'

type FormFieldTemplate = {
    name : string,
    type : string,
    isRequired : boolean
}

type FormType = {
    template : Array<FormFieldTemplate>,
    metadata : any | null,
    formData? : any
    sendHandler : (formData : object) => void
}

const Form : React.FC<FormType> = ({template, metadata, sendHandler,formData = {}}) => { 
    
    const UpdateFormData = (name : string, value : any)  => {

        if (value)
            formData[name] = value
        else formData[name] = null   
    }

    return ( 
            
        <form>
        {
            template.map( formField => {
                const {name, type, isRequired} = formField
                
                return <Fragment key={name}>
                    <div>
                        <span>{name}: </span>
                    </div>
                    <div>
                        <FormField onValueChange={UpdateFormData} value={formData[name]} name={name} type={type} metadata={metadata[name]} isRequired={isRequired}/>
                    </div>
                </Fragment>
            }) 
        }
        <button onClick={(event) => {event.preventDefault(); sendHandler(formData)}}>Send</button>
        </form>
    ) 
} 

export default Form