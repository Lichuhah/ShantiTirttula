import React from 'react';
import 'devextreme/data/odata/store';
import DataSource from 'devextreme/data/custom_store';
import DataGrid, {
  Column,
  SearchPanel,
  Pager,
  Paging,
  FilterRow,
  Lookup,
  Item,
  Toolbar,
  Selection
} from 'devextreme-react/data-grid';
import { getTokenFromLocalStorage } from '../../api/auth';
import Button from 'devextreme-react/button';
import { Link } from 'react-router-dom';
import { Menu } from 'devextreme-react';
import { ShantiApiDelete } from '../../api/shantiajax';

interface ShantiDataGridProps {
    path: string,
    title: string,
    rowActions?: any,
    children: any,
    navigate: any,
}

function isNotEmpty(value) {
    return value !== undefined && value !== null && value !== '';
}

class ShantiDataGrid extends React.PureComponent<ShantiDataGridProps> {

    path: string;
    title: string;
    dataSource: DataSource;
    dataGrid : any;
    columns: any[];

    constructor(props:ShantiDataGridProps){
        super(props);
        this.path = props.path;
        this.title = props.title;
        this.dataGrid = null;
        this.dataSource = this.getDataSource(props);
        this.refreshDataGrid = this.refreshDataGrid.bind(this);
        this.getRef = this.getRef.bind(this);
        this.createColumns = this.createColumns.bind(this);
        this.renderCommandCell = this.renderCommandCell.bind(this);
        this.removeCellClick = this.removeCellClick.bind(this);
        this.columns = this.createColumns();
    }

    /**
     * GetSelectedItems
     */
    public GetSelectedItems() {
      return this.dataGrid.instance.getSelectedRowsData();
    }

    createColumns(){
        this.columns = [];
        this.props.children.map((col, i) => {    
          let columnProps = { key: ('col'+i)};
          Object.assign(columnProps, col.props);
          //columnProps['cellTemplate'] = (el, info,cell) => this.cellTemplate(el, info,cell);
          this.columns.push(
            <Column {...columnProps} />
          );
        });
        return this.columns;
    }

    renderCommandCell(){
        let items = [];
        items.push({             
          text:'Удалить',
          icon:'trash',
          onClick: this.removeCellClick              
        });

        items.push(
          //<Link to={'form?mode=edit&id='+ this.dataGrid.GetSelectedItems()[0].id}>
          {
            text:'Изменить',
            icon:'edit',
            onClick: ()=>{
              this.props.navigate('form?mode=edit&id='+ this.dataGrid.instance.getSelectedRowsData()[0].id)
            }
          }
        );

        if(this.props.rowActions != undefined){
          this.props.rowActions.forEach(element => {
            items.push(element)
          });
        }

        let ds = [
          {
            icon:'overflow',
            onClick: this.rowMenuCellClick,
            items: items
          },
        ]

        return (
          <Menu 
            dataSource={ds}
            itemRender={(el)=>{
              return (<Button 
                icon={el.icon}
                onClick= {(id)=>{
                  el.onClick();
                }}
              />)
            }}
          />
        );
    }

    rowMenuCellClick(){

    }
    
    async removeCellClick() {
        let result = ShantiApiDelete(this.path, this.dataGrid.instance.getSelectedRowsData()[0].id)
        if((await result).success){
          this.refreshDataGrid();
        }
    }

    getToolbar(){
      return(
        <Toolbar>
          <Item location="after">
            <Button
              icon='refresh' 
              onClick={this.refreshDataGrid} 
              />
          </Item>
          <Item location="after">
            <Link to={'form?mode=new'}>

            <Button
              icon='add' 
              
              /></Link>
          </Item>
        </Toolbar>
      );
    }

    refreshDataGrid() {
      this.dataGrid.instance.refresh();
    }

    getRef(ref) {
      this.dataGrid = ref;
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
              return fetch(`${process.env.REACT_APP_API_URL}${props.path}/grid${params}`,{
                method: 'GET',
                headers: {
                  "Accept": "*/*",
                  "Content-Type": "application/json",
                },
                credentials: 'include'
                })
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
                ref={this.getRef}
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
                    <Selection mode={'single'} />
                    {this.getToolbar()}
                    <Column
                      width={'5%'}
                      cellRender={this.renderCommandCell}
                    />
                    {this.columns.map((col, i) => {       
                        return (col) 
                    })}

                </DataGrid>
            </React.Fragment>
        )
    }
}

export default ShantiDataGrid;
