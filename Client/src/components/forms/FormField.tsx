import React, { ChangeEvent, FormEvent, Fragment } from "react"
import Select from '../forms/Select'

type FormFieldType = {
    name: string,
    value?: string,
    type: string,
    metadata: any | null,
    isRequired: boolean
    onValueChange: (name: string, value: any) => void
}

const FormField : React.FC<FormFieldType> = ({name, value, type, metadata, isRequired, onValueChange}) => { 
    
    const changeHandler = (event : any) => onValueChange(name,event.target.value)
    
    let attributes : any = {name : name, onChange : changeHandler}
    
    if (value)
        attributes.value = value
    
    if (isRequired)
        attributes.required = true 

    const inputAttributes = {...attributes, type : type}
    
    switch(type) {
        case "textarea": 
            return <textarea {...attributes}></textarea>
        case "select": 
            return <Select options={metadata.options} attributes={attributes} />
        default : 
            return <input {...inputAttributes}/>  
    } 
}

export default FormField