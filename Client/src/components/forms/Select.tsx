import React from 'react'

export type Option = {
    text: string,
    value: string,
}

type SelectType = {
    attributes : any,
    options : Array<Option>
}

const Select : React.FC<SelectType> = ({attributes, options}) => {
    
    return (
        <select {...attributes} defaultValue="Выберите..." >
            <option disabled >Выберите...</option>
            {options?.map(option => <option key={option.value} value={option.value}>{option.text}</option>)}
        </select>
    )
}

export default Select

