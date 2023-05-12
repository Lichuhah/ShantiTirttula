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
    text:'Выбрать',
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
    />,
    <Column
      dataField={'typeName'}
      caption={'Продукт'}
    />,
    <Column
      dataField={'producerType'}
      caption={'Режим управления'}
    />,
    <Column
        dataField={'lastDateTime'}
        caption={'Последнее обновление'}
        dataType={'datetime'}
        format={"yyyy-MM-dd HH:mm:ss"}
    />,
    <Column
        dataField={'isConnected'}
        caption={'Состояние'}
    />
  ];

  let grid:ShantiDataGrid = new ShantiDataGrid(
    { 
      title: 'Теплицы',
      path: '/api/auth', 
      children: columns,
      rowActions: rowActions,
      navigate: useNavigate(),
      allowDelete: false,
      allowEdit: false,
    })

  return (
    <React.Fragment>
      {grid.render()}  
    </React.Fragment>
)}