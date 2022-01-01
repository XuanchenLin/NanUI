import { ReactComponent as GlobalIcon } from './global.svg';
import { CSSTransition, TransitionGroup } from "react-transition-group";
import React, { useState, useEffect } from 'react'

export default function ContentView(props) {

  const [iconStage, setIconStage] = useState(true);


  useEffect(() => {
    const handler = setTimeout(() => {
      setIconStage(!iconStage);
    }, 2000)
    return () => clearTimeout(handler)
  }, [iconStage,])

  return <main className="app-page-view">
    <TransitionGroup component={null}>
      {iconStage ? <CSSTransition key={iconStage} timeout={300} classNames="view">
        <section className="view content-view">
          {props.children}
        </section>
      </CSSTransition> : <CSSTransition key={iconStage} timeout={300} classNames="view">
        <section className="view global-view">
          <GlobalIcon />
        </section>
      </CSSTransition>}
    </TransitionGroup>
  </main>
}