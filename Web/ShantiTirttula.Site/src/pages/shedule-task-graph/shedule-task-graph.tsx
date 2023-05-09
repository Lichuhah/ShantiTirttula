import {Scheduler} from "devextreme-react";
import { Item, SimpleItem, IItemProps } from "devextreme-react/form";
import DataSource from "devextreme/data/data_source";
import React from "react";
import { ShantiApiGet } from "../../api/shantiajax";
import { ShantiItemForm } from "../../components";
export default function SheduleTaskGraph() {

    let shedulerDataSource = new DataSource({
        store: {
            type: 'odata',
            withCredentials: true,
            url: `${process.env.REACT_APP_API_URL}/api/ap/shedule-tasks`,
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
            <ShantiItemForm title="График: " colCount={1} path="/api/ap/shedule-tasks" >
                <SimpleItem
                    //dataField={'deviceId'}
                    //editorType={'dxTextBox'}
                    colSpan={1}
                    render={()=>{ return (
                        <Scheduler
                            dataSource={shedulerDataSource}
                            startDateExpr = {"startDateTime"}
                            textExpr = {"command.name"}
                        >
                        </Scheduler>
                    )}}
                />
            </ShantiItemForm>
        </React.Fragment>
    );
}