import React from "react";
import ExtraMenu from "./ExtraMenu";
import AppLogo from "./Logo";
import NavMenu from "./NavMenu";
import { useAppContext, changeLanguage } from "../AppContext";

const SideBar = () => {
  const context = useAppContext();
  const { state } = context;
  const { lang } = state;
  const toggleLang = () => {
    if (lang === "en-US") {
      changeLanguage(context, "zh-CN");
    } else {
      changeLanguage(context, "en-US");
    }
  };
  return (
    <aside className="app-side-bar">
      <div className="system-commands">
        <div className="language-btn" onClick={() => toggleLang()}>
          <span>{lang === "en-US" ? "中文" : "En"}</span>
        </div>
      </div>
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
