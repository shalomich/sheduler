import axios from "axios";
import React from "react";
import { userUri } from "../../apiConfig";
import { IModelTable } from "../tables/ModelTable";

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

    const addingPath : string = window.location.pathname + '/add'

    if (models)
        return (
        <div>
            <a href={addingPath}>
                <button>Добавить</button>
            </a>
            <TableComponent models={models}/>
        </div>)
    else return null
}

export default TablePage