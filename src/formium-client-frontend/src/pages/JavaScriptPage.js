import React from "react";
import Eng from "./js-page/eng";
import Chs from "./js-page/chs";
import "./js-page/JavaScript.scss";
import { useAppContext } from "../AppContext";

const JavaScriptPage = () => {
  const {
    state: { lang },
  } = useAppContext();

  return <div className="js-page">{lang === "en-US" ? <Eng /> : <Chs />}</div>;
};

export default JavaScriptPage;
