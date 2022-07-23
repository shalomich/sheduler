import axios from "axios";
import React from "react";
import api from "../../api";
import { userUri } from "../../apiConfig";
import { UseAuthorizedContext } from "../Account";
import Loading from "../Loading";
import { IModelTable } from "../tables/ModelTable";

type TablePageType<T extends IModelTable> = {
    TableComponent: React.FC<{models: Array<T>}>,
    uri: string
}

const TablePage = <T extends IModelTable>(props : TablePageType<T>) => {
    
    const {uri, TableComponent} = props
    const[models, setModels] = React.useState<Array<T>>()

    const {authorizedData} = UseAuthorizedContext()

    React.useEffect(()=>{
        api(uri,{},authorizedData?.token)
            .then(responce => setModels(responce as Array<T>))
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
    else return <Loading/>
}

export default TablePage