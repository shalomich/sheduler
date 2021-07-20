import React, { Fragment } from "react";
import ShowInfo from "../HOCs/ShowInfo";
import { BaseInfoItem } from "./InfoItem";

interface IModel {
    id: number
}
export interface IUserProfile {
    data: IModel,
    statistics : object
}
const UserProfile : React.FC<{profile: IUserProfile}> = ({profile}) => {
    
    const ProfileBlock = ShowInfo(BaseInfoItem)
    const StatisticsBlock = ShowInfo(BaseInfoItem)

    const {id : number, ...data} = profile.data

    return(
        <Fragment>
            <h1>Данные о сотруднике</h1>
            <div>
                <ProfileBlock model={data}/>
            </div>
            <h1>Статистика</h1>
            <div>
                <StatisticsBlock model={profile.statistics}/>
            </div>
        </Fragment>
    )
}

export default UserProfile