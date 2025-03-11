import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { useTheme } from '../contexts/ThemeContext';
import './AllCustomers.css';

function AllCustomers() {
  const { isDarkMode } = useTheme();
  const [customers, setCustomers] = useState([]);
  const [customerNotes, setCustomerNotes] = useState({});
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetchCustomersAndNotes();
  }, []);

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

  return (
    <div className={`customers-container ${isDarkMode ? 'dark' : 'light'}`}>
      <h1>All Customers</h1>
      {loading && <p>Loading customers...</p>}
      {error && <p>Error: {error}</p>}
      {customers.length > 0 && (
        <div className="customers-grid">
          {customers.map(customer => (
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
      )}
    </div>
  );
}

export default AllCustomers;