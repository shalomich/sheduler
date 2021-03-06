import { type } from "os";
import React, {Fragment} from "react";
import { Redirect } from "react-router-dom";
import { AuthPath, NoToken } from "../appConfig";

type AuthorizedDataType = {
    id: number,
    role: string,
    token: string
}

type AuthorizedContextType = {
    authorizedData: AuthorizedDataType | undefined
    SignIn: (token : string) => void,
    SignOut: () => void,
    IsAuthorized: () => boolean
}

const AuthorizedContext = React.createContext<AuthorizedContextType>({
    authorizedData: undefined,
    SignIn: (token) => {},
    SignOut: () => {},
    IsAuthorized: () => false
});

export const UseAuthorizedContext = () => React.useContext(AuthorizedContext);

const Account : React.FC = ({children}) => {
    
    const [token, setToken] = React.useState(localStorage.getItem('token') ?? NoToken)
 
    const IsAuthorized = () => token != NoToken 

    const SignIn = (token : string) => {
        localStorage.setItem('token',token)
        setToken(token)   
    }

    const SignOut = () => {
        localStorage.removeItem('token')
        setToken(NoToken)  
    } 

    const GetAuthorizedData = () => {
        if (IsAuthorized()) 
        {
            const [,payload,] = token.split('.')
            const {id,role} = JSON.parse(atob(payload))
            return {id,role,token} as AuthorizedDataType        
        }
        else return undefined
    }

    if (IsAuthorized() == false && window.location.pathname != AuthPath)
        window.location.href = AuthPath

    return (
        <AuthorizedContext.Provider value={{SignIn, SignOut, authorizedData: GetAuthorizedData(), IsAuthorized}}>
            {children}
        </AuthorizedContext.Provider>
    )    
}

export default Account