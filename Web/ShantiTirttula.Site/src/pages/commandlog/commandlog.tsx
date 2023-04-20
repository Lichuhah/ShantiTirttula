import React from 'react';
import 'devextreme/data/odata/store';
import DataGrid, {
  Column
} from 'devextreme-react/data-grid';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';
import { useNavigate } from 'react-router-dom';

export default function CommandLog() {

  let columns = [
    <Column
      dataField={'sensorTypeName'}
      caption={'Тип датчика'}
    />,
    <Column
      dataField={'triggerTypeName'}
      caption={'Тип триггера'}
    />,
    <Column
      dataField={'deviceTypeName'}
      caption={'Тип устройства'}
    />,
    <Column
      dataField={'value'}
      caption={'Выставленное значение'}
    />,
    <Column
      dataField={'dateType'}
      caption={'Дата'}
      dataType={"date"}
    />,
  ];

  let grid:ShantiDataGrid = new ShantiDataGrid(
    { 
      title: 'Команды',
      path: '/api/commandlog', 
      children: columns,
      navigate: useNavigate()
    })

  return (
    <React.Fragment>
      {grid.render()}  
    </React.Fragment>
)}