import { Chart } from "devextreme-react";
import { CommonSeriesSettings, Series } from "devextreme-react/chart";
import { Item, SimpleItem, IItemProps } from "devextreme-react/form";
import DataSource from "devextreme/data/data_source";
import React, {useRef} from "react";
import { ShantiApiGet } from "../../api/shantiajax";
import { ShantiItemForm } from "../../components";
export default function SensorsForm() {

    let enddate = new Date();
    let startdate = new Date();
    startdate.setDate(startdate.getDate()-1);

    function getUrl(){
        return `${process.env.REACT_APP_API_URL}/api/test/data-proc/` + new URLSearchParams(window.location.search).get("id") +
            '/bytime/'+startdate.toJSON()+'/'+enddate.toJSON();
    }
    function getDS(){
        return new DataSource({
            store: {
                type: 'odata',
                url: getUrl(),
            },
            paginate: false,
        });
    }

    let chartDataSource = getDS();

    let argAxis = {
        label: {
            format: "yyyy-MM-dd HH:mm:ss"
        }
    };

    let startCalender: any;
    let startCalendarOptions = {
        type: 'datetime',
        max: enddate,
        value: startdate,
        onValueChanged: (e)=>{
            startdate = e.value;
            endCalender.option('min', e.value);
            chartRender.current.instance.getDataSource().store()._requestDispatcher._url = getUrl();
            chartRender.current.instance.getDataSource().reload();

        },
        onContentReady: (e)=>{
            startCalender = e.component;
        }
    }

    let endCalender: any;
    let endCalendarOptions = {
        type: 'datetime',
        min: startdate,
        value: enddate,
        onValueChanged: (e)=>{
            enddate = e.value;
            startCalender.option('max', e.value);
            chartRender.current.instance.getDataSource().store()._requestDispatcher._url = getUrl();
            chartRender.current.instance.getDataSource().reload();
        },
        onContentReady: (e)=>{
            endCalender = e.component;
        }
    }

    let chartRender=useRef(null);
    let chart: any;
    return (
        <React.Fragment>
            <ShantiItemForm title="Датчик: " colCount={2} path="/api/sensors" >
            <Item
                dataField={'typeName'}
                editorType={'dxTextBox'}
                itemType={'simple'}
                label={{text:"Наименование"}}
            />
            <Item
                dataField={'number'}
                editorType={'dxTextBox'}
                itemType={'simple'}
                label={{text:"Порядковый номер"}}
            />
              <Item
                  editorType={'dxDateBox'}
                  itemType={'simple'}
                  label={{text:"Начальное время графика"}}
                  editorOptions={startCalendarOptions}
              />
              <Item
                  editorType={'dxDateBox'}
                  itemType={'simple'}
                  label={{text:"Конечное время графика"}}
                  editorOptions={endCalendarOptions}
              />
            <SimpleItem
                //editorType={'dxTextBox'}
                colSpan={2}
                render={()=>{ return (
                    <Chart
                        ref={chartRender}
                        title="Данные:"
                        dataSource = {chartDataSource}
                        argumentAxis = {argAxis}
                        palette={"Dark Moon"}
                        onInitialized={(e)=>{
                            chart=e.component
                        }}
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
            </ShantiItemForm>
        </React.Fragment>
    );
}