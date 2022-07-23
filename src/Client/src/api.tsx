import React from "react";

export enum SuccesStatus {
    OK = 200,
    Created = 201,
    NoContent = 204
}

const api = (uri : string, options : any = {}, token: string | undefined = undefined , successStatus : SuccesStatus = SuccesStatus.OK) => {

    options.headers = {
        'Accept': 'application/json, text/plain',
        'Content-Type': 'application/json;charset=UTF-8'
    };

    if (token)
      options.headers.Authorization = 'Bearer ' + token
    
    options.body = JSON.stringify(options.body)
  
    return new Promise((resolve, reject) => {
      fetch(uri, options)
        .then(response => {
          if (response.status === successStatus)
            return resolve(response.json());
          else 
            return reject(response.json()); 
        });
    });
}

export default api