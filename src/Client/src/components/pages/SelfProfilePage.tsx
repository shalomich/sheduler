import React from "react";
import { Link } from "react-router-dom";
import api from "../../api";
import { selfProfileUri } from "../../apiConfig";
import { UseAuthorizedContext } from "../Account";
import Loading from "../Loading";
import UserProfile from "../UserProfile";

const SelfProfilePage : React.FC = () => {
    
    const[profile, setProfile] = React.useState<any>();
    const {authorizedData} = UseAuthorizedContext() 

    React.useEffect(() => {
        api(selfProfileUri,{method: 'GET'},authorizedData?.token)
            .then(responce => setProfile(responce))
    })
    
    if (profile)
        return(
            <div>
                <UserProfile profile={profile}/>
                <Link to='profile/edit'>
                    <button>Редактировать</button>
                </Link>
            </div>
        ) 
    else return <Loading/>
}

export default SelfProfilePage