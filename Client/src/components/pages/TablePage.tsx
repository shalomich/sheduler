import axios from "axios";
import React from "react";
import { userUri } from "../../apiConfig";
import { IModelTable } from "../ModelTable";

type TablePageType<T extends IModelTable> = {
    TableComponent: React.FC<{models: Array<T>}>,
    uri: string
}

const TablePage = <T extends IModelTable>(props : TablePageType<T>) => {
    
    const {uri, TableComponent} = props
    const[models, setModels] = React.useState<Array<T>>()

    React.useEffect(()=>{
        axios.get(uri)
            .then(responce => setModels(responce.data))
    },[])

    if (models)
        return (
        <div>
            <TableComponent models={models}/>
        </div>)
    else return null
}

export default TablePage