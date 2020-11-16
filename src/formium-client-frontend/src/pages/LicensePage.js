import React from "react";
import "./license-page/License.scss";

import Eng from "./license-page/eng";
import Chs from "./license-page/chs";
import { useAppContext } from "../AppContext";

const LicensePage = () => {
  const {
    state: { lang },
  } = useAppContext();

  return lang === "en-US" ? <Eng /> : <Chs />;
};

export default LicensePage;
