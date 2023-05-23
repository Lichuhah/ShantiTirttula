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
          allowDelete = {true}
        allowEdit = {true}
        title={'Триггеры'}
        path={'/api/triggers'}
        navigate ={useNavigate()}
      >
        <Column
          dataField={'sensorName'}
          caption={'Датчик'}
        /><Column
          dataField={'typeName'}
          caption={'Условие'}
      /><Column
          dataField={'triggerValue'}
          caption={'Значение'}
      /><Column
          dataField={'sensorUnit'}
          caption={'Единица'}
      /><Column
          dataField={'command.name'}
          caption={'Команда'}
      /><Column
          dataField={'isAutonomy'}
          caption={'Автономный'}
      />
      </ShantiDataGrid>     
    </React.Fragment>
)}