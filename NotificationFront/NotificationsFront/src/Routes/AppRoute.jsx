import React, { useContext } from "react";
import {  Route } from "react-router-dom";
import AppContext from "../Context/AppContext";

const AppRoute = ({
  component: Component,
  path,
  isPrivate,
  exact,
  ...rest
}) => {
  return (
    <Route
      exact={exact}
      path={path}
      render={(props) => <Component {...props} />}
      {...rest}
    />
  );
};

export default AppRoute;
