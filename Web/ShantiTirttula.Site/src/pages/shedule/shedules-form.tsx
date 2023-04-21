import { Item, SimpleItem, IItemProps } from "devextreme-react/form";
import React from "react";
import { ShantiItemForm } from "../../components";
import ShantiDropDownTreeView from "../../components/shanti-drop-down-treeview/ShantiDropDownTreeView";
import ShantiSelectBox from "../../components/shanti-select-box/ShantiSelectBox";

export default function ShedulesForm() {
    return (
        <React.Fragment>
          <ShantiItemForm title="Расписание: " colCount={3} path="/api/shedules">
            <Item
                dataField={'startTime'}
                editorType={'dxDateBox'}
                editorOptions={{type: 'datetime', min: new Date()}}
                itemType={'simple'}
            />
            <Item
                dataField={'endTime'}
                editorType={'dxDateBox'}
                editorOptions={{type: 'datetime'}}
                itemType={'simple'}
            />
            <Item
                dataField={'period'}
                //editorType={'dxTextBox'}
                itemType={'simple'}
            />
            <SimpleItem
                dataField={'startCommandId'}
                render={()=>{ return (
                    <ShantiSelectBox
                        path="/api/ap/commands"
                        dataField="startCommandId"
                        byKeyPath="/api/ap/commands"
                    />
                )}}
            />
            <SimpleItem
                dataField={'endCommandId'}
                editorType={'dxTextBox'}
                render={()=>{ return (
                    <ShantiSelectBox
                        path="/api/ap/commands"
                        dataField="endCommandId"
                        byKeyPath="/api/ap/commands"
                    />
                )}}
            />
            </ShantiItemForm>    
        </React.Fragment>
    );
}