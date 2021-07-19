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
    SignOut: () => void
}

const AuthorizedContext = React.createContext<AuthorizedContextType>({
    authorizedData: undefined,
    SignIn: (token) => {},
    SignOut: () => {}
});

export const UseAuthorizedContext = () => React.useContext(AuthorizedContext);

const Account : React.FC = ({children}) => {
    
    const [token, setToken] = React.useState(localStorage.getItem('token') ?? NoToken)

    console.log(token);
    
    
    const IsAuthorized = () => token != NoToken 

    const SignIn = (token : string) => {
        localStorage.setItem('token',token)
        setToken(token)   
    }

    const SignOut = () => setToken(NoToken)

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
        <AuthorizedContext.Provider value={{SignIn, SignOut, authorizedData: GetAuthorizedData()}}>
            {children}
        </AuthorizedContext.Provider>
    )    
}

export default Account