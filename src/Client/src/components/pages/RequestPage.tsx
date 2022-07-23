import axios from "axios";
import React, { Fragment } from "react";
import api from "../../api";
import { requestUri } from "../../apiConfig";
import ShowInfo from "../../HOCs/ShowInfo";
import { UseAuthorizedContext } from "../Account";
import { BaseInfoItem } from "../InfoItem";
import Loading from "../Loading";
import RequestActions from "../RequestActions";


const RequestPage : React.FC<{match : any}> = ({match}) => {
    
    const[request, setRequest] = React.useState<any>()

    const uri = requestUri + match.params.id + '/profile'

    const {authorizedData} = UseAuthorizedContext()
    
    React.useEffect(()=>{
        api(uri, {method:'GET'}, authorizedData?.token)
            .then(responce => setRequest(responce))
    },[])

    const RequestInfoBlock = ShowInfo(BaseInfoItem)

    if (request) {
        const {id, status, creatorId, ...data} = request

        Object.keys(data).forEach(key => {data[key] === null && delete data[key]} )
        return(
            <Fragment>
                <h2>Данные о заявке</h2>
                <div>
                    <RequestInfoBlock model={data}/>
                    <RequestActions requestActionData={{id,status,creatorId}} StatusChanged={newStatus => {
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