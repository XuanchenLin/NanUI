import "./App.scss";
import React from "react";
import "./App.scss";
import SideBar from "./components/SideBar";
import { useAppContext } from "./AppContext";
import { selectPage } from "./pages/Configuration";
import PageView from "./components/PageView";

const App = () => {
  const {
    state: { page },
  } = useAppContext();

  const Page = selectPage(page);

  const CurrentPage = () => (
    <div className="app-page">
      {Page ? <Page /> : <div>Component doesn't exist.</div>}
    </div>
  );

  return (
    <div className="app">
      <SideBar></SideBar>
      <PageView>
        <CurrentPage />
      </PageView>
    </div>
  );
};

export default App;
