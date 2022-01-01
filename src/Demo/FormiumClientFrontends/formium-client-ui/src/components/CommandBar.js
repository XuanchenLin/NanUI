import React, { useEffect, useState } from "react";
import { useAppContext } from "../AppContext";

const CommandBar = () => {
  const [isMaximized, setIsMaximized] = useState(false);

  const {
    state: { lang },
  } = useAppContext();

  const onHostWindowStateChanged = ({ detail: { state } }) => {
    if (state === "maximized") {
      setIsMaximized(true);
    } else {
      setIsMaximized(false);
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

      <div className="title-bar"></div>
      <div className="system-commands">
        <div className="minimize-btn" formium-command="minimize" title={lang === "en-US" ? "Minimize" : "最小化"}>
          <span>&#xe7bf;</span>
        </div>
        <div className="maximize-btn" formium-command="maximize" title={lang === "en-US" ? isMaximized ? "Restore" : "Maximize" : isMaximized ? "还原" : "最大化"}>
          {isMaximized ? <span>&#xe7c0;</span> : <span>&#xe7c1;</span>}
        </div>
        <div className="close-btn" formium-command="close" title={lang === "en-US" ? "Close" : "关闭"}>
          <span>&#xe7b4;</span>
        </div>
      </div>
    </div>
  );
};

export default CommandBar;
