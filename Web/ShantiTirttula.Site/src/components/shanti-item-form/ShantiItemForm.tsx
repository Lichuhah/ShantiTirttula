import React, { useEffect } from 'react';
import { Link, useSearchParams } from 'react-router-dom';
import Form, { Item, SimpleItem } from 'devextreme-react/form';
import { Button, Toolbar } from 'devextreme-react';
import { Item as ToolBarItem } from 'devextreme-react/toolbar';
import './ShantiEditForm.scss';
import { ShantiApiGet, ShantiApiPost} from '../../api/shantiajax';
import ShantiFormItem from './ShantiFormItem';


enum Mode{
    View = 0,
    New = 1,
    Edit = 2
}


interface ShantiItemFormProps {
    title: string,
    children?: any,
    colCount: number,
    path: string
}

interface ShantiItemFormState {
    pageMode: Mode,
    itemId: number,
    formData: {}
}

export default class ShantiItemForm extends React.PureComponent<ShantiItemFormProps, ShantiItemFormState> {
    pageMode: Mode;
    title: string;
    items: any;
    form: any;
    editors = {};  

    constructor(props){
        super(props);
        this.title = props.title;
        // if(props.children == undefined)
        //      this.items = [];
        // else {
        //      this.items = this.props.children;
        // }

        this.state = {pageMode: this.getMode(), itemId: this.getId(), formData: {}}
        this.loadData();
        this.setEditMode = this.setEditMode.bind(this);
        this.setNewMode = this.setNewMode.bind(this);
        this.setViewMode = this.setViewMode.bind(this);
        this.saveData = this.saveData.bind(this);
        this.getFormData = this.getFormData.bind(this);
        this.getRef = this.getRef.bind(this);
        this.loadData = this.loadData.bind(this);
        this.setListener = this.setListener.bind(this);
        this.setFormDataValue = this.setFormDataValue.bind(this);
        this.fieldChanged = this.fieldChanged.bind(this);
        this.setListener();
    }

    setListener(){
        document.addEventListener('onValueChanged',  (e:any) => {
            this.setFormDataValue(e.detail.dataField, e.detail.newValue);
        });
    }

    fieldChanged(e){
        this.setFormDataValue(e.dataField, e.value)
    }

    setFormDataValue(name, value){
        this.state.formData[name]=value;
    }

    getRef(ref) {
        this.form = ref;
    }

    getId(){
        let id = new URLSearchParams(window.location.search).get("id");
        if(id != undefined)
            return parseInt(id);
        else
            return 0;
    }

    getMode(){
        let mode = new URLSearchParams(window.location.search).get("mode");
        switch(mode){
            case "new": return Mode.New; 
            case "edit": return Mode.Edit;
            case "view": return Mode.View;
        }   
    }

    setEditMode(){
        this.setState({pageMode: Mode.Edit})
    }

    setViewMode(){
        console.log(this.state)
        this.setState({pageMode: Mode.View})
    }

    setNewMode(){
        this.setState({pageMode: Mode.New})
    }

    async loadData(){
        console.log("load");
        if(this.state.itemId > 0){
            this.setState({
                formData: (await ShantiApiGet(`${this.props.path}/`+this.state.itemId)).data
            });
            return (await ShantiApiGet(`${this.props.path}/`+this.state.itemId)).data;
        }  
    }

    async saveData(){
        let data = this.getFormData();
        data['id'] = 0;
        var result = ShantiApiPost(`${this.props.path}`,this.getFormData());
        if((await result).success){
            this.setState({
                pageMode: Mode.View,
                itemId: (await result).data.id,
            });
            this.loadData();
        } else {
            console.log((await result).errorMessages)
        }
    }

    getFormData(){
        let data = this.state.formData;
        data['authId'] = sessionStorage.getItem("mcId");
        return data;
    }

    getToolBar(mode:Mode){
        switch(mode){
            case Mode.New: return(
                <Toolbar>
                  <ToolBarItem location="after">
                    <Link to={'/triggers'}>
                        <Button
                            icon='clear'
                            text = {"Отмена"}
                        />
                      </Link>
                      <Button
                        icon='save'
                        text = {"Сохранить"}
                        onClick={this.saveData}
                      />
                  </ToolBarItem>
                </Toolbar>
            );
            case Mode.Edit: return(
                <Toolbar>
                <ToolBarItem location="after">
                    <Button
                        icon='clear'
                        text = {"Отмена"}
                        onClick={this.setViewMode}
                    />
                    <Button
                        icon='save'
                        text = {"Сохранить"}
                        onClick={this.setViewMode}
                    />
                </ToolBarItem>
              </Toolbar>);
            case Mode.View: return(
                <Toolbar>
                <ToolBarItem location="after">
                    <Link to={'/triggers'}>
                        <Button
                            icon='arrowleft'
                            text = {"Вернуться"}
                        />
                      </Link>
                    <Button
                        icon='edit'
                        text = {"Изменить"}
                        onClick={this.setEditMode}
                    />
                </ToolBarItem>
                </Toolbar>
            );
            };
        }

    render(): React.ReactNode {
        return(
           <React.Fragment>
                <h2 className={'content-block'}>{this.title}</h2>
                {this.getToolBar(this.state.pageMode)}
                <Form
                    ref={this.getRef}
                    className={'shanti-edit-form'} 
                    colCount = {this.props.colCount}
                    onOptionChanged ={function(e){console.log(e)}}
                    onFieldDataChanged = {this.fieldChanged}
                    formData = {this.state.formData}
                    >
                    {this.props.children.map((col,i) => { 
                        return col;
                    })} 
                </Form>
            </React.Fragment>
        );
    }
}