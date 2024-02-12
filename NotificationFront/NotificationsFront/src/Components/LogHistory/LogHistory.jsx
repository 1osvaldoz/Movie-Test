import { useContext, useState } from "react";
import { Button, Table } from "react-bootstrap";
import AppContext from "../../Context/AppContext";
import ModalUserCategoryChannel from "../Elements/ModalUserCategoryChannel";
import "./LogHistory.css";

function BasicExample() {
  const { getData } = useContext(AppContext);
  const { LogHistoryList } = getData();
  const [showModal, setShowModal] = useState(false);
  return (
    <div className="LogHistory__container">
      <br />
      {LogHistoryList && (
        <>
          <h2>
            Log Notification{" "}
            <Button onClick={() => setShowModal(true)}>
              <i class="fa fa-info-circle" aria-hidden="true"></i>
            </Button>
          </h2>

          <Table striped bordered hover>
            <thead>
              <tr>
                <th>#</th>
                <th>Date</th>
                <th>Category</th>
                <th>Channel</th>
                <th>Message</th>
              </tr>{" "}
            </thead>
            <tbody>
              {LogHistoryList?.map((item, i) => (
                <tr key={`row${i}`}>
                  <td>{i + 1}</td>
                  <td>{item.date}</td>
                  <td>{item.categoryName}</td>
                  <td>{item.channelName}</td>
                  <td>{item.message}</td>
                </tr>
              ))}
            </tbody>
          </Table>
          <ModalUserCategoryChannel show={showModal} setShow={setShowModal} />
        </>
      )}
    </div>
  );
}

export default BasicExample;
