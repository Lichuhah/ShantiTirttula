import React, { useMemo } from 'react';
import { useNavigate } from "react-router-dom";
import ContextMenu, { Position } from 'devextreme-react/context-menu';
import List from 'devextreme-react/list';
import { useAuth } from '../../contexts/auth';
import './UserPanel.scss';
import type { UserPanelProps } from '../../types';

export default function UserPanel({ menuMode }: UserPanelProps) {
  const { user, signOut } = useAuth();
  const navigate = useNavigate();

  function navigateToProfile() {
    navigate("/profile");
  }
  const menuItems = useMemo(() => ([
    {
      text: 'Profile',
      icon: 'user',
      onClick: navigateToProfile
    },
    {
      text: 'Logout',
      icon: 'runner',
      onClick: signOut
    }
  ]), [signOut]);
  return (
    <div className={'user-panel'}>
      <div className={'user-info'}>
        <div className={'image-container'}>
          <div
            style={{
              background: `url(https://avatars.githubusercontent.com/u/63907966?s=400&u=f2d1bb78665fc760f815c1f704894d92bb1c89af&v=4) no-repeat #fff`,
              backgroundSize: 'cover'
            }}
            className={'user-image'} />
        </div>
        <div className={'user-name'}>{user!.email}</div>
      </div>

      {menuMode === 'context' && (
        <ContextMenu
          items={menuItems}
          target={'.user-button'}
          showEvent={'dxclick'}
          width={210}
          cssClass={'user-menu'}
        >
          <Position my={'top center'} at={'bottom center'} />
        </ContextMenu>
      )}
      {menuMode === 'list' && (
        <List className={'dx-toolbar-menu-action'} items={menuItems} />
      )}
    </div>
  );
}
