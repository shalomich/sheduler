import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import {BrowserRouter, Switch, Route} from 'react-router-dom'
import FormPage from './components/pages/FormPage';
import { loginFormUri, loginUri } from './apiConfig';
import LoginForm from './components/forms/LoginForm';
 
ReactDOM.render(
    <BrowserRouter>
        <App>
            <Switch>
                <Route path='/login' component={() => <FormPage formUri={loginFormUri} actionUri={loginUri} FormComponent={LoginForm}/>}/>
                <Route exact path='/profile' />
                <Route path='/profile/edit' />
                <Route exact path='/users' />
                <Route path='/users/add' />
                <Route exact path='/users/:id(\d*)' />
                <Route path='/users/:id/edit' />
                <Route exact path='/requests' />
                <Route path='/requests/add' />
                <Route exact path='/requests/:id' />
                <Route path='/requests/:id/edit'/>    
            </Switch>
        </App>
    </BrowserRouter>
, document.getElementById('root'))



