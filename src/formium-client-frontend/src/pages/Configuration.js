import React from "react";

import { ReactComponent as HomeIcon } from "./icons/main.svg";
import { ReactComponent as AboutIcon } from "./icons/about.svg";
import { ReactComponent as WindowIcon } from "./icons/window.svg";
import { ReactComponent as ResourceIcon } from "./icons/resource.svg";
import { ReactComponent as JavaScriptIcon } from "./icons/js.svg";
import { ReactComponent as LicenseIcon } from "./icons/license.svg";

const MainPage = React.lazy(() => import("./MainPage"));
const AboutPage = React.lazy(() => import("./AboutPage"));
const WindowPage = React.lazy(() => import("./WindowPage"));
const ResourcePage = React.lazy(() => import("./ResourcePage"));
const LicensePage = React.lazy(() => import("./LicensePage"));

const JSPage = React.lazy(() => import("./JavaScriptPage"));

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
    title: { "zh-CN": "窗体样式", "en-US": "Window Styles" },

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
  {
    name: "license",
    title: { "zh-CN": "许可证", "en-US": "License" },

    component: LicensePage,
    icon: LicenseIcon,
  },
];

export const selectPage = (pageName) => {
  return pages.find((v) => v.name === pageName)?.component;
};
