import React from 'react';
import DropDownBox from 'devextreme-react/drop-down-box';
import DataSource from 'devextreme/data/custom_store';
import { getTokenFromLocalStorage } from '../../api/auth';
import TreeList, {Column, Selection} from 'devextreme-react/tree-list';
import { ShantiApiGet } from '../../api/shantiajax';
import { SelectBox } from 'devextreme-react';

interface ShantiSelectBoxProps {
    path: string,
    byKeyPath: string,
    dataField: string,
}

interface ShantiSelectBoxState{
    selectedId: any,
}

function isNotEmpty(value) {
    return value !== undefined && value !== null && value !== '';
}

class ShantiSelectBox extends React.PureComponent<ShantiSelectBoxProps, ShantiSelectBoxState>{
    path: string;
    dataSource: DataSource;

    constructor(props){
        super(props);
        this.path = props.path;
        this.dataSource = this.getDataSource(props); 

        this.state = {
            selectedId: null
        };  

        this.onValueChanged = this.onValueChanged.bind(this);
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
                ShantiApiGet(`${process.env.REACT_APP_API_URL}${props.byKeyPath}`+id)
                   .then(res => resolve(res.data));  
                });
            }
          });
        }

    onValueChanged(e) {
        console.log(e)
        this.setState({
          selectedId: e.selectedItem.id,
        });
        const event = new CustomEvent("onValueChanged", { 
            detail: {
              dataField: this.props.dataField,
              newValue: e.selectedItem.id
            } 
        });
        document.dispatchEvent(event);
    }

    render(): React.ReactNode {
        return(
            <SelectBox
                value={this.state.selectedId}
                valueExpr="id"
                dataSource={this.dataSource}
                displayExpr="name"
                placeholder="Select a value..."
                showClearButton={true}
                onSelectionChanged={this.onValueChanged}
            />
        )
    }
}

export default ShantiSelectBox;