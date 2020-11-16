import React from "react";
import { ReactComponent as DevToolsIcon } from "./assets/devtools.svg";
import { useAppContext } from "../AppContext";

import { openDevTools } from "@/FormiumBridge.js";

const DevToolsMenu = (props) => {
  const {
    state: { lang },
  } = useAppContext();

  return (
    <div className="nav-menu-item" {...props}>
      <div className="item-icon">
        <DevToolsIcon />
      </div>
      <span>{lang === "en-US" ? `Developer Tools` : `开发人员工具`}</span>
    </div>
  );
};

const ExtraMenu = () => {
  return (
    <div className="app-nav-menu extra-menu">
      <DevToolsMenu onClick={() => openDevTools()} />
    </div>
  );
};

export default ExtraMenu;
