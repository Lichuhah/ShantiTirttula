import React from 'react';
import 'devextreme/data/odata/store';
import DataGrid, {
  Column
} from 'devextreme-react/data-grid';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';
import { useNavigate } from 'react-router-dom';

export default function Devices() {

  let columns = [
    <Column
      dataField={'typeName'}
      caption={'Тип'}
    />,
    <Column
      dataField={'isAvailable'}
      caption={'Доступность'}
    />,
    <Column
      dataField={'isPwm'}
      caption={'Аналоговое'}
    />
  ];

  let grid:ShantiDataGrid = new ShantiDataGrid(
    { 
      navigate: useNavigate(),
        allowDelete: false,
        allowEdit: false,
      title: 'Устройства',
      path: '/api/devices', 
      children: columns,
    })

  return (
    <React.Fragment>
      {grid.render()}  
    </React.Fragment>
)}