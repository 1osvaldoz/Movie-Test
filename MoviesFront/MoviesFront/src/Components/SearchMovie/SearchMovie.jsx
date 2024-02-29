import { useContext, useState, useEffect } from "react";
import { Container, Button, InputGroup } from "react-bootstrap";
import Select from "react-select";
import AppContext from "../../Context/AppContext";
import Form from "react-bootstrap/Form";
import ModalEmail from "../Elements/ModalEmail";
import "./SearchMovie.css";

function SearchMovie() {
  const [categoryList, setCategoryList] = useState([]);
  const [showModal, setShowModal] = useState(true);
  const [errorSelect, setErrorSelect] = useState(false);
  const [categoriesSelected, setCategoriesSelected] = useState([]);
  const [postData, setPostData] = useState({
    messageText: "",
  });
  const { CategoryRequest, MoviesRequest, checkUserSession, setLoader } =
    useContext(AppContext);
  const { token } = checkUserSession();
  useEffect(() => {
    if (token) getCategories();
  }, [token]);

  const getCategories = async () => {
    const categoriesList = await CategoryRequest.getCategories(token);
    setCategoryList(categoriesList);
  };

  const postMovie = async (e) => {
    e.preventDefault();
    const form = e.currentTarget;
    const parsePostData = {
      searchText: postData.messageText,
      categories: categoriesSelected,
    };
    if (postData.messageText =="" && categoriesSelected.length === 0) {
      setErrorSelect(true);
      e.stopPropagation();
      return false;
    }
    setLoader(true);
    const { data, error } = await MoviesRequest.Post(token, parsePostData);
    setLoader(false);

    if (error != "") {
      setPostData({
        categoryId: 0,
        messageText: "",
      });
      setErrorSelect(false);
    }
  };

  return (
    <Container className="SearchMovie__container">
      <Form onSubmit={postMovie}>
        <Form.Group className="mb-3" controlId="validationCustom01">
          <Form.Label>Category</Form.Label>

          <Select
            className={errorSelect ? "errorSelect" : ""}
            isMulti
            options={categoryList.map((item, i) => ({
              value: item.id,
              label: item.name,
            }))}
            onChange={(target) => setCategoriesSelected(target)}
          />
        </Form.Group>
        <Form.Group className="mb-3" controlId="validationCustom02">
          <Form.Label>Search by Name, Actor Or Gener</Form.Label>
          <InputGroup hasValidation>
            <Form.Control
              rows={3}
              value={postData.messageText}
              onChange={(input) => {
                setPostData({ ...postData, messageText: input.target.value });
              }}
            />
          </InputGroup>
        </Form.Group>
        <Button type="submit">
          Search <i className="fa fa-search" aria-hidden="true"></i>
        </Button>
      </Form>

      <ModalEmail show={showModal} setShow={setShowModal} />
    </Container>
  );
}

export default SearchMovie;
