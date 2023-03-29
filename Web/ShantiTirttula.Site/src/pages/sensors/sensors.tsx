import React from 'react';
import 'devextreme/data/odata/store';
import DataGrid, {
  Column
} from 'devextreme-react/data-grid';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';

export default function Triggers() {
  return (
    <React.Fragment>
      <ShantiDataGrid
        title={'Датчики'}
        path={'/api/sensors'}
      >
        <Column
          dataField={'typeName'}
          caption={'Тип датчика'}
        />
        <Column
          dataField={'number'}
          caption={'Порядковый номер'}
        />
      </ShantiDataGrid>     
    </React.Fragment>
)}