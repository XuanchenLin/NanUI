import "./App.scss";
import sound from "./assets/start.wav";
import { useRef, useEffect } from "react";
import { ReactComponent as StartIcon } from "./assets/start.svg";

function App() {
  const culture = window?.Formium?.culture.name || "en-US";

  const audioPlayer = useRef(null);
  useEffect(() => {
    const handle = setTimeout(() => {
      audioPlayer.current.play();
    }, 1100);
    return () => {
      clearTimeout(handle);
    };
  }, []);

  let messages = {
    close: "Close",
    slogan: "Build .NET WinForm Apps with HTML/CSS/JS",
    launch: "Launch Demo",
  };

  if (culture === "zh-CN") {
    messages = {
      close: "关闭窗口",
      slogan: "用 HTML/CSS/JS 来创建 .NET 窗体应用",
      launch: "开始体验",
    };
  }
  useEffect(() => {
    const handle = setTimeout(() => {
      const rootEl = document.querySelector("html");
      rootEl.classList.add("animation-complete");
    }, 6000);
    return () => {
      clearTimeout(handle);
    };
  }, []);

  return (
    <div className="App">
      <div className="close-btn" title={messages.close} formium-command="close">
        &#x2715;
      </div>
      <audio src={sound} ref={audioPlayer} style={{ display: "none" }} />
      <div className="animate-squre one"></div>
      <div className="animate-squre two"></div>
      <div className="animate-squre three"></div>
      <div className="animate-squre four"></div>
      <div className="animate-squre five"></div>

      <div className="sense">
        <div className="headline">
          <div className="nanui-logo">
            <div className="chrome-icon"></div>
            <div className="window-icon"></div>
          </div>
          <div className="nanui-brand">
            Nan<span>UI</span>
          </div>
        </div>
        <div className="slogan">{messages.slogan}</div>
        <div className="buttons" title={messages.launch}>
          <div
            className="start-btn"
            onClick={() => {
              const { Formium } = window;
              Formium?.external?.launcher?.launchDemo();
            }}
          >
            <StartIcon />
          </div>
          <div className="btn-halo"></div>
        </div>
      </div>
    </div>
  );
}

export default App;
