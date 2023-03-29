import React from 'react';
import 'devextreme/data/odata/store';
import DataGrid, {
  Column
} from 'devextreme-react/data-grid';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';

export default function Devices() {

  let columns = [
    <Column
      dataField={'typeName'}
      caption={'Тип'}
    />,
    <Column
      dataField={'pin'}
      caption={'Номер пина'}
    />,
    <Column
      dataField={'isPwm'}
      caption={'Аналоговое'}
    />
  ];

  let grid:ShantiDataGrid = new ShantiDataGrid(
    { 
      title: 'Устройства',
      path: '/api/devices', 
      children: columns,
    })

  return (
    <React.Fragment>
      {grid.render()}  
    </React.Fragment>
)}