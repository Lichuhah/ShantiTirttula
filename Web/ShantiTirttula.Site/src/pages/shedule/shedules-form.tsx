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
                editorOptions={{type: 'time'}}
                itemType={'simple'}
                label={{text:"Время начала"}}
            />
            <Item
                dataField={'endTime'}
                editorType={'dxDateBox'}
                editorOptions={{type: 'time'}}
                itemType={'simple'}
                label={{text:"Время окончания"}}
            />
            <Item
                dataField={'period'}
                //editorType={'dxTextBox'}
                itemType={'simple'}
                label={{text:"Периодичность"}}
            />
            <SimpleItem
                dataField={'startCommandId'}
                label={{text:"Начальная команда"}}
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
                label={{text:"Конечная команда"}}
                render={()=>{ return (
                    <ShantiSelectBox
                        path="/api/ap/commands"
                        dataField="endCommandId"
                        byKeyPath="/api/ap/commands"
                    />
                )}}
            />
              <Item
                  label={{text:"Дни недели"}}
                  itemType={"group"}
                  colCount={2}
                  items={[
                      {
                          editorType: 'dxCheckBox',
                          editorOptions: {text:"Понедельник"}
                      },
                      {
                          editorType: 'dxCheckBox',
                          editorOptions: {text:"Вторник"}
                      },
                      {
                          editorType: 'dxCheckBox',
                          editorOptions: {text:"Среда"}
                      },
                      {
                          editorType: 'dxCheckBox',
                          editorOptions: {text:"Четверг"}
                      },
                      {
                          editorType: 'dxCheckBox',
                          editorOptions: {text:"Пятница"}
                      },
                      {
                          editorType: 'dxCheckBox',
                          editorOptions: {text:"Суббота"}
                      },
                      {
                          editorType: 'dxCheckBox',
                          editorOptions: {text:"Воскресенье"}
                      },
                  ]}
              />
            </ShantiItemForm>    
        </React.Fragment>
    );
}