import React, {Fragment} from 'react';
import Account, {UseAuthorizedContext} from './components/Account';
import Header from './components/Header';

const App : React.FC = ({children}) => {
  return (
    <Fragment>
      <Account>
        <Header/>
        {children}
      </Account>
    </Fragment> 
  );
}

export default App;
