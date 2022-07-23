import axios from "axios";
import React from "react";
import internal from "stream";
import { allowedStatus, approvedStatus, cancelledStatus, createdStatus, disallowedStatus, disapprovedStatus, requestUri, sentStatus, withdrawnStatus } from "../apiConfig";
import { DirectorRole, ManagerRole } from "../appConfig";
import { GetAccessOrDestroyFC } from "../HOCs/GetAccess";
import { UseAuthorizedContext } from "./Account";

type RequestActionsType = {
    requestActionData: {
        id : number,
        status : string,
        creatorId : number
    },
    StatusChanged : (newStatus : string) => void
}

const RequestActions : React.FC<RequestActionsType> = ({requestActionData, StatusChanged}) => {

    const {id, status, creatorId} = requestActionData
    const {authorizedData} = UseAuthorizedContext()
 
    const currentStatus = (status as string).toLowerCase()

    const ChangeStatus = (newStatus : string) => {
        
        const statusUri = `${requestUri}${id}/${newStatus}`

        axios.put(statusUri)
            .then(responce => StatusChanged(newStatus))
    }

    if (creatorId == authorizedData?.id)
        return <RequestSelfActions currentStatus={currentStatus} changeStatus={ChangeStatus}/>
    if (authorizedData?.role === DirectorRole)
        return <RequestOtherActions currentStatus={currentStatus} changeStatus={ChangeStatus}/> 
    else return null 
}

export default RequestActions

type RequestUserActionsType = {
    currentStatus : string,
    changeStatus : (nextStatus : string) => void
}

const CreateChangeStatusButton = (changeStatus : (nextStatus : string) => void) => {
    const BuildStatusButton = (status : string,text : string, ) => 
        <button onClick={() => changeStatus(status)}>{text}</button>
    return BuildStatusButton
}     
    
    

const RequestSelfActions : React.FC<RequestUserActionsType> = ({currentStatus, changeStatus}) => {
    
    const BuildButton = CreateChangeStatusButton(changeStatus)
    
    const SentButton = BuildButton(sentStatus, 'отправить на согласование')
    const WithdrawnButton = BuildButton(withdrawnStatus, 'отозвать с согласования')
    const CancelledButton = BuildButton(cancelledStatus, 'Отменить')

    const editPath = window.location.pathname + '/edit'

    switch(currentStatus) {
        case createdStatus :
        case withdrawnStatus : 
            return (
                <div>
                    {SentButton}
                    {CancelledButton}
                    <a href={editPath}>
                        <button>Редактировать</button>
                    </a>
                </div>
            )
        
        case sentStatus:
        case disapprovedStatus:
        case disallowedStatus:
            return (
                <div>
                    {WithdrawnButton}
                    {CancelledButton}
                </div>
            )
        case approvedStatus:
        case allowedStatus:
            return (
                <div>
                    {CancelledButton}
                </div>
            )
        case cancelledStatus:
            return null
        default: throw 'Uncorrect status'
    }
}

const RequestOtherActions : React.FC<RequestUserActionsType> = ({currentStatus, changeStatus}) => {
    
    const BuildButton = CreateChangeStatusButton(changeStatus)
    
    const ApprovedButton = BuildButton(approvedStatus, 'согласовать')
    const DisapprovedButton = BuildButton(disapprovedStatus, 'не согласовать')
    
    const AllowedButton = BuildButton(allowedStatus, 'утвердить')
    const DisallowedButton = BuildButton(disallowedStatus, 'не утвердить')
     
    switch(currentStatus) {
        case sentStatus:
            return (
                <div>
                    {ApprovedButton}
                    {DisapprovedButton}
                </div>
            )
        case approvedStatus:
            return (
                <div>
                    {AllowedButton}
                    {DisallowedButton}
                </div>
            )
        default : 
            return null
    }
}


