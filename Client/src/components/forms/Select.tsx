import React from 'react'

export type Option = {
    text: string,
    value: string,
    isRequired : boolean
}

interface ISelect {
    attributes : any,
    options : Array<Option>
}

interface IMultipleSelect extends ISelect {
    onValueChange : (values : Array<string>) => void 
}

const Select : React.FC<ISelect> = ({attributes, options}) => {
    return (
        <select {...attributes} defaultValue="Выберите..." >
            <option disabled >Выберите...</option>
            {options.map(option => <option key={option.value} value={option.value}>{option.text}</option>)}
        </select>
    )
}

export default Select

