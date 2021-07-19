import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import {BrowserRouter, Switch, Route} from 'react-router-dom'
import FormPage from './components/pages/FormPage';
import { loginFormUri, loginUri, selfFormUri, selfProfileUri, userFormUri, userUri } from './apiConfig';
import LoginForm from './components/forms/LoginForm';
import SelfProfilePage from './components/pages/SelfProfilePage';
import AddingForm from './components/forms/AddingForm';
import EditForm from './components/forms/EditForm';
 
ReactDOM.render(
    <BrowserRouter>
        <App>
            <Switch>
                <Route path='/login' component={() => <FormPage formUri={loginFormUri} actionUri={loginUri} FormComponent={LoginForm}/>}/>
                <Route exact path='/profile'/>
                <Route path='/profile/edit' component={() => <FormPage formUri={selfFormUri} actionUri={selfProfileUri} FormComponent={EditForm}/>} />
                <Route exact path='/users' />
                <Route path='/users/add'component={() => <FormPage formUri={userFormUri} actionUri={userUri} FormComponent={AddingForm}/>} />
                <Route exact path='/users/:id(\d*)' />
                <Route path='/users/:id/edit' render={({match}) => <FormPage formUri={userFormUri} actionUri={userUri} FormComponent={EditForm} match={match}/>} />
                <Route exact path='/requests' />
                <Route path='/requests/add' />
                <Route exact path='/requests/:id' />
                <Route path='/requests/:id/edit'/>    
            </Switch>
        </App>
    </BrowserRouter>
, document.getElementById('root'))



