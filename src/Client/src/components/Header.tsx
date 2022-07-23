import React, { Fragment } from "react";
import { RolesWithoutEmployee } from "../appConfig";
import { GetAccessOrDestroyElement } from "../HOCs/GetAccess";
import { UseAuthorizedContext } from "./Account";

const Header : React.FC = () => {

    const {SignOut, IsAuthorized} = UseAuthorizedContext()
    const UserTablePageLink = GetAccessOrDestroyElement(RolesWithoutEmployee, 
        <Fragment><a href='/user'>Пользователи</a> | </Fragment>)
    
    if (IsAuthorized())
        return (

            <header>
                <h1>Планировщик</h1>
                <nav>
                    <a href='/profile'>Профиль</a> | 
                    <a href='/request'>Заявки</a> | 
                    <UserTablePageLink/>
                    <a onClick={SignOut} href='/login'>Выйти из аккаунта</a> 
                </nav>
            </header>
        )
    
    return null
}

export default Header