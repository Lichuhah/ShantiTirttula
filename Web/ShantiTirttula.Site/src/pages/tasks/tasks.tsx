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
import { ShantiApiPost } from '../../api/shantiajax';
import ShantiDataGrid from '../../components/shanti-data-grid/ShantiDataGrid';

export default function Task() {
  return (
    <React.Fragment>
      {/* <ShantiDataGrid
        title = {'Задачи'}
        path={'/api/mcauth'}
      >
        <Column
          dataField={'key'}
          width={190}
          caption={'Subject'}
          hidingPriority={8}
        />
        <Column
          dataField={'Task_Status'}
          caption={'Status'}
          hidingPriority={6}
        />
      </ShantiDataGrid>      */}
    </React.Fragment>
)}