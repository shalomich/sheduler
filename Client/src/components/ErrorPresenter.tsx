import React,{Fragment} from "react";

type ErrorPresenterContextType = {
    SetErrors: (errors : Array<string>) => void
}

const ErrorPresenterContext = React.createContext<ErrorPresenterContextType>({
    SetErrors : (errors) => {}
})

export const UseErrorContext = () => React.useContext(ErrorPresenterContext)

const ErrorPresenter : React.FC = ({children}) => {

    const [errors, SetErrors] = React.useState<Array<string>>([])

    return (
        <Fragment>
            {errors.map(error => <div>{error}</div>)}
            <ErrorPresenterContext.Provider value={{SetErrors}}>
                {children}
            </ErrorPresenterContext.Provider>
        </Fragment>
    )
}

export default ErrorPresenter