import React from "react";


import { ReactComponent as HomeIcon } from "./icons/main.svg";
import { ReactComponent as AboutIcon } from "./icons/about.svg";
import { ReactComponent as WindowIcon } from "./icons/window.svg";
import { ReactComponent as ResourceIcon } from "./icons/resource.svg";
import { ReactComponent as JavaScriptIcon } from "./icons/js.svg";

// const MainPage = React.lazy(() => import("./MainPage"));
// const AboutPage = React.lazy(() => import("./AboutPage"));
// const WindowPage = React.lazy(() => import("./WindowPage"));
// const ResourcePage = React.lazy(() => import("./ResourcePage"));
//const JSPage = React.lazy(() => import("./JavaScriptPage"));

import MainPage from "./MainPage";
import AboutPage from "./AboutPage";
import WindowPage from "./WindowPage";
import ResourcePage from "./ResourcePage";
import JSPage from "./JavaScriptPage";

export const pages = [
  {
    name: "main",
    title: { "zh-CN": "欢迎使用", "en-US": "Welcome" },
    component: MainPage,
    icon: HomeIcon,
  },
  {
    name: "about",
    title: { "zh-CN": "项目简介", "en-US": "Introduction" },

    component: AboutPage,
    icon: AboutIcon,
  },
  {
    name: "window",
    title: { "zh-CN": "窗体功能", "en-US": "Window Features" },

    component: WindowPage,
    icon: WindowIcon,
  },
  {
    name: "resource",
    title: { "zh-CN": "资源加载", "en-US": "Resources" },

    component: ResourcePage,
    icon: ResourceIcon,
  },
  {
    name: "javascript",
    title: "JavaScript",
    component: JSPage,
    icon: JavaScriptIcon,
  },

];

export const selectPage = (pageName) => {
  const Page = pages.find((v) => v.name === pageName)?.component || <div>Component is not ready!</div>;


  return () => {

    return <Page />
  };
};
