import React from "react";
import { Link } from "react-router-dom";
import api from "../../api";
import { selfProfileUri, userUri } from "../../apiConfig";
import { UseAuthorizedContext } from "../Account";
import Loading from "../Loading";
import UserProfile from "../UserProfile";

const OtherProfilePage : React.FC<{match : any}> = ({match}) => {
    
    const[profile, setProfile] = React.useState<any>();
    const {authorizedData} = UseAuthorizedContext()
    
    const userByIdUri = userUri + match.params.id
    const otherProfileUri = userByIdUri + "/profile"

    React.useEffect(() => {
        api(otherProfileUri,{method: 'GET'}, authorizedData?.token)
            .then(responce => setProfile(responce))
    },[])

    const userByIdEditPath = window.location.href + '/edit'

    if (profile)
        return(
            <div>
                <UserProfile profile={profile}/>
                <a href={userByIdEditPath}>
                    <button>Редактировать</button>
                </a>
            </div>
        ) 
    else return <Loading/>
}

export default OtherProfilePage