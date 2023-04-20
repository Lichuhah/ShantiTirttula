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
        navigate = {useNavigate()}
        title={'Значения датчиков'}
        path={'/api/sensordata'}
      >
        <Column
          dataField={'sensorId'}
          caption={'id сенсора'}
        />
        <Column
          dataField={'value'}
          caption={'Значение'}
        />
      </ShantiDataGrid>     
    </React.Fragment>
)}