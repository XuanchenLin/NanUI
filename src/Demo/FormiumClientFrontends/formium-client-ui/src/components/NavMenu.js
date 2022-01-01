import React from "react";
import { pages } from "../pages/Configuration";
import { useAppContext, changePageView } from "../AppContext";

const NavMenu = () => {
  const context = useAppContext();
  const { state } = context;

  const { page, lang } = state;

  const onItemClick = (page) => {
    changePageView(context, page);
  };

  const listItems = pages.map((item) => {
    const Icon = item.icon;
    return (
      <div
        className={`nav-menu-item ${page === item.name && "active"}`}
        key={item.name}
        onClick={() => onItemClick(item.name)}
      >
        <div className="item-icon">
          <Icon />
        </div>
        <span>
          {typeof item.title === "string" ? item.title : item.title[lang]}
        </span>
      </div>
    );
  });

  return <div className="app-nav-menu">{listItems}</div>;
};

export default NavMenu;
