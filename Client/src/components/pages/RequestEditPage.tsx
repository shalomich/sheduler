import axios from "axios";
import { async } from "q";
import React from "react";
import { formUri, requestUri } from "../../apiConfig";
import EditForm from "../forms/EditForm";
import Loading from "../Loading";
import FormPage from "./FormPage";

const RequestEditPage : React.FC<{match : any}> = ({match}) => {
    
    const [requestType, setRequestType] = React.useState<string>()

    const requestByIdUri = requestUri + match.params.id

    React.useEffect(() => {
        const requestTypeUri = requestByIdUri  + '/type'
        axios.get(requestTypeUri)
            .then(response => setRequestType(response.data))
    },[])

    const requestFormUri = formUri + requestType
    const requestActionUri = `${requestByIdUri}?type=${requestType}`
    
    if (requestType)
        return <FormPage formUri={requestFormUri} actionUri={requestActionUri} FormComponent={EditForm}/>
    else return <Loading/>
}

export default RequestEditPage