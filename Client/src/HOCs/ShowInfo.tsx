import React,{Fragment} from 'react'
import {IInfoItem} from '../components/InfoItem'

const ShowInfo = (InfoItemComponent : React.FC<IInfoItem>) =>{
    const ItemList : React.FC<{model: object}> = ({model}) =>{
        return (
        <Fragment>
            {
                Object.entries(model).map(([propertyName, value]) => {
                    return <InfoItemComponent key={propertyName} propertyName={propertyName} value={value}/>
                })
            }
        </Fragment>
        )
    }

    return ItemList;
}

export default ShowInfo