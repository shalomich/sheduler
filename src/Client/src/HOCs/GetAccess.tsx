import React from "react";
import { Redirect } from "react-router-dom";
import { Roles } from "../appConfig";
import { UseAuthorizedContext } from "../components/Account";

export const GetAccessOrDestroyFC = (rolesWithAccess : Array<string>, Component : React.FC<any>) => {
    const TryDestroy : React.FC<any> = (...props) => 
        IsInRole(rolesWithAccess) === false ? null :  <Component {...props}/>
    console.log(IsInRole(rolesWithAccess));
    
    return TryDestroy
}

export const GetAccessOrDestroyElement = (rolesWithAccess : Array<string>, Element : JSX.Element) => {
    const TryDestroy : React.FC = () => 
        IsInRole(rolesWithAccess) == false ? null :  Element
    return TryDestroy
}

export const GetAccessOrBack = (rolesWithAccess : Array<string>, Component : React.FC<any>) => {
    const TryBack : React.FC<any> = (props) => {
        if (IsInRole(rolesWithAccess) == false) {
            window.history.back()
            return null
        }
        else return <Component {...props}/>
    }
    return TryBack
}
const IsInRole = (rolesWithAccess : Array<string>) => {
    const intersection : Array<string> = Roles
        .filter(role => rolesWithAccess
            .includes(role));
    
    if (intersection.length == 0)
            throw 'Uncorrect roles'
    
    const {authorizedData} = UseAuthorizedContext()

    return authorizedData && rolesWithAccess.includes(authorizedData.role) 
}