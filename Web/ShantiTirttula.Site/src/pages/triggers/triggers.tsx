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
        title={'Триггеры'}
        path={'/api/triggers'}
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