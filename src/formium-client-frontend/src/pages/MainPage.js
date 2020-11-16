import React from "react";
import "./main-page/MainPage.scss";
import { useAppContext } from "../AppContext";

import Eng from "./main-page/eng";
import Chs from "./main-page/chs";

const MainPage = () => {
  const {
    state: { lang },
  } = useAppContext();

  return (
    <div className="main-page">{lang === "en-US" ? <Eng /> : <Chs />}</div>
  );
};

export default MainPage;
