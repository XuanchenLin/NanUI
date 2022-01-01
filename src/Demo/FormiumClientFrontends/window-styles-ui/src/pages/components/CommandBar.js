import { useState, useEffect } from "react";

export default function CommandBar(props) {


  const [isMaximized, setIsMaximized] = useState(false);
  const onHostWindowStateChanged = ({ detail: { state } }) => {
    if (state === "maximized") {
      setIsMaximized(true);
    } else {
      setIsMaximized(false);
    }
  };

  let { text } = props;
  text = text || "Application";

  useEffect(() => {
    window.addEventListener("hoststatechanged", onHostWindowStateChanged);

    return () => {
      window.removeEventListener("hoststatechanged", onHostWindowStateChanged);
    };
  }, [isMaximized]);

  return <div className="app-command-bar">
    <div className="title-bar">{text}</div>
    <div className="system-commands">
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
}