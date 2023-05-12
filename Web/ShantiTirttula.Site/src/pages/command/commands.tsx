import React from 'react';
import 'devextreme/data/odata/store';
import DataGrid, {
  Column
} from 'devextreme-react/data-grid';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';
import { Link, useNavigate } from 'react-router-dom';

export default function Commands() {
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
          dataField={'value'}
          caption={'Значение'}
        />,
        <Column
          dataField={'isPwm'}
          caption={'ШИМ'}
        />,
    ];

    let grid:ShantiDataGrid = new ShantiDataGrid(
      { 
        title: 'Команды',
        path: '/api/ap/commands', 
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