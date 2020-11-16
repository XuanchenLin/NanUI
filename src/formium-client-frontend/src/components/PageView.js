import React, { Suspense } from "react";
import CommandBar from "./CommandBar";

const LoadingIndicator = () => <div className="loading-indicator"></div>;

const PageView = (props) => {
  return (
    <main className="app-page-view">
      <CommandBar />
      <Suspense fallback={<LoadingIndicator />}>{props.children}</Suspense>
    </main>
  );
};

export default PageView;
