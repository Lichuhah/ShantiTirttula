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

export default function Task() {
  return (
    <React.Fragment>
      <h2 className={'content-block'}>Tasks</h2>

      <DataGrid
        className={'dx-card wide-card'}
        dataSource={dataSource2 as DataSource}
        showBorders={false}
        focusedRowEnabled={true}
        defaultFocusedRowIndex={0}
        columnAutoWidth={true}
        columnHidingEnabled={true}
      >
        <Paging defaultPageSize={10} />
        <Pager showPageSizeSelector={true} showInfo={true} />
        <FilterRow visible={true} />
        <SearchPanel visible={true} highlightCaseSensitive={true} />
        <Column dataField={'Task_ID'} width={90} hidingPriority={2} />
        <Column
          dataField={'login'}
          width={190}
          caption={'Subject'}
          hidingPriority={8}
        />
        <Column
          dataField={'Task_Status'}
          caption={'Status'}
          hidingPriority={6}
        />
        <Column
          dataField={'Task_Priority'}
          caption={'Priority'}
          hidingPriority={5}
        >
          <Lookup
            dataSource={priorities}
            valueExpr={'value'}
            displayExpr={'name'}
          />
        </Column>
        <Column
          dataField={'ResponsibleEmployee.Employee_Full_Name'}
          caption={'Assigned To'}
          allowSorting={false}
          hidingPriority={7}
        />
        <Column
          dataField={'Task_Start_Date'}
          caption={'Start Date'}
          dataType={'date'}
          hidingPriority={3}
        />
        <Column
          dataField={'Task_Due_Date'}
          caption={'Due Date'}
          dataType={'date'}
          hidingPriority={4}
        />
        <Column
          dataField={'Task_Priority'}
          caption={'Priority'}
          name={'Priority'}
          hidingPriority={1}
        />
        <Column
          dataField={'Task_Completion'}
          caption={'Completion'}
          hidingPriority={0}
        />
      </DataGrid>
    </React.Fragment>
)}

function isNotEmpty(value) {
  return value !== undefined && value !== null && value !== '';
}

const dataSource2 = new DataSource({
  key: 'id',
  load(loadOptions) {
    let params = '?';
    [
      'filter',
      'group',
      'groupSummary',
      'parentIds',
      'requireGroupCount',
                            'requireTotalCount',
                            'searchExpr',
                            'searchOperation',
                            'searchValue',
                            'select',
                            'sort',
                            'skip',
                            'take',
                            'totalSummary',
                            'userData'
    ].forEach((i) => {
      if (i in loadOptions && isNotEmpty(loadOptions[i])) { console.log('aaa'); params += `${i}=${JSON.stringify(loadOptions[i])}&`; }
    });
    console.log(loadOptions);
    params = params.slice(0, -1);
    return fetch(`${process.env.REACT_APP_API_URL}api/users${params}`,{
      method: 'GET',
      headers: {
        "Accept": "*/*",
        "Content-Type": "application/json"
      }})
      .then((response) => response.json())
      .then((data) => ({
        data: data.data.data,
        totalCount: data.totalCount,
        summary: data.summary,
        groupCount: data.groupCount,
      }))
      .catch(() => { throw new Error('Data Loading Error'); });
  },
});

const dataSource = {
  store: {
    type: 'odata',
    key: 'Task_ID',
    url: 'https://js.devexpress.com/Demos/DevAV/odata/Tasks'
  },
  expand: 'ResponsibleEmployee',
  select: [
    'Task_ID',
    'Task_Subject',
    'Task_Start_Date',
    'Task_Due_Date',
    'Task_Status',
    'Task_Priority',
    'Task_Completion',
    'ResponsibleEmployee/Employee_Full_Name'
  ]
};

const priorities = [
  { name: 'High', value: 4 },
  { name: 'Urgent', value: 3 },
  { name: 'Normal', value: 2 },
  { name: 'Low', value: 1 }
];
