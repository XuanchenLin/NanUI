import React from "react";
import "./resource-page/Resource.scss";
import Eng from "./resource-page/eng";
import Chs from "./resource-page/chs";
import { useAppContext } from "../AppContext";

const ResourcePage = () => {
  const {
    state: { lang },
  } = useAppContext();

  return (
    <div className="resource-page">{lang === "en-US" ? <Eng /> : <Chs />}</div>
  );
};

export default ResourcePage;
