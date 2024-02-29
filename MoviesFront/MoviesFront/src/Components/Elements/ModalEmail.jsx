import { useContext, useState } from "react";
import AppContext from "../../Context/AppContext";
import { Form, Modal, Button } from "react-bootstrap";
import "./ModalEmail.css";
const ModalEmail = ({ show, setShow }) => {
  const [email, setEmail] = useState("user1@gmail.com");
  const { LoginRequest, checkUserSession } = useContext(AppContext);
  const { token } = checkUserSession();
  const login = async () => {
    const { data, error } = await LoginRequest.Login(email);
    if (error) {
      alert(error.response.data);
    } else {
      setShow(false);
    }
  };
  return (
    <Modal centered show={show}>
      <Modal.Body className="centered">
        <Form.Label>Email</Form.Label>
        <Form.Control
          type="email"
          placeholder="name@example.com"
          value={email}
          onChange={(input) => setEmail(input.target.value)}
        />
      </Modal.Body>
      <Modal.Footer>
        <Button variant="primary" onClick={() => login()}>
          Login
        </Button>
        <Button variant="danger" onClick={() => setShow(false)}>
          Close
        </Button>
      </Modal.Footer>
    </Modal>
  );
};
export default ModalEmail;
