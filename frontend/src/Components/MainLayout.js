import React from "react";
import { NavLink } from "react-router-dom";

export const MainLayout = ({ children }) => {
  return (
    <>
      <div className="navbar navbar-expand navbar-light fixed-top ">
        <div className="container">
          <NavLink className="navbar-brand" to={"/"}>
            Home
          </NavLink>
          </div>
      </div>
      <div className="auth-wrapper container">{children}</div>
    </>
  );
};
