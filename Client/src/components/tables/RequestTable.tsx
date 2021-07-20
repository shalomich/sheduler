import React from "react";
import ModelTable, { IModelTable } from "./ModelTable";

export interface IRequestTable extends IModelTable  {
    creatorName: string,
    type: string,
    sendingDate: Date,
    choosendDates: Array<Date>,
    dayQuantity: number,
    approvingName: string,
    status: string
} 

const RequestTable : React.FC<{models : Array<IRequestTable>}> = ({models}) => {

    const modelType : string = 'request'

    const headers : Array<string> = ['Заявитель', 'Тип заявки','Дата отправления на согласование','Даты по заявке',
    'Количество дней','Согласующий','Статус']
    
    return(
        <ModelTable models={models} modelType={modelType} headers={headers}/>
    )
}

export default RequestTable