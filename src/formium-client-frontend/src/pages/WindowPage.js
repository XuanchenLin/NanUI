import React from "react";
import Eng from "./window-page/eng";
import Chs from "./window-page/chs";

import { useAppContext } from "../AppContext";

const WindowPage = () => {
  const {
    state: { lang },
  } = useAppContext();

  return (
    <div className="main-page">{lang === "en-US" ? <Eng /> : <Chs />}</div>
  );
};

export default WindowPage;
