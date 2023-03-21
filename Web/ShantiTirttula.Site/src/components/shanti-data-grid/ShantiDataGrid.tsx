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
import { getTokenFromLocalStorage } from '../../api/auth';

interface ShantiDataGridProps {
    path: string,
    title: string,
    children: any[]
}

function isNotEmpty(value) {
    return value !== undefined && value !== null && value !== '';
}

class ShantiDataGrid extends React.Component<ShantiDataGridProps> {

    path: string;
    title: string;
    dataSource: DataSource;

    constructor(props:ShantiDataGridProps){
        super(props);
        this.path = props.path;
        this.title = props.title;
        this.dataSource = this.getDataSource(props);
    }

    getDataSource(props){
        return new DataSource({
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
                if (i in loadOptions && isNotEmpty(loadOptions[i])) { params += `${i}=${JSON.stringify(loadOptions[i])}&`; }
              });
              params = params.slice(0, -1);
              return fetch(`${process.env.REACT_APP_API_URL}${props.path}${params}`,{
                method: 'GET',
                headers: {
                  "Accept": "*/*",
                  "Content-Type": "application/json",
                  "Authorization": "Bearer " + getTokenFromLocalStorage()
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
    }

    render(): React.ReactNode {
        return (
            <React.Fragment>
              <h2 className={'content-block'}>{this.title}</h2>
        
                <DataGrid
                className={'dx-card wide-card'}
                dataSource={this.dataSource as DataSource}
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

                    {this.props.children.map((col, i) => {       
                        return (col) 
                    })}

                </DataGrid>
            </React.Fragment>
        )
    }
}

export default ShantiDataGrid;
