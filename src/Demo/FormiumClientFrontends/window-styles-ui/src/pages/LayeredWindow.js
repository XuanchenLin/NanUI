import "./LayeredWindow.scss";
import sound from "./assets/kitty-meow.mp3";
import { useRef, useEffect } from "react";

export default function LayeredWindow() {
  const audioPlayer = useRef(null);

  const culture = window?.Formium?.culture.name || "en-US";

  let messages = {
    close: "Nose",
  };

  if (culture === "zh-CN") {
    messages = {
      close: "鼻子",
    };
  }

  useEffect(() => {
    audioPlayer.current.play();

    const handle = setInterval(() => {
      audioPlayer.current.play();
    }, 5000);
    return () => {
      clearInterval(handle);
    };
  }, []);

  return (
    <div className="window layered-window">
      <audio src={sound} ref={audioPlayer} style={{ display: "none" }} />

      <div className="cat-container">
        <div className="cat">
          <div className="head">
            <div className="ears">
              <div className="ear-hair-left"></div>
              <div className="ear-hair-right"></div>
            </div>
            <div className="eyes"></div>
            <div className="eye-lids"></div>
            <div className="eye-balls"></div>

            <div className="nose" formium-command="close" title="Close"></div>
            <div className="mouth"></div>
            <div className="mouth-bottom"></div>
            <div className="chin"></div>
            <div className="hair-left"></div>
            <div className="hair-right"></div>
            <div className="whiskers-left"></div>
            <div className="whiskers-right"></div>
            <div className="eyebrows"></div>
          </div>

          <div className="cat-body">
            <div className="paw-left"></div>
            <div className="paw-right"></div>
            <div className="back-left-leg"></div>
            <div className="back-right-leg"></div>
            <div className="tail"></div>
            <div className="tail-front"></div>
            <div className="tail-poof"></div>
            <div className="cat-shadow"></div>
          </div>

          <div className="speech-bubble">
            <h2 className="speech-bubble__meow">{messages.close}</h2>
          </div>

          {/* <div className="cat-dish">
          <h3 className="cat-dish__label">f<span className="oo-letters">oo</span>d</h3>
        </div> */}
        </div>
      </div>
    </div>
  );
}
