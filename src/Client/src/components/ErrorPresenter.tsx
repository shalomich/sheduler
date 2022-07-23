import React,{Fragment} from "react";

type ErrorPresenterContextType = {
    ShowErrors: (errors : any) => void
}

const ErrorPresenterContext = React.createContext<ErrorPresenterContextType>({
    ShowErrors : (errors) => {}
})

export const UseErrorContext = () => React.useContext(ErrorPresenterContext)

const ErrorPresenter : React.FC = ({children}) => {

    const [messages, setMessages] = React.useState<Array<string>>([])

    const ShowErrors = (errors: object) => setMessages(Object.values(errors).flat(1))
    
    return (
        <Fragment>
            <ul>
                {messages.map(message => <li>{message}</li>)}
            </ul>
            <ErrorPresenterContext.Provider value={{ShowErrors}}>
                {children}
            </ErrorPresenterContext.Provider>
        </Fragment>
    )
}

export default ErrorPresenter