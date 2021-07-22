import React, { Fragment } from "react";
 
type CalendarType = {
    name : string,
    value : Array<Date>,
    onValueChange: (name: string, value: any) => void
}

const Calendar : React.FC<CalendarType> = ({name, value, onValueChange}) => {
    
    const [dates, setDates] = React.useState(value === undefined ? [] : value)

    const ChangeDate = (newDate : Date) => {
        let newDates : Array<Date>

        const existingDate = dates.find(date => 
            date.toDateString() === newDate.toDateString()) 
        
        if (existingDate)
            newDates = dates.filter(date => date.toDateString() != existingDate.toDateString())
        else newDates =  [... dates, newDate]  
        
        onValueChange(name, newDates)
        setDates(newDates)
    }

    const minDate = new Date().toISOString().split("T")[0];

    return (
        <Fragment>
            <input type='date' id='calendar' min={minDate} name={name} onChange={(event) => ChangeDate(new Date(event.target.value))}/>
            <ul>
                {dates.map(date => <li>{date.toDateString()}</li>)}
            </ul>
        </Fragment>
    )
}

export default Calendar