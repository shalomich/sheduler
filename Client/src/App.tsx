import React, {Fragment} from 'react';
import Account, {UseAuthorizedContext} from './components/Account';

const App : React.FC = ({children}) => {
  return (
    <Fragment>
      <Account>
        {children}
      </Account>
    </Fragment> 
  );
}

export default App;
