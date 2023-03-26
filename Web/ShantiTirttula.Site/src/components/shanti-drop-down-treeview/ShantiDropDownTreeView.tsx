import React from 'react';
import DropDownBox from 'devextreme-react/drop-down-box';
import DataSource from 'devextreme/data/custom_store';
import { getTokenFromLocalStorage } from '../../api/auth';
import TreeList, {Column, Selection} from 'devextreme-react/tree-list';
import { ShantiApiGet } from '../../api/shantiajax';

interface ShantiDropDownTreeViewProps {
    path: string,
    byKeyPath: string,
    dataField: string,
}

interface ShantiDropDownTreeViewState{
    selectedId: any,
    isOpened: boolean
}

function isNotEmpty(value) {
    return value !== undefined && value !== null && value !== '';
}

class ShantiDropDownTreeView extends React.PureComponent<ShantiDropDownTreeViewProps, ShantiDropDownTreeViewState>{
    path: string;
    dataSource: DataSource;
    treeView: any;

    constructor(props){
        super(props);
        this.treeView = null;
        this.path = props.path;
        this.dataSource = this.getDataSource(props);      
        this.state = {
            selectedId: null,
            isOpened: false
        };  

        this.onTreeBoxOpened = this.onTreeBoxOpened.bind(this);
        this.treeViewItemSelectionChanged = this.treeViewItemSelectionChanged.bind(this);
        this.syncTreeViewSelection = this.syncTreeViewSelection.bind(this);
        this.treeViewOnContentReady = this.treeViewOnContentReady.bind(this);
        this.treeViewRender = this.treeViewRender.bind(this);
        this.onTreeRowClick = this.onTreeRowClick.bind(this);
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
            byKey(id) {
              return new Promise<void>((resolve, reject) => {  
                ShantiApiGet(`${props.byKeyPath}`+id)
                   .then(res => resolve(res.data))
                   .catch(err => console.log(err));  
                });
            }
          });
        }

    render(): React.ReactNode {
        return(
            <DropDownBox
            opened={this.state.isOpened}
            value={this.state.selectedId}
            valueExpr="id"
            displayExpr="typeName"
            placeholder="Select a value..."
            showClearButton={true}
            dataSource={this.dataSource}
            onOptionChanged={this.onTreeBoxOpened}
            onValueChanged={this.syncTreeViewSelection}
            contentRender={(this.treeViewRender)}
          />
        );
    }

    treeViewRender(){
        return (
          <TreeList 
            dataSource={this.dataSource}
            ref={(ref) => { this.treeView = ref; }}
            dataStructure="plain"
            keyExpr="id"
            parentIdExpr="parentId"        
            onContentReady={this.treeViewOnContentReady}
            onRowClick={this.onTreeRowClick}
            onSelectionChanged={this.treeViewItemSelectionChanged}         
            >
            <Selection mode="single" />
            <Column dataField={"name"} 
            />
        </TreeList>
        );
    }

    onTreeBoxOpened(e) {
        if (e.name === 'opened') {
          this.setState({
            isOpened: e.value,
          });
        }
      }

    syncTreeViewSelection(e) {
        this.setState({
          selectedId: e.value,
        });
        const event = new CustomEvent("onValueChanged", { 
          detail: {
            dataField: this.props.dataField,
            newValue: e.value
          } 
        });
        document.dispatchEvent(event);

        if (!this.treeView) return;
    
        if (!e.value) {
          this.treeView.instance.deselectAll();
        } else {
          this.treeView.instance.selectRows(e.value, true);
        }
      }

      treeViewItemSelectionChanged(e) {
        this.setState({
          selectedId: e.component.getSelectedRowKeys()[0],
        });
      }

    treeViewOnContentReady(e) {
      if(this.state.selectedId!=null)
        e.component.selectRows(this.state.selectedId, true);
    }

    onTreeRowClick(e) {
      if(e.node.key>0){
        this.setState({
          isOpened: false,
        });
      }
    }
  

}

export default ShantiDropDownTreeView;