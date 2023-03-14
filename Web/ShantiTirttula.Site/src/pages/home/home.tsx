import React from 'react';
import './home.scss';

export default function Home() {
  return (
    <React.Fragment>
      <h2 className={'content-block'}>Home</h2>
      <div className={'content-block'}>
        <div className={'dx-card responsive-paddings'}>
          <div className={'logos-container'}>
            <picture className={'my-face'}>
                <img src="/resource/pictures/MyFuckingFace.jpg" width={'100%'} height={400}></img>
            </picture>
          </div>

          <p>Здесь что-то будет.</p>
          <p>
            <span>Репозиторий: </span>
            <a href={'https://github.com/Lichuhah/ShantiTirttula'} target={'_blank'} rel={'noopener noreferrer'}>Shanti Tirttula Repository</a>
          </p>
        </div>
      </div>
    </React.Fragment>
)}
