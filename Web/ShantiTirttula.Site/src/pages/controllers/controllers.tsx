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
    text:'Установить основным',
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
      dataField={'mac'}
      caption={'Мас адрес'}
      hidingPriority={8}
    />,
    <Column
      dataField={'typeName'}
      caption={'Тип контроллера'}
      hidingPriority={6}
    />
  ];

  let grid:ShantiDataGrid = new ShantiDataGrid(
    { 
      title: 'Контроллеры',
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