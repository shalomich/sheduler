import React, {Fragment} from "react";

export interface IInfoItem {
    propertyName:string,
    value:any
}

export const BaseInfoItem : React.FC<IInfoItem> = ({propertyName,value}) => {  
  return (
    <Fragment>
        <b>{propertyName}</b><br/>
        <span>{value?.toString()}</span><br/>
    </Fragment>
  ) 
}