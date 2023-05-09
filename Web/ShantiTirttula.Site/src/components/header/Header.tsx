import React from 'react';
import Toolbar, { Item } from 'devextreme-react/toolbar';
import Button from 'devextreme-react/button';
import UserPanel from '../user-panel/UserPanel';
import './Header.scss';
import { Template } from 'devextreme-react/core/template';
import type { HeaderProps } from '../../types';
import { Form } from 'devextreme-react';

let toolbarsyle = {
  style: "background-image: url('/resource/pictures/SumeruBack1.webp');" +
  "background-repeat: no-repeat;" + 
  "background-position: 0px 0px;" + 
  "background-size: contain;", 
}

let userpanelstyle = {
  style: "background-image: url('/resource/pictures/UserPanelBack1.webp');" +
      "background-repeat: no-repeat;" +
      "background-position: 0px 0px;" +
      "background-size: contain;",
}

export default function Header({ menuToggleEnabled, title, toggleMenu }: HeaderProps) {
  return (
    <header className={'header-component'}>
      <Toolbar className={'header-toolbar'}
        height = {document.body.offsetHeight * 0.08}
        elementAttr = {toolbarsyle}
      >
        <Item
          visible={menuToggleEnabled}
          location={'before'}
          widget={'dxButton'}
          cssClass={'menu-button'}
        >
          <Button icon="menu" stylingMode="text" onClick={toggleMenu} />
        </Item> 
        <Item
          location={'before'}
          cssClass={'header-title'}
          text={title}
          visible={!!title}
        />
        <Item
          location={'center'}
          locateInMenu={'auto'}
        >
          <img src="/resource/icons/SumeruIcon.png" width={'100%'} height={document.body.offsetHeight * 0.08}></img>
        </Item>
        <Item
          location={'after'}
          locateInMenu={'auto'}
          menuItemTemplate={'userPanelTemplate'}
        >
          <Button
            className={'user-button authorization'}
            width={210}
            height={'100%'}
            stylingMode={'text'}
          >
            <UserPanel menuMode={'context'} />
          </Button>
        </Item>
        <Template name={'userPanelTemplate'} >
          <UserPanel menuMode={'list'} />
        </Template>        
      </Toolbar>
    </header>
)}
