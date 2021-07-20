import React from "react";
import { Link } from "react-router-dom";
import api from "../../api";
import { selfProfileUri, userUri } from "../../apiConfig";
import { UseAuthorizedContext } from "../Account";
import Loading from "../Loading";
import UserProfile, { IUserProfile } from "../UserProfile";

const OtherProfilePage : React.FC<{match : any}> = ({match}) => {
    
    const[profile, setProfile] = React.useState<IUserProfile>();
    const {authorizedData} = UseAuthorizedContext()
    
    const userByIdUri = userUri + match.params.id
    const otherProfileUri = userByIdUri + "/profile"

    React.useEffect(() => {
        api(otherProfileUri,{method: 'GET'})
            .then(responce => setProfile(responce as IUserProfile))
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