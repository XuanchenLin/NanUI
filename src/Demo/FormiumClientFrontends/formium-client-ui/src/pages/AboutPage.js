import React from "react";
import { useAppContext } from "../AppContext";
import Eng from "./about-page/eng";
import Chs from "./about-page/chs";

const AboutPage = () => {
  const {
    state: { lang },
  } = useAppContext();

  return (
    <div className="about-page">{lang === "en-US" ? <Eng /> : <Chs />}</div>
  );
};

export default AboutPage;
