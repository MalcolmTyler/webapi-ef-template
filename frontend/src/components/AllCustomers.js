import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { useTheme } from '../contexts/ThemeContext';
import './AllCustomers.css';

function AllCustomers() {
  const { isDarkMode } = useTheme();
  const [customers, setCustomers] = useState([]);
  const [filteredCustomers, setFilteredCustomers] = useState([]);
  const [customerNotes, setCustomerNotes] = useState({});
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [showForm, setShowForm] = useState(false);
  const [searchTerm, setSearchTerm] = useState('');
  const [newCustomer, setNewCustomer] = useState({
    companyName: '',
    contactTitle: '',
    contactFirstNames: '',
    contactSurname: '',
    line1: '',
    line2: '',
    line3: '',
    line4: '',
    postcode: '',
    telephone: '',
    fax: '',
    email: '',
    mailshot: false
  });

  useEffect(() => {
    fetchCustomersAndNotes();
  }, []);

  useEffect(() => {
    if (customers.length > 0) {
      const filtered = customers.filter(customer => {
        const searchString = searchTerm.toLowerCase();
        return (
          customer.companyName?.toLowerCase().includes(searchString) ||
          customer.contactFirstNames?.toLowerCase().includes(searchString) ||
          customer.contactSurname?.toLowerCase().includes(searchString) ||
          customer.email?.toLowerCase().includes(searchString) ||
          customer.telephone?.includes(searchString) ||
          customer.line1?.toLowerCase().includes(searchString) ||
          customer.postcode?.toLowerCase().includes(searchString)
        );
      });
      setFilteredCustomers(filtered);
    }
  }, [searchTerm, customers]);

  const fetchCustomersAndNotes = async () => {
    try {
      const [customersResponse, notesResponse] = await Promise.all([
        fetch('http://localhost:5207/api/Customers'),
        fetch('http://localhost:5207/api/Notes')
      ]);

      if (!customersResponse.ok || !notesResponse.ok) {
        throw new Error('Failed to fetch data');
      }

      const [customersData, notesData] = await Promise.all([
        customersResponse.json(),
        notesResponse.json()
      ]);

      // Create a map of customer IDs to their note counts
      const notesMap = notesData.reduce((acc, note) => {
        acc[note.custID] = (acc[note.custID] || 0) + 1;
        return acc;
      }, {});

      setCustomers(customersData);
      setCustomerNotes(notesMap);
      setLoading(false);
    } catch (err) {
      setError(err.message);
      setLoading(false);
    }
  };

  const handleInputChange = (e) => {
    const { name, value, type, checked } = e.target;
    setNewCustomer(prev => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch('http://localhost:5207/api/Customers', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newCustomer)
      });

      if (!response.ok) {
        throw new Error('Failed to create customer');
      }

      const createdCustomer = await response.json();
      setCustomers(prev => [...prev, createdCustomer]);
      setNewCustomer({
        companyName: '',
        contactTitle: '',
        contactFirstNames: '',
        contactSurname: '',
        line1: '',
        line2: '',
        line3: '',
        line4: '',
        postcode: '',
        telephone: '',
        fax: '',
        email: '',
        mailshot: false
      });
      setShowForm(false);
    } catch (err) {
      setError(err.message);
    }
  };

  return (
    <div className={`customers-container ${isDarkMode ? 'dark' : 'light'}`}>
      <div className="header-actions">
        <h1>All Customers</h1>
        <button onClick={() => setShowForm(!showForm)} className="add-customer-btn">
          {showForm ? 'Cancel' : 'Add New Customer'}
        </button>
      </div>

      <div className="search-container">
        <input
          type="text"
          placeholder="Search customers..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          className="search-input"
        />
      </div>

      {showForm && (
        <form onSubmit={handleSubmit} className="customer-form">
          <div className="form-row">
            <input
              type="text"
              name="companyName"
              value={newCustomer.companyName}
              onChange={handleInputChange}
              placeholder="Company Name"
              required
            />
            <input
              type="text"
              name="contactTitle"
              value={newCustomer.contactTitle}
              onChange={handleInputChange}
              placeholder="Contact Title"
            />
          </div>
          <div className="form-row">
            <input
              type="text"
              name="contactFirstNames"
              value={newCustomer.contactFirstNames}
              onChange={handleInputChange}
              placeholder="First Names"
            />
            <input
              type="text"
              name="contactSurname"
              value={newCustomer.contactSurname}
              onChange={handleInputChange}
              placeholder="Surname"
            />
          </div>
          <div className="form-row">
            <input
              type="text"
              name="line1"
              value={newCustomer.line1}
              onChange={handleInputChange}
              placeholder="Address Line 1"
            />
            <input
              type="text"
              name="line2"
              value={newCustomer.line2}
              onChange={handleInputChange}
              placeholder="Address Line 2"
            />
          </div>
          <div className="form-row">
            <input
              type="text"
              name="line3"
              value={newCustomer.line3}
              onChange={handleInputChange}
              placeholder="Address Line 3"
            />
            <input
              type="text"
              name="line4"
              value={newCustomer.line4}
              onChange={handleInputChange}
              placeholder="Address Line 4"
            />
          </div>
          <div className="form-row">
            <input
              type="text"
              name="postcode"
              value={newCustomer.postcode}
              onChange={handleInputChange}
              placeholder="Postcode"
            />
            <input
              type="tel"
              name="telephone"
              value={newCustomer.telephone}
              onChange={handleInputChange}
              placeholder="Telephone"
            />
          </div>
          <div className="form-row">
            <input
              type="tel"
              name="fax"
              value={newCustomer.fax}
              onChange={handleInputChange}
              placeholder="Fax"
            />
            <input
              type="email"
              name="email"
              value={newCustomer.email}
              onChange={handleInputChange}
              placeholder="Email"
            />
          </div>
          <div className="form-row">
            <label>
              <input
                type="checkbox"
                name="mailshot"
                checked={newCustomer.mailshot}
                onChange={handleInputChange}
              />
              Mailshot
            </label>
          </div>
          <button type="submit" className="submit-btn">Create Customer</button>
        </form>
      )}

      {loading && <p>Loading customers...</p>}
      {error && <p>Error: {error}</p>}
      {filteredCustomers.length > 0 ? (
        <div className="customers-grid">
          {filteredCustomers.map(customer => (
            <div key={customer.custID} className="customer-card">
              <h3>{customer.companyName}</h3>
              <p>Contact: {customer.contactTitle} {customer.contactFirstNames} {customer.contactSurname}</p>
              <p>Email: {customer.email}</p>
              <p>Phone: {customer.telephone}</p>
              <div className="address">
                <p>{customer.line1}</p>
                {customer.line2 && <p>{customer.line2}</p>}
                {customer.line3 && <p>{customer.line3}</p>}
                {customer.line4 && <p>{customer.line4}</p>}
                <p>{customer.postcode}</p>
              </div>
              {customerNotes[customer.custID] > 0 && (
                <Link 
                  to={`/customers/${customer.custID}/notes`} 
                  className="notes-link"
                >
                  View Notes ({customerNotes[customer.custID]})
                </Link>
              )}
            </div>
          ))}
        </div>
      ) : (
        <p className="no-results">No customers found matching your search.</p>
      )}
    </div>
  );
}

export default AllCustomers;