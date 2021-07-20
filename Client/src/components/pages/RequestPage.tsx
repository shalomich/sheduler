import axios from "axios";
import React, { Fragment } from "react";
import { requestUri } from "../../apiConfig";
import ShowInfo from "../../HOCs/ShowInfo";
import { BaseInfoItem } from "../InfoItem";
import Loading from "../Loading";
import RequestActions from "../RequestActions";


const RequestPage : React.FC<{match : any}> = ({match}) => {
    
    const[request, setRequest] = React.useState<any>()

    const uri = requestUri + match.params.id
    
    React.useEffect(()=>{
        axios.get(uri)
            .then(responce => setRequest(responce.data))
    },[])

    const RequestInfoBlock = ShowInfo(BaseInfoItem)

    if (request) {
        const {id, ...data} = request

        Object.keys(data).forEach(key => {data[key] === null && delete data[key]} )
        return(
            <Fragment>
                <h1>Данные о заявке</h1>
                <div>
                    <RequestInfoBlock model={data}/>
                    <RequestActions request={request} StatusChanged={newStatus => {
                        const changedRequest = {...request} 
                        changedRequest.status = newStatus
                        setRequest(changedRequest) 
                    }}/>
                </div>
            </Fragment>
        )
    }
    else return <Loading/>
}

export default RequestPage