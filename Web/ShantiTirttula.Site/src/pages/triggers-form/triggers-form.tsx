import { Item, SimpleItem } from "devextreme-react/form";
import React from "react";
import { ShantiItemForm } from "../../components";
import ShantiDropDownTreeView from "../../components/shanti-drop-down-treeview/ShantiDropDownTreeView";

function renderDeviceDrop() {
    return (
        <ShantiDropDownTreeView
            path="/api/mcauth/devices/tree"
            dataField="deviceId"
        />
    );
}

export default function TriggersForm() {
    return (
        <React.Fragment>
          <ShantiItemForm title="Триггер: " colCount={3}>
            <Item
                dataField={'triggerValue'}
                editorType={'dxTextBox'}
                itemType={'simple'}
            />
            <Item
                dataField={'deviceValue'}
                editorType={'dxTextBox'}
                itemType={'simple'}
            />
            <SimpleItem
                dataField={'deviceId'}
                editorType={'dxTextBox'}
                render={renderDeviceDrop}
            />
            </ShantiItemForm>    
        </React.Fragment>
    );
}