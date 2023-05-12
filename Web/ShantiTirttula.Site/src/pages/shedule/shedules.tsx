import React from 'react';
import 'devextreme/data/odata/store';
import DataGrid, {
  Column
} from 'devextreme-react/data-grid';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';
import { Link, useNavigate } from 'react-router-dom';

export default function Shedules() {
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
          dataField={'startTime'}
          dataType={'datetime'}
          caption={'Время запуска'}
        />,
        <Column
          dataField={'endTime'}
          dataType={'datetime'}
        //   editorOptions={{
        //         dateSerializationFormat:'HH:mm:ss'
        //     }
        //   }
          caption={'Время окончания'}
        />
    ];

    let grid:ShantiDataGrid = new ShantiDataGrid(
      { 
        title: 'Датчики',
        path: '/api/ap/shedules', 
        children: columns,
        //rowActions: rowActions
        navigate: useNavigate(),
          allowDelete: false,
          allowEdit: false,
      })

  return (
    <React.Fragment>
      {grid.render()}     
    </React.Fragment>
)}