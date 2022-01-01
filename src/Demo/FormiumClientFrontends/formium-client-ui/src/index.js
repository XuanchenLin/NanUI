import React from "react";
import ReactDOM from "react-dom";
import "./index.scss";
import App from "./App";
import Context from "./AppContext";

import reportWebVitals from "./reportWebVitals";

ReactDOM.render(
  <Context>
    <App></App>
  </Context>,
  document.getElementById("formium-app")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals(console.log);
