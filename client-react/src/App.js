import 'bootstrap/dist/css/bootstrap.css';
import { useState } from 'react';

function App() {
  const [orders, setOrders] = useState([]);

  function getOrders() {
    const url = '/api/orders';

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(ordersFromServer => {
        console.log(ordersFromServer);
        setOrders(ordersFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
            <h1>ASP.NET Core React App by Alim</h1>
            <div className='mt-5'>
              <button onClick={getOrders} className='btn btn-dark btn-lg w-100'>Get orders from server</button>
              <button onClick={() => { }} className='btn btn-secondary btn-lg w-100 mt-4'>Create new order</button>
            </div>
          </div>

          {renderOrdersTable()}
        </div>
      </div>
    </div>
  );

  function renderOrdersTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr className='w-130'>
              <th scope="col">OrderID (PK)</th>
              <th scope="col">City Sender</th>
              <th scope="col">Address Sender</th>
              <th scope="col">City Recipient</th>
              <th scope="col">Address Recipient</th>
              <th scope="col">Cargo Weight</th>
              <th scope="col">ReceiptDateTime</th>
              <th scope="col">CRUD Operations</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th scope="row">1</th>
              <td>Order 1 city sender</td>
              <td>Order 1 address sender</td>
              <td>Order 1 city recipient</td>
              <td>Order 1 address recipient</td>
              <td>5 kg</td>
              <td>06.08.2020</td>
              <td>
                <button className="btn btn-dark mx-2 my-2">Update</button>
                <button className="btn btn-secondary">Delete</button>
              </td>
            </tr>
          </tbody>
        </table>
      </div >
    )
  }
}

export default App;