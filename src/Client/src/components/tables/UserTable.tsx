import React from "react";
import ModelTable, { IModelTable } from "./ModelTable";

export interface IUserTable extends IModelTable  {
    name: string,
    role: string,
    post : string
} 

const UserTable : React.FC<{models : Array<IUserTable>}> = ({models}) => {

    const modelType : string = 'user'

    const headers : Array<string> = ['ФИО', 'Роль','Должность']
    
    return(
        <ModelTable models={models} modelType={modelType} headers={headers}/>
    )
}

export default UserTable