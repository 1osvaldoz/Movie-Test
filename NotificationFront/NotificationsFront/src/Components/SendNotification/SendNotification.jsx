import { useContext, useState, useEffect } from "react";
import {
  Container,
  Dropdown,
  DropdownButton,
  Button,
  InputGroup,
} from "react-bootstrap";
import AppContext from "../../Context/AppContext";
import Form from "react-bootstrap/Form";
import "./SendNotification.css";
import ModalEmail from "../Elements/ModalEmail";

function Home() {
  const [categoryList, setCategoryList] = useState([]);
  const [showModal, setShowModal] = useState(true);
  const [errorSelect, setErrorSelect] = useState(false);
  const [postData, setPostData] = useState({
    categoryId: 0,
    messageText: "",
  });
  const {
    CategoryRequest,
    NotificationLogRequest,
    checkUserSession,
    setLoader,
  } = useContext(AppContext);
  const { token } = checkUserSession();
  useEffect(() => {
    if (token) getCategories();
  }, [token]);

  const getCategories = async () => {
    const categoriesList = await CategoryRequest.getCategories(token);
    setCategoryList(categoriesList);
  };
  const postNotification = async (e) => {
    e.preventDefault();
    const form = e.currentTarget;

    if (form.checkValidity() === false || postData.categoryId === 0) {
      setErrorSelect(true);
      e.stopPropagation();
      return false;
    }
    setLoader(true);
    await NotificationLogRequest.Post(token, postData);
    await NotificationLogRequest.Get(token);
    setLoader(false);

    setPostData({
      categoryId: 0,
      messageText: "",
    });
    setErrorSelect(false);
  };

  return (
    <Container className="SendNotification__container">
      <Form onSubmit={postNotification}>
        <Form.Group className="mb-3" controlId="validationCustom01">
          <Form.Label>Category</Form.Label>
          <Form.Select
            size="lg"
            onChange={(input) => {
              setPostData({
                ...postData,
                categoryId: Number(input.target.value),
              });
              if (Number(input.target.value) == 0) {
                setErrorSelect(true);
              }
            }}
            value={postData.categoryId}
            isInvalid={errorSelect}
          >
            <option value={0}>{"- Select Category -"}</option>
            {categoryList.map((item, i) => (
              <option key={`cmbCategoriesItem${item.id}`} value={item.id}>
                {item.name}
              </option>
            ))}
          </Form.Select>
        </Form.Group>
        <Form.Group className="mb-3" controlId="validationCustom02">
          <Form.Label>Message</Form.Label>
          <InputGroup hasValidation>
            <Form.Control
              as="textarea"
              required
              rows={3}
              value={postData.messageText}
              onChange={(input) => {
                setPostData({ ...postData, messageText: input.target.value });
              }}
            />
          </InputGroup>
        </Form.Group>
        <Button variant="danger" onClick={() => setShowModal(true)}>
          Change User
        </Button>{" "}
        <Button variant="success" type="submit">
          Send notification
        </Button>
      </Form>
      <ModalEmail show={showModal} setShow={setShowModal} />
    </Container>
  );
}

export default Home;
