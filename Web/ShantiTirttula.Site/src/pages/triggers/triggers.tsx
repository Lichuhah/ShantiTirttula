import React from 'react';
import 'devextreme/data/odata/store';
import DataGrid, {
  Column
} from 'devextreme-react/data-grid';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';
import { useNavigate } from 'react-router-dom';

export default function Triggers() {
  return (
    <React.Fragment>
      <ShantiDataGrid
          allowDelete = {false}
        allowEdit = {false}
        title={'Триггеры'}
        path={'/api/triggers'}
        navigate ={useNavigate()}
      >
        <Column
          dataField={'deviceValue'}
          caption={'Ключ'}
          hidingPriority={8}
        />
        <Column
          dataField={'typeName'}
          caption={'Мас адрес'}
          hidingPriority={8}
        />
        <Column
          dataField={'triggerValue'}
          caption={'Тип контроллера'}
          hidingPriority={6}
        />
      </ShantiDataGrid>     
    </React.Fragment>
)}