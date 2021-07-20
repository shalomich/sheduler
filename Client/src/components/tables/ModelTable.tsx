import React from "react";

export interface IModelTable {
    id: number
}

type ModelTableType = {
    modelType: string
    models: Array<IModelTable>,
    headers: Array<string>
}

const ModelTable : React.FC<ModelTableType> = ({modelType, models, headers}) => {
    return(
        <table>
            <tr>
                <th>Id</th>
                {headers.map(header => <th>{header}</th>)}
            </tr>
            {models.map(model => {
                const {id, ...data} = model
                console.log(data);
                
                const modelPath = `${modelType}/${id}` 
                return (
                    <tr>
                        <td>
                            <a href={modelPath}>{id}</a>
                        </td>
                        {Object.values(data).map(value => <td>{value}</td>)}
                    </tr>
                )
            })}
        </table>
    )
}

export default ModelTable