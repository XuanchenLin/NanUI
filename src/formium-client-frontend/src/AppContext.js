import React, { useContext, useReducer } from "react";

const AppContext = React.createContext();

const REDUCER_ACTION_NAMES = {
  CHANGE_VIEW: "CHANGE_VIEW",
  CHANGE_LANG: "CHANGE_LANG",
};

const initState = { page: "main", lang: "zh-CN" };

const reducer = (state, action) => {
  switch (action.type) {
    case REDUCER_ACTION_NAMES.CHANGE_VIEW:
      return { ...state, page: action.payload };
    case REDUCER_ACTION_NAMES.CHANGE_LANG:
      return { ...state, lang: action.payload };
    default:
      return state;
  }
};

export const useAppContext = () => useContext(AppContext);

export const changePageView = (context, pageName) => {
  const {
    state: { page },
    dispatch,
  } = context;
  if (page === pageName) {
    return;
  }

  dispatch({ type: REDUCER_ACTION_NAMES.CHANGE_VIEW, payload: pageName });
};

export const changeLanguage = (context, language) => {
  const {
    state: { lang },
    dispatch,
  } = context;

  if (lang === language) {
    return;
  }

  dispatch({ type: REDUCER_ACTION_NAMES.CHANGE_LANG, payload: language });
};

const AppContextComponent = (props) => {
  const [state, dispatch] = useReducer(reducer, initState);

  return (
    <AppContext.Provider value={{ state, dispatch }}>
      {props.children}
    </AppContext.Provider>
  );
};

export default AppContextComponent;
