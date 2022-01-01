import React from "react";
import { ReactComponent as DevToolsIcon } from "./assets/devtools.svg";
import { ReactComponent as LicenseIcon } from "./assets/license.svg";

import { useAppContext } from "../AppContext";

import { openDevTools, openLicenseWindow } from "@/FormiumBridge.js";

const DevToolsMenu = (props) => {
  const {
    state: { lang },
  } = useAppContext();

  return (
    <>
      <div className="nav-menu-item" {...props} onClick={() => openLicenseWindow()}>
        <div className="item-icon">
          <LicenseIcon />
        </div>
        <span>{lang === "en-US" ? `Licenses` : `许可证信息`}</span>
      </div>
      <div className="nav-menu-item" {...props} onClick={() => openDevTools()}>
        <div className="item-icon">
          <DevToolsIcon />
        </div>
        <span>{lang === "en-US" ? `Developer Tools` : `开发人员工具`}</span>
      </div>
    </>
  );
};

const ExtraMenu = () => {
  return (
    <div className="app-nav-menu extra-menu">
      <DevToolsMenu />
    </div>
  );
};

export default ExtraMenu;
