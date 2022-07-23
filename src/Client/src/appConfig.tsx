import React from "react";

export const NoToken : string = 'no token'
export const AuthPath : string = '/login'
export const InitialPagePath : string = '/profile'

export const EmployeeRole = 'Employee'
export const AdminRole = 'Admin'
export const ManagerRole = 'Manager'
export const DirectorRole = 'Director'

export const Roles : Array<string> = [
    EmployeeRole,
    AdminRole,
    ManagerRole,
    DirectorRole
]

export const RolesWithoutEmployee : Array<string> = Roles.filter(role => role != EmployeeRole)