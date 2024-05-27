/* eslint-disable react/prop-types */
import { useContext } from "react";
import "./Modal.Module.css";
import { ModalContext } from "../../App";

const Modal = () => {
  const [openModal, setOpenModal, content] = useContext(ModalContext);
  const onCloseModal = () => setOpenModal(!openModal);
  if (!openModal) return null;
  return (
    <div className="Overlay" onClick={onCloseModal}>
      <div
        className="Modal"
        onClick={(e) => {
          e.stopPropagation();
        }}
      >
        <button
          className="btn btn-outline-danger CloseButton"
          onClick={onCloseModal}
        >
          <i
            className="bi bi-x-square-fill"
            style={{
              color: "red",
              fontSize: "clamp(2rem, 2rem + 1vw, 4rem)",
            }}
          ></i>
        </button>
        {content}
      </div>
    </div>
  );
};

export default Modal;
