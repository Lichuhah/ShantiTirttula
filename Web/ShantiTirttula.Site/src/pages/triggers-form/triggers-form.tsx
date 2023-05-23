import { Item, SimpleItem, IItemProps } from "devextreme-react/form";
import React from "react";
import { ShantiItemForm } from "../../components";
import ShantiDropDownTreeView from "../../components/shanti-drop-down-treeview/ShantiDropDownTreeView";
import ShantiSelectBox from "../../components/shanti-select-box/ShantiSelectBox";

export default function TriggersForm() {
    return (
        <React.Fragment>
          <ShantiItemForm title="Триггер: " colCount={2} path="/api/triggers">
              <SimpleItem
                  dataField={'sensorId'}
                  editorType={'dxTextBox'}
                  render={()=>{ return (
                      <ShantiDropDownTreeView
                          path="/api/mcauth/sensors/tree"
                          dataField="sensorId"
                          byKeyPath="/api/sensors/"
                      />
                  )}}
              />
            <Item
                dataField={'triggerValue'}
                editorType={'dxTextBox'}
                itemType={'simple'}
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
            <SimpleItem
                dataField={'deviceId'}
                editorType={'dxTextBox'}
                render={()=>{ return (
                    <ShantiDropDownTreeView
                        path="/api/mcauth/devices/tree"
                        dataField="deviceId"
                        byKeyPath="/api/devices/"
                    />
                )}}
            />

            <SimpleItem
                dataField={'Type'}
                editorType={'dxTextBox'}
                render={()=>{ return (
                    <ShantiSelectBox
                        path="/api/triggertypes"
                        dataField="Type"
                        byKeyPath="/api/triggertypes"
                    />
                )}}
            />
            </ShantiItemForm>    
        </React.Fragment>
    );
}