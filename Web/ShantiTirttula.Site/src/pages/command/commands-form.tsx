import { Chart } from "devextreme-react";
import { CommonSeriesSettings, Series } from "devextreme-react/chart";
import { Item, SimpleItem, IItemProps } from "devextreme-react/form";
import DataSource from "devextreme/data/data_source";
import React from "react";
import { ShantiApiGet } from "../../api/shantiajax";
import { ShantiItemForm } from "../../components";
import ShantiDropDownTreeView from "../../components/shanti-drop-down-treeview/ShantiDropDownTreeView";
import ShantiSelectBox from "../../components/shanti-select-box/ShantiSelectBox";
export default function CommandsForm() {

    return (
        <React.Fragment>
          <ShantiItemForm title="Команда: " colCount={2} path="/api/commands" >
            <Item
                dataField={'name'}
                editorType={'dxTextBox'}
                itemType={'simple'}
            />
            <Item
                dataField={'value'}
                editorType={'dxTextBox'}
                itemType={'simple'}
            />
            <SimpleItem
                dataField={'deviceId'}
                editorType={'dxTextBox'}
                render={()=>{ return (
                    <ShantiSelectBox
                        path="/api/devices"
                        dataField="deviceId"
                        byKeyPath="/api/devices"
                        displayExpr="typeName"
                    />
                )}}
            />
            </ShantiItemForm>    
        </React.Fragment>
    );
}