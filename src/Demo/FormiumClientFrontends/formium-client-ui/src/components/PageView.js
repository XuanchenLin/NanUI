import React from "react";
import CommandBar from "./CommandBar";


const PageView = (props) => {
  return (
    <main className="app-page-view">
      <CommandBar />
      {props.children}
    </main>
  );
};

export default PageView;
