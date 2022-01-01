import "./App.scss";
import React, { useEffect } from "react";
import "./App.scss";
import SideBar from "./components/SideBar";
import { useAppContext } from "./AppContext";
import { selectPage } from "./pages/Configuration";
import PageView from "./components/PageView";
import { CSSTransition, TransitionGroup } from "react-transition-group";

const App = () => {
  const {
    state: { page },
  } = useAppContext();
  const Page = selectPage(page);


  useEffect(() => {
    const { Formium, createWaves } = window;
    createWaves && createWaves();
    if (Formium) {
      setTimeout(() => Formium?.hostWindow?.splashScreen?.hide(), 400);
    }

  }, []);

  const pageViewScrollHandler = (e) => {
    const pageView = e.target;
    const titleBar = document.querySelector(".app-command-bar");

    if (pageView.scrollTop >= titleBar.clientHeight) {
      titleBar.classList.add("stay");
    }
    else {
      titleBar.classList.remove("stay");
    }
  }

  useEffect(() => {
    const pageView = document.querySelector(".app-page");

    if (pageView) {
      pageView.scrollTop = 0;
      const titleBar = document.querySelector(".app-command-bar");
      titleBar.classList.remove("stay");
    }

    pageView.addEventListener("scroll", pageViewScrollHandler, { passive: true });

    return () => {
      window.removeEventListener('scroll', pageViewScrollHandler);
    }
  }, [page]);

  return (
    <div className="app">
      <SideBar></SideBar>
      <PageView>
        <TransitionGroup component={null}>
          <CSSTransition key={page} timeout={{ enter: 200, exit: 100 }} classNames="fade" unmountOnExit={true} onEnter={() => {

          }}>
            <div className="app-page">
              <Page />
            </div>
          </CSSTransition>
        </TransitionGroup>

      </PageView >
    </div >
  );
};

export default App;
