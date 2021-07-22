import React, { Fragment } from "react";
import ShowInfo from "../HOCs/ShowInfo";
import { BaseInfoItem } from "./InfoItem";

const UserProfile : React.FC<{profile: any}> = ({profile}) => {
    
    const ProfileBlock = ShowInfo(BaseInfoItem)

    const {id : number, ...data} = profile

    return(
        <Fragment>
            <h1>Данные о сотруднике</h1>
            <div>
                <ProfileBlock model={data}/>
            </div>
        </Fragment>
    )
}

export default UserProfile