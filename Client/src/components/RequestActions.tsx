import axios from "axios";
import React from "react";
import { requestUri } from "../apiConfig";
import { DirectorRole, ManagerRole } from "../appConfig";
import { GetAccessOrDestroyFC } from "../HOCs/GetAccess";
import { UseAuthorizedContext } from "./Account";

type RequestActionsType = {
    request: any,
    StatusChanged : (newStatus : string) => void
}

const RequestActions : React.FC<RequestActionsType> = ({request, StatusChanged}) => {

    const {id, status, creatorId} = request
    const {authorizedData} = UseAuthorizedContext()

    

    const currentStatus = (status as string).toLowerCase()

    const ChangeStatus = (newStatus : string) => {
        
        const statusUri = `${requestUri}${id}/${newStatus}`

        axios.put(statusUri)
            .then(responce => StatusChanged(newStatus))
    }
    
    const RequestManagerOrDirectorActions = GetAccessOrDestroyFC([ManagerRole,DirectorRole], RequestOtherActions)

    if (creatorId == authorizedData?.id)
        return <RequestSelfActions currentStatus={currentStatus} changeStatus={ChangeStatus}/>
    else return <RequestManagerOrDirectorActions currentStatus={currentStatus} changeStatus={ChangeStatus}/>  
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
    
    const SentButton = BuildButton('sent', 'отправить на согласование')
    const WithdrawnButton = BuildButton('withdrawn', 'отозвать с согласования')
    const CancelledButton = BuildButton('cancelled', 'Отменить')

    const editPath = window.location.pathname + '/edit'

    switch(currentStatus) {
        case 'created' :
        case 'withdrawn' : 
            return (
                <div>
                    {SentButton}
                    {CancelledButton}
                    <a href={editPath}>
                        <button>Редактировать</button>
                    </a>
                </div>
            )
        
        case 'sent':
        case 'disapproved':
        case 'disallowed':
            return (
                <div>
                    {WithdrawnButton}
                    {CancelledButton}
                </div>
            )
        case 'approved':
        case 'allowed':
            return (
                <div>
                    {CancelledButton}
                </div>
            )
        case 'cancelled':
            return null
        default: throw 'Uncorrect status'
    }
}

const RequestOtherActions : React.FC<RequestUserActionsType> = ({currentStatus, changeStatus}) => {
    
    const BuildButton = CreateChangeStatusButton(changeStatus)
    
    const ApprovedButton = BuildButton('approved', 'согласовать')
    const DisapprovedButton = BuildButton('disapproved', 'не согласовать')
    
    const AllowedButton = BuildButton('allowed', 'утвердить')
    const DisallowedButton = BuildButton('disallowed', 'не утвердить')
     
    const editPath = window.location.pathname + '/edit'

    switch(currentStatus) {
        case 'sent':
            return (
                <div>
                    {ApprovedButton}
                    {DisapprovedButton}
                    <a href={editPath}>
                        <button>Редактировать</button>
                    </a>
                </div>
            )
        case 'approved':
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


