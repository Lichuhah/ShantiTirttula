import { Chart } from "devextreme-react";
import { CommonSeriesSettings, Series } from "devextreme-react/chart";
import { Item, SimpleItem, IItemProps } from "devextreme-react/form";
import DataSource from "devextreme/data/data_source";
import React from "react";
import { ShantiApiGet } from "../../api/shantiajax";
import { ShantiItemForm } from "../../components";
import ShantiDropDownTreeView from "../../components/shanti-drop-down-treeview/ShantiDropDownTreeView";
import ShantiSelectBox from "../../components/shanti-select-box/ShantiSelectBox";
export default function SensorsForm() {

    let chartDataSource = new DataSource({
        store: {
            type: 'odata',
            url: `${process.env.REACT_APP_API_URL}/api/test/data-proc/` + new URLSearchParams(window.location.search).get("id"),
        },
        paginate: false,
    })

    let argAxis = {
        label: {
            format: "yyyy-MM-dd HH:mm:ss"
        }
    };

    return (
        <React.Fragment>
          <ShantiItemForm title="Датчик: " colCount={2} path="/api/sensors" >
            <Item
                dataField={'typeName'}
                editorType={'dxTextBox'}
                itemType={'simple'}
            />
            <Item
                dataField={'number'}
                editorType={'dxTextBox'}
                itemType={'simple'}
            />
            <SimpleItem
                //dataField={'deviceId'}
                //editorType={'dxTextBox'}
                colSpan={2}
                render={()=>{ return (
                    <Chart
                        title="Данные:"
                        dataSource = {chartDataSource}
                        argumentAxis = {argAxis}
                        palette={"Dark Moon"}
                    >
                        <Series
                            name="Temp."
                            argumentField="dateTime"
                            valueField="value"
                            type="line"
                            showInLegend={false}
                        />
                    </Chart>
                )}}
            />
            {/* <SimpleItem
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
            />  */}
            </ShantiItemForm>    
        </React.Fragment>
    );
}