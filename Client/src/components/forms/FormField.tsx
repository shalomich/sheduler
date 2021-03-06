import React from "react"
import Select from '../forms/Select'
import BinaryRadioGroup from "./BinaryRadioGroup"
import Calendar from "./Calendar"

export type FormFieldTemplate = {
    name : string,
    type : string,
    isRequired : boolean,
    text : string,
    metadata : any
}

type FormFieldType = {
    template : FormFieldTemplate
    value?: any,
    onValueChange: (name: string, value: any) => void
}

const FormField : React.FC<FormFieldType> = ({template, value, onValueChange}) => { 
    
    const [fieldValue, setFieldValue] = React.useState<any>(value)

    const {name, type, isRequired, metadata} = template

    const changeHandler = (event : any) => {
        const value = event.target.value
        onValueChange(name,value)
        setFieldValue(value)
    } 
    let attributes : any = {name : name, onChange : changeHandler, value : fieldValue}
    
    if (isRequired)
        attributes.required = true 

    const inputAttributes = {...attributes, type : type}
    
    switch(type) {
        case "textarea": 
            return <textarea {...attributes}></textarea>
        case "select": 
            return <Select options={metadata} attributes={attributes} />
        case "radio":
            return <BinaryRadioGroup name={name} value={value} onValueChange={onValueChange}/>
        case "date":
            return <Calendar value={value} name={name} onValueChange={onValueChange}/>
        default : 
            return <input {...inputAttributes}/>  
    } 
}

export default FormField