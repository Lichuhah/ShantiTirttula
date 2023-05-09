import React from 'react';
import 'devextreme/data/odata/store';
import DataGrid, {
  Column
} from 'devextreme-react/data-grid';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';
import { Link, useNavigate } from 'react-router-dom';

export default function Triggers() {
  let navigate = useNavigate();

  let rowActions = new Array(
    {             
      text:'Посмотреть данные',
      icon:'pin',
      onClick: (e)=>{
          navigate('/sensors/form?mode=edit&id='+ grid.GetSelectedItems()[0].id)
        }
      }            
    );

    let columns = [
        <Column
          dataField={'typeName'}
          caption={'Тип датчика'}
        />,
        <Column
          dataField={'number'}
          caption={'Порядковый номер'}
        />
    ];

    let grid:ShantiDataGrid = new ShantiDataGrid(
      { 
        title: 'Датчики',
        path: '/api/ap/sensor', 
        children: columns,
        rowActions: rowActions,
        navigate: navigate
      })

  return (
    <React.Fragment>
      {grid.render()}     
    </React.Fragment>
)}