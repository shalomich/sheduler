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
import OtherProfilePage from './components/pages/OtherProfilePage';
 
ReactDOM.render(
    <BrowserRouter>
        <App>
            <Switch>
                <Route path='/login' component={() => <FormPage formUri={loginFormUri} actionUri={loginUri} FormComponent={LoginForm}/>}/>
                <Route exact path='/profile'/>
                <Route path='/profile/edit' component={() => <FormPage formUri={selfFormUri} actionUri={selfProfileUri} FormComponent={EditForm}/>} />
                <Route exact path='/user' />
                <Route path='/user/add'component={() => <FormPage formUri={userFormUri} actionUri={userUri} FormComponent={AddingForm}/>} />
                <Route exact path='/user/:id(\d*)' render={({match}) => <OtherProfilePage match={match}/>} />
                <Route path='/user/:id/edit' render={({match}) => <FormPage formUri={userFormUri} actionUri={userUri} FormComponent={EditForm} match={match}/>} />
                <Route exact path='/requests' />
                <Route path='/request/add' />
                <Route exact path='/request/:id' />
                <Route path='/request/:id/edit'/>    
            </Switch>
        </App>
    </BrowserRouter>
, document.getElementById('root'))



