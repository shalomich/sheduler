import React from "react";
import { RolesWithoutEmployee } from "../appConfig";
import { GetAccessOrDestroyElement } from "../HOCs/GetAccess";
import { UseAuthorizedContext } from "./Account";

const Header : React.FC = () => {

    const {SignOut, IsAuthorized} = UseAuthorizedContext()
    const UserTablePageLink = GetAccessOrDestroyElement(RolesWithoutEmployee, 
        <a href='/user'><button>Пользователи</button></a>)
    
    if (IsAuthorized())
        return (
            <header>
                <div>
                    <h1>Планировщик</h1>
                    <a href='/profile'><button>Профиль</button></a>
                    <a href='/request'><button>Заявки</button></a>
                    <UserTablePageLink/>
                    <button onClick={SignOut}>Выйти из аккаунта</button>
                </div>
            </header>
        )
    
    return null
}

export default Header