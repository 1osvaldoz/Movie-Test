import { useContext, useState } from "react";
import AppContext from "../../Context/AppContext";
import { Form, Modal, Button } from "react-bootstrap";
import { useEffect } from "react";

const ModalUserCategoryChannel = ({ show, setShow }) => {
  const { UserRequest, checkUserSession } = useContext(AppContext);
  const { token } = checkUserSession();
  const [data, setData] = useState({});

  const ModalUserCategoryChannel = async (show, setShow) => {
    const { data, error } = await UserRequest.GetCategoryChannelsByUser(token);
    if (error) {
      alert(error.response.data);
    } else {
      setData(data);
    }
  };
  useEffect(() => {
    ModalUserCategoryChannel();
  }, []);
  return (
    <Modal centered show={show}>
      <Modal.Body className="centered">
        <Form.Label>
          <h2>Categories</h2>
        </Form.Label>
        {data?.categories?.map((item, i) => (
          <h6 key={`categoryItem${i}`}>
            {i + 1}. {item}
          </h6>
        ))}
        <Form.Label>
          <h2>Channels</h2>
        </Form.Label>
        {data?.channels?.map((item, i) => (
          <h6 key={`channelItem${i}`}>
            {i + 1}. {item}
          </h6>
        ))}
      </Modal.Body>
      <Modal.Footer>
        <Button variant="primary" onClick={() => setShow(false)}>
          Close
        </Button>
      </Modal.Footer>
    </Modal>
  );
};
export default ModalUserCategoryChannel;
