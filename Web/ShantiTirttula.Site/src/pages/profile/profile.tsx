import React, { useState } from 'react';
import './profile.scss';
import Form from 'devextreme-react/form';

export default function Profile() {
  const [notes, setNotes] = useState(
    'Ну топ же.'
  );
  const employee = {
    ID: 7,
    FirstName: 'Госпожа',
    LastName: 'Хутава',
    Prefix: '6C',
    Position: 'Вайфу',
    Picture: '20210228210611',
    BirthDate: new Date('1974/11/5'),
    HireDate: new Date('2005/05/11'),
    Notes: notes,
    Address: 'Ли Юэ Похоронное бюро'
  };

  return (
    <React.Fragment>
      <h2 className={'content-block'}>${process.env.REACT_APP_API_URL}</h2>

      <div className={'content-block dx-card responsive-paddings'}>
        <div className={'form-avatar'}>
          <img
            alt={''}
            src={`https://static.wikia.nocookie.net/gensin-impact/images/e/e9/Hu_Tao_Icon.png/revision/latest?cb=${
              employee.Picture
            }`}
            width={'auto'}
            height={'auto'}
          />
        </div>
        <span>{notes}</span>
      </div>

      <div className={'content-block dx-card responsive-paddings'}>
        <Form
          id={'form'}
          defaultFormData={employee}
          onFieldDataChanged={e => e.dataField === 'Notes' && setNotes(e.value)}
          labelLocation={'top'}
          colCountByScreen={colCountByScreen}
        />
      </div>
    </React.Fragment>
  );
}

const colCountByScreen = {
  xs: 1,
  sm: 2,
  md: 3,
  lg: 4
};
