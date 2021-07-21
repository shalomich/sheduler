import React from "react";

type CalendarType = {
    name : string,
    onValueChange: (name: string, value: any) => void
}
const Calendar : React.FC<CalendarType> = ({name, onValueChange}) => {
    
    return (
        <input type='date' name={name} onChange={(event) => onValueChange(name,[event.target.value])}/>
    )
}

export default Calendar