import { useContext, useState } from "react";
import AppContext from "../../Context/AppContext";
import { Spinner, Modal } from "react-bootstrap";
import "./Loader.css";
const Loader = () => {
  const { showLoader } = useContext(AppContext);

  return (
    <div className={`ModalLoader__container ${!showLoader&& "hide"}`}>
      <Spinner animation="grow" variant="primary" />
      <Spinner animation="grow" variant="secondary" />
      <Spinner animation="grow" variant="success" />
      <Spinner animation="grow" variant="danger" />
      <Spinner animation="grow" variant="warning" />
      <Spinner animation="grow" variant="info" />
      <Spinner animation="grow" variant="light" />
      <Spinner animation="grow" variant="dark" />
    </div>
  );
};
export default Loader;
