import React from "react";

type BinaryRadioGroupType = {
    name: string,
    value: boolean | undefined,
    onValueChange: (name: string, value: any) => void
}

const BinaryRadioGroup : React.FC<BinaryRadioGroupType> = ({name,value, onValueChange}) => {

    return (
        <div>
            <label>Да</label>
            <input id="yes" name={name} type='radio' defaultChecked={value === true} onClick={()=> onValueChange(name,true)}/>
            <label>Нет</label>
            <input id="no"name={name} type='radio' defaultChecked={value === false} onClick={()=> onValueChange(name,false)}/>
        </div>
    )
}

export default BinaryRadioGroup