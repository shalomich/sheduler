import { type } from "os";
import React, {Fragment} from "react";

type AuthorizedDataType = {
    id: number,
    role: string,
    token: string
}

type AuthorizedContextType = {
    UpdateToken: (token : string) => void,
    authorizedData: AuthorizedDataType | undefined
}

const AuthorizedContext = React.createContext<AuthorizedContextType>({
    UpdateToken: (token) => {console.log(token)},
    authorizedData: undefined
});

export const UseAuthorizedContext = () => React.useContext(AuthorizedContext);

const Account : React.FC = ({children}) => {
    
    const [authorizedData, setAuthorizedData] = React.useState<AuthorizedDataType>();
    
    const UpdateToken = (token : string) => {
        if (token) {
            const [,payload,] = token.split('.')
            const {id,role} = JSON.parse(atob(payload))
            setAuthorizedData({id,role, token})
        }
    }
    
    return (
        <Fragment>
            <AuthorizedContext.Provider value={{UpdateToken, authorizedData}}>
                {children}
            </AuthorizedContext.Provider>
        </Fragment>
    )
}

export default Account