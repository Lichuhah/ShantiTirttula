import React from 'react';
import 'devextreme/data/odata/store';
import DataGrid, {
  Column
} from 'devextreme-react/data-grid';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';
import { Link, useNavigate } from 'react-router-dom';

export default function SheduleTasks() {
//   let rowActions = new Array(
//     {             
//       text:'Посмотреть данные',
//       icon:'pin',
//       onClick: (e)=>{
//           document.location.href='/sensors/form?mode=edit&id='+ grid.GetSelectedItems()[0].id
//         }
//       }            
//     );

    let columns = [
        <Column
            dataField={'command.name'}
            caption={'Команда'}
        />,
        <Column
          dataField={'startDateTime'}
          dataType={'datetime'}
          caption={'Время'}
        />,
    ];

    let grid:ShantiDataGrid = new ShantiDataGrid(
      { 
        title: 'Запланированные задачи',
        path: '/api/ap/shedule-tasks', 
        children: columns,
        navigate: useNavigate(),
          allowDelete: false,
          allowEdit: false,
        //rowActions: rowActions
      })

  return (
    <React.Fragment>
      {grid.render()}     
    </React.Fragment>
)}