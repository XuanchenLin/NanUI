import React, { useEffect, useState } from "react";
import { useAppContext, changeLanguage } from "../AppContext";

const CommandBar = () => {
  const [isMaximized, setIsMaximized] = useState(false);

  const context = useAppContext();
  const { state } = context;
  const { lang } = state;

  const onHostWindowStateChanged = ({ detail: { state } }) => {
    if (state === "maximized") {
      setIsMaximized(true);
    } else {
      setIsMaximized(false);
    }
  };

  const toggleLang = () => {
    if (lang === "en-US") {
      changeLanguage(context, "zh-CN");
    } else {
      changeLanguage(context, "en-US");
    }
  };

  useEffect(() => {
    window.addEventListener("hoststatechanged", onHostWindowStateChanged);

    return () => {
      window.removeEventListener("hoststatechanged", onHostWindowStateChanged);
    };
  }, [isMaximized]);

  return (
    <div className="app-command-bar">
      {/* <div className="lang-bar">
        <img src={lang === "en-US" ? en_us : zh_cn} alt="Language" />
      </div> */}
      <div className="title-bar"></div>
      <div className="system-commands">
        <div className="minimize-btn" onClick={() => toggleLang()}>
          <span>{lang === "en-US" ? "中文" : "ENG"}</span>
        </div>
        <div className="minimize-btn" formium-command="minimize">
          <span>&#xe7bf;</span>
        </div>
        <div className="maximize-btn" formium-command="maximize">
          {isMaximized ? <span>&#xe7c0;</span> : <span>&#xe7c1;</span>}
        </div>
        <div className="close-btn" formium-command="close">
          <span>&#xe7b4;</span>
        </div>
      </div>
    </div>
  );
};

export default CommandBar;
