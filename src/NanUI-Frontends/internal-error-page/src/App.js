import "./App.scss";
import { ReactComponent as CloseIcon } from "./close.svg";
import Globalization from "./Globalization.json";

export default function App() {
  const culture = window?.Formium?.culture.name || "en-US";

  let messages = {};

  if (Globalization.hasOwnProperty(culture)) {
    messages = Globalization[culture];
  } else {
    messages = Globalization["en-US"];
  }

  return (
    <div className="App">
      <header>
        <div className="title">{messages.caption}</div>

        <div className="control-box" formium-command="close">
          <CloseIcon />
        </div>
      </header>
      <main>
        <h2>{messages.title}</h2>
        <p>{messages.content}</p>
      </main>
    </div>
  );
}
