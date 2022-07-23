import axios from "axios";
import { async } from "q";
import React from "react";
import api from "../../api";
import { formUri, requestUri } from "../../apiConfig";
import { UseAuthorizedContext } from "../Account";
import EditForm from "../forms/EditForm";
import Loading from "../Loading";
import FormPage from "./FormPage";

const RequestEditPage : React.FC<{match : any}> = ({match}) => {
    
    const [requestType, setRequestType] = React.useState<string>()

    const requestByIdUri = requestUri + match.params.id

    const {authorizedData} = UseAuthorizedContext()

    React.useEffect(() => {
        const requestTypeUri = requestByIdUri  + '/type'
        api(requestTypeUri, {method:'GET'}, authorizedData?.token)
            .then(response => setRequestType(response as string))
    },[])

    const requestFormUri = formUri + requestType
    const requestActionUri = `${requestByIdUri}?type=${requestType}`
    
    if (requestType)
        return <FormPage formUri={requestFormUri} actionUri={requestActionUri} FormComponent={EditForm}/>
    else return <Loading/>
}

export default RequestEditPage