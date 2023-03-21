import React from 'react';
import 'devextreme/data/odata/store';
import DataSource from 'devextreme/data/custom_store';
import DataGrid, {
  Column,
  SearchPanel,
  Pager,
  Paging,
  FilterRow,
  Lookup
} from 'devextreme-react/data-grid';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';

export default function Controllers() {
  return (
    <React.Fragment>
      <ShantiDataGrid
        title={'Контроллеры'}
        path={'/api/mcauth'}
      >
        <Column
          dataField={'key'}
          caption={'Ключ'}
          hidingPriority={8}
        />
        <Column
          dataField={'mac'}
          caption={'Мас адрес'}
          hidingPriority={8}
        />
        <Column
          dataField={'typeName'}
          caption={'Тип контроллера'}
          hidingPriority={6}
        />
      </ShantiDataGrid>     
    </React.Fragment>
)}