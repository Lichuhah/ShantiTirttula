import React, { useMemo, useRef } from 'react';
import 'devextreme/data/odata/store';
import { Button } from 'devextreme-react';
import { useScreenSize } from '../../utils/media-query';
import { Link, useNavigate } from 'react-router-dom';
import {TreeView, Item } from 'devextreme-react/tree-view';

interface ShantiNavigationMenuProps {
    children,
    selectedItemChanged,
    openMenu,
    compactMode,
    onMenuReady,
    isLarge,
    navigate
}

interface ShantiNavigationMenuState{
    isMcSelected: boolean,
    mcKey: string,
    navigation: any
}

export class ShantiNavigationMenu extends React.PureComponent<ShantiNavigationMenuProps, ShantiNavigationMenuState> {
    treeView : any;
    navigation: any;

    constructor(props){
        super(props);
        this.state = {isMcSelected: false, mcKey: "", navigation:[]};
        this.state = {isMcSelected: false, mcKey: "", navigation:this.getNavigation()};
        //this.setState({navigation: this.getNavigation()})
        document.addEventListener('selectedControllerChanged',  (e:any) => {
            let val = e.detail.value;
            sessionStorage.setItem("mcId", val.id);
            this.setState({isMcSelected: true, mcKey: val.key}, 
                ()=>{this.setNavigation()});
            ;
        });

        this.setNavigation = this.setNavigation.bind(this);
        this.getNavigation = this.getNavigation.bind(this);
        this.getRef = this.getRef.bind(this);
    }

    setNavigation(){
       this.setState({navigation: this.getNavigation()})
    }

    getNavigation(){
        
        return [
            {
                text: 'Home',
                icon: 'home',
                path: '/home'
            },
            {
               text: 'Контроллер: '+this.state.mcKey,
               icon: 'folder',
               items: [
                //  {
                //    text: 'Профиль',
                //    key: 'profile',
                //    path: '/profile',
                //    disabled: !this.state.isMcSelected,
                //  },
                 {
                   text: 'Контроллеры',
                   key: 'controllers',
                   path: '/controllers',
                 },
                 {
                   text: 'Триггеры',
                   key: 'triggers',
                   path: '/triggers',
                   disabled: !this.state.isMcSelected,
                 },
                 {
                    text: 'Датчики',
                    key: 'sensors',
                    path: '/sensors',
                    disabled: !this.state.isMcSelected,
                 },
                 {
                    text: 'Значения датчиков',
                    key: 'sensordata',
                    path: '/sensordata',
                    disabled: !this.state.isMcSelected,
                 }
               ]
         }
        ];
    }

    selectedItemChanged(e) {    
        this.props.navigate(e.itemData.path);
    }

    // getItems(){
    //     let items = this.normalizePath();
    //     items.find(i=>i.key == "controllerfolder").text = "Контроллер:"+this.mcId;
    //     return this.normalizePath()
    // }

    public SetController(key){
        this.setState({isMcSelected: true, mcKey: key})
    }
    
    getRef(ref) {
        this.treeView = ref;
    }

    // renderLink(e): React.ReactNode{
    //     console.log(e)
    //     if(e.items == undefined){
    //         return (<Item 
    //                 id={e.text}
    //                 text={e.text}
    //                 icon={e.icon}  
    //             />);
    //     } else {
    //         return (<Item
    //                 text={"fafwa"}  
    //             />);
    //     }
    // }

    render(): React.ReactNode {
        return <TreeView
            ref={this.getRef}
            items={this.state.navigation}
            keyExpr={'path'}
            selectionMode={'single'}
            focusStateEnabled={false}
            expandEvent={'click'}
            onItemClick={(e)=>{this.selectedItemChanged(e)}}
            //onContentReady={this.props.onMenuReady}
            //itemRender={this.renderLink}
            width={'100%'} />;
    }
}

export default ShantiNavigationMenu;