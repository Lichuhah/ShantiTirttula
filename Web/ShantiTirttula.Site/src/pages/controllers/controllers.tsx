import React from 'react';
import 'devextreme/data/odata/store';
import DataGrid, {
  Column
} from 'devextreme-react/data-grid';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';
import { useNavigate } from 'react-router-dom';

export default function Controllers() {

  let rowActions = new Array(
  {             
    text:'Установить основной',
    icon:'pin',
    onClick: ()=>{
      document.dispatchEvent(new CustomEvent("selectedControllerChanged", { 
        detail: {
          value: grid.GetSelectedItems()[0]
        } 
      }));
    }            
  });

  let columns = [
    <Column
      dataField={'key'}
      caption={'Ключ'}
      hidingPriority={8}
    />,
    <Column
      dataField={'typeName'}
      caption={'Продукт'}
      hidingPriority={6}
    />,
    <Column
        dataField={'lastDateTime'}
        caption={'Последнее обновление'}
        hidingPriority={6}
        dataType={'datetime'}
        format={"yyyy-MM-dd HH:mm:ss"}
    />,
    <Column
        dataField={'isConnected'}
        caption={'Состояние'}
        hidingPriority={6}
    />
  ];

  let grid:ShantiDataGrid = new ShantiDataGrid(
    { 
      title: 'Теплицы',
      path: '/api/auth', 
      children: columns,
      rowActions: rowActions,
      navigate: useNavigate()
    })

  return (
    <React.Fragment>
      {grid.render()}  
    </React.Fragment>
)}