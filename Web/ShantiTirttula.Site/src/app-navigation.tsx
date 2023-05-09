export const navigation = [
  {
    text: 'Home',
    key: 'Home',
    path: '/home',
    icon: 'home'
  },
  {
    text: 'Контроллер:',
    key: 'controllerfolder',
    icon: 'folder',
    items: [
      {
        text: 'Профиль',
        key: 'profile',
        path: '/profile',
        disabled: true
      },
      {
        text: 'Контроллеры',
        key: 'controllers',
        path: '/controllers'
      },
      {
        text: 'Триггеры',
        key: 'triggers',
        path: '/triggers',
        disabled: true
      },
      {
        text: 'Команды',
        key: 'commands',
        path: '/commands',
        disabled: true
      },{
        text: 'Расписание',
        key: 'shedules',
        path: '/shedules',
        disabled: true
      },{
        text: 'План',
        key: 'shedule-tasks',
        path: '/shedule-tasks',
        disabled: true
      }
    ]
  }
  ];
