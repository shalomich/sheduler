import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import {BrowserRouter, Switch, Route} from 'react-router-dom'
import FormPage from './components/pages/FormPage';
import { loginFormUri, loginUri, requestUri, selfFormUri, selfProfileUri, userFormUri, userUri } from './apiConfig';
import LoginForm from './components/forms/LoginForm';
import SelfProfilePage from './components/pages/SelfProfilePage';
import AddingForm from './components/forms/AddingForm';
import EditForm from './components/forms/EditForm';
import OtherProfilePage from './components/pages/OtherProfilePage';
import TablePage from './components/pages/TablePage';
import UserTable, { IUserTable } from './components/tables/UserTable';
import RequestTable from './components/tables/RequestTable';
import RequestPage from './components/pages/RequestPage';
import { GetAccessOrBack } from './HOCs/GetAccess';
import { AdminRole, RolesWithoutEmployee } from './appConfig';
import RequestAddingPage from './components/pages/RequestAddingPage';
import RequestEditPage from './components/pages/RequestEditPage';

const UserTablePage = GetAccessOrBack(RolesWithoutEmployee,TablePage)
const UserAddingPage = GetAccessOrBack([AdminRole],FormPage)
const UserPage = GetAccessOrBack(RolesWithoutEmployee,OtherProfilePage)
const UserEditingPage = GetAccessOrBack([AdminRole],FormPage)


ReactDOM.render(
    <BrowserRouter>
        <App>
            <Switch>
                <Route path='/login' component={() => <FormPage formUri={loginFormUri} actionUri={loginUri} FormComponent={LoginForm}/>}/>
                <Route exact path='/profile' component={SelfProfilePage}/>
                <Route path='/profile/edit' component={() => <FormPage formUri={selfFormUri} actionUri={selfProfileUri} FormComponent={EditForm}/>} />
                <Route exact path='/user' component={() => <UserTablePage uri={userUri} TableComponent={UserTable}/>}/>
                <Route path='/user/add'component={() => <UserAddingPage formUri={userFormUri} actionUri={userUri} FormComponent={AddingForm}/>} />
                <Route exact path='/user/:id(\d*)' render={({match}) => <UserPage match={match}/>} />
                <Route path='/user/:id/edit' render={({match}) => <UserEditingPage formUri={userFormUri} actionUri={userUri} FormComponent={EditForm} match={match}/>} />
                <Route exact path='/request' component={() => <TablePage uri={requestUri} TableComponent={RequestTable}/>} />
                <Route path='/request/add' component={RequestAddingPage} />
                <Route exact path='/request/:id' render={({match}) => <RequestPage match={match}/>}/>
                <Route path='/request/:id/edit' render={({match}) => <RequestEditPage match={match}/>}/>    
            </Switch>
        </App>
    </BrowserRouter>
, document.getElementById('root'))



