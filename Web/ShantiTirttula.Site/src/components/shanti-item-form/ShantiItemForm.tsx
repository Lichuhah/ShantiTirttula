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
}

interface ShantiItemFormState {
    pageMode: Mode,
    itemId: number,
    formData: {}
}

export default class ShantiItemForm extends React.Component<ShantiItemFormProps, ShantiItemFormState> {
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

        if(this.state.itemId > 0){
            this.loadData();
        }

       

        this.setEditMode = this.setEditMode.bind(this);
        this.setNewMode = this.setNewMode.bind(this);
        this.setViewMode = this.setViewMode.bind(this);
        this.saveData = this.saveData.bind(this);
        this.getFormData = this.getFormData.bind(this);
        this.getRef = this.getRef.bind(this);
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
        this.setState({pageMode: Mode.View})
    }

    setNewMode(){
        this.setState({pageMode: Mode.New})
    }

    loadData(){
        var data = ShantiApiGet("/api/forms?id="+this.state.itemId);
    }

    saveData(){
        this.getFormData();
    }

    getFormData(){
        console.log(this.state.formData);
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
                    >
                    {this.props.children.map((col,i) => {  
                        return col;
                    })} 
                </Form>
            </React.Fragment>
        );
    }
}