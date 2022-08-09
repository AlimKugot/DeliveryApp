import 'bootstrap/dist/css/bootstrap.css';
import { useState } from 'react';
import OrderCreateForm from './components/OrderCreateForm';
import OrderUpdateForm from './components/OrderUpdateForm';

export default function App() {
  const [orders, setOrders] = useState([]);
  const [showingCreateNewOrderForm, setShowingCreateNewOrderForm] = useState(false);
  const [ordersCurrentlyBeingUpdated, setOrderCurrentlyUpdated] = useState(null);

  function getOrders() {
    const url = '/api/orders';

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(ordersFromServer => {
        setOrders(ordersFromServer);
        console.log(ordersFromServer);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  function deleteOrder(id) {
    const url = `/api/orders/${id}`;

    fetch(url, {
      method: 'DELETE'
    })
      .then(response => response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
      });
    onOrderDeleted(id);
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {(showingCreateNewOrderForm === false && ordersCurrentlyBeingUpdated === null) && (
            <div>
              <h1>ASP.NET Core React App by Alim</h1>
              <div className='mt-5'>
                <button onClick={getOrders} className='btn btn-dark btn-lg w-100'>Get orders from server</button>
                <button onClick={() => setShowingCreateNewOrderForm(true)} className='btn btn-dark btn-lg w-100 mt-4'>Create new order</button>
              </div>
            </div>
          )}


          {(orders.length > 0 && showingCreateNewOrderForm === false && ordersCurrentlyBeingUpdated === null) && renderOrdersTable()}

          {showingCreateNewOrderForm && <OrderCreateForm onOrderCreated={onOrderCreated} />}

          {ordersCurrentlyBeingUpdated !== null && <OrderUpdateForm order={ordersCurrentlyBeingUpdated} onOrderUpdated={onOrderUpdated}/>}
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
            {orders.map((order) => (
              <tr key={order.id}>
                <th scope="row">{order.id}</th>
                <td>{order.citySender}</td>
                <td>{order.addressSender}</td>
                <td>{order.cityRecipient}</td>
                <td>{order.addressRecipient}</td>
                <td>{order.cargoWeight} kg</td>
                <td>{order.receiptDateTime}</td>
                <td>
                  <button onClick={() => setOrderCurrentlyUpdated(order)} className="btn btn-dark mx-2 my-2">Update</button>
                  <button onClick={() => {if(window.confirm(`Are you sure to delete "${order.id}"?`)) deleteOrder(order.id)}} className="btn btn-secondary">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <button onClick={() => setOrders([])} className="btn btn-dark btn-lg w-100">Clean up</button>
      </div >
    )
  }

  function onOrderCreated(createdOrder) {
    setShowingCreateNewOrderForm(false);
    if (createdOrder === null) return;
    alert('Press Ok to see the result');
    getOrders();
  }

  function onOrderUpdated(updatedOrder) {
    setOrderCurrentlyUpdated(null);
    if (updatedOrder === null) return;
    let ordersCopy = [...orders];
    const index = ordersCopy.findIndex((ordersCopyOrder, currentIndex) => {
      if (ordersCopyOrder.id === updatedOrder.id) {
        return true;  
      }
    });
    if (index !== -1) ordersCopy[index] = updatedOrder;
    setOrders(ordersCopy);
  }

  function onOrderDeleted(deletedOrderId) {
    let ordersCopy = [...orders];
    const index = ordersCopy.findIndex((ordersCopyOrder, currentIndex) => {
      if (ordersCopyOrder.id === deletedOrderId) {
        return true;  
      }
    });
    if (index !== -1) ordersCopy.splice(index, 1);
    setOrders(ordersCopy);
  }
}
