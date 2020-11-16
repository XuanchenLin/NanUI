import React from "react";
import ExtraMenu from "./ExtraMenu";
import AppLogo from "./Logo";
import NavMenu from "./NavMenu";

const SideBar = () => {
  return (
    <aside className="app-side-bar">
      <div className="top-aside">
        <AppLogo />
        <NavMenu />
      </div>
      <div className="middle-aside"></div>
      <div className="bottom-aside">
        <ExtraMenu />
      </div>
    </aside>
  );
};
export default SideBar;
