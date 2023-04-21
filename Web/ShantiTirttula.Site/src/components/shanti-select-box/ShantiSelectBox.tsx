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
    displayExpr?: string
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
              return fetch(`${process.env.REACT_APP_API_URL}${props.path}`,{
                method: 'GET',
                credentials: 'include',
                headers: {
                  "Accept": "*/*",
                  "Content-Type": "application/json",
                }})
                .then((response) => response.json())
                .then((data) => ({
                  data: data.data,
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
                displayExpr={this.props.displayExpr != undefined ? this.props.displayExpr : 'name'}
                placeholder="Select a value..."
                showClearButton={true}
                onSelectionChanged={this.onValueChanged}
            />
        )
    }
}

export default ShantiSelectBox;