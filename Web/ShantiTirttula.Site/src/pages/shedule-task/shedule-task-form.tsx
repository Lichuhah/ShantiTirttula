import { Item, SimpleItem, IItemProps } from "devextreme-react/form";
import React from "react";
import { ShantiItemForm } from "../../components";
import ShantiDropDownTreeView from "../../components/shanti-drop-down-treeview/ShantiDropDownTreeView";
import ShantiSelectBox from "../../components/shanti-select-box/ShantiSelectBox";

export default function SheduleTaskForm() {
    return (
        <React.Fragment>
          <ShantiItemForm title="Создать разовую задачу: " colCount={3} path="/api/ap/shedule-tasks">
            <Item
                dataField={'startDateTime'}
                editorType={'dxDateBox'}
                editorOptions={{type: 'datetime', min: new Date()}}
                itemType={'simple'}
                label={{text:"Дата и время"}}
            />
            <SimpleItem
                dataField={'commandId'}
                label={{text:"Команда"}}
                render={()=>{ return (
                    <ShantiSelectBox
                        path="/api/ap/commands"
                        dataField="commandId"
                        byKeyPath="/api/ap/commands"
                    />
                )}}
            />
            </ShantiItemForm>    
        </React.Fragment>
    );
}