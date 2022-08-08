import React, { useState } from 'react'

export default function PostCreateForm(props) {
    const initialFormData = Object.freeze({
        citySender: "Los-Angeles",
        addressSender: "st. Vashington",
        cityRecipient: "New-York",
        addressRecipient: "Wall Street",
        cargoWeight: "1.5",
        receiptDateTime: "2021-05-11T12:00:00Z"
    });
    const [formData, setFormData] = useState(initialFormData);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        const orderToCreate = {
            orderId: 0,
            citySender: formData.citySender,
            addressSender: formData.addressSender,
            cityRecipient: formData.cityRecipient,
            addressRecipient: formData.addressRecipient,
            cargoWeight: formData.cargoWeight,
            receiptDateTime: formData.receiptDateTime
        }

        const url = "/api/orders";

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(orderToCreate)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
            });
        props.onOrderCreated(orderToCreate);
    };

    return (
        <div className='container'>
            <div className='row mt-5 mb-5 min-vh-100'>
                <div className='col d-flex flex-column justify-content-center align-items-center'>
                    <form className="row g-3 w-50 h-40">
                        <h1 className="mt-5 mb-5 text-center"> Create new order</h1>

                        <div className='col-12'>
                            <label class="form-label">Sender's city</label>
                            <input value={formData.citySender} name="citySender" type="text" class="form-control" onChange={handleChange} />
                        </div>
                        <div className="col-12">
                            <label class="form-label">Sender's address</label>
                            <input value={formData.addressSender} name="addressSender" type="text" class="form-control" onChange={handleChange} />
                        </div>

                        <div className="col-12">
                            <label class="form-label">Recipient's city</label>
                            <input value={formData.cityRecipient} name="cityRecipient" type="text" class="form-control" onChange={handleChange} />
                        </div>

                        <div className="col-12">
                            <label class="form-label">Recipient's address:</label>
                            <input value={formData.addressRecipient} name="addressRecipient" type="text" class="form-control" onChange={handleChange} />
                        </div>

                        <div className="col-12">
                            <label class="form-label">Cargo Weight (kg)</label>
                            <input value={formData.cargoWeight} name="cargoWeight" type="double" class="form-control" onChange={handleChange} />
                        </div>

                        <div className="col-12">
                            <label class="form-label">ReceiptDateTime</label>
                            <input value={formData.receiptDateTime} name="receiptDateTime" type="datetime" class="form-control" onChange={handleChange} />
                        </div>

                        <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
                        <button onClick={() => props.onOrderCreated(null)} className="btn btn-danger btn-lg w-100 mt-3">Cancel</button>
                    </form>
                </div>
            </div>
        </div>
    )
}
