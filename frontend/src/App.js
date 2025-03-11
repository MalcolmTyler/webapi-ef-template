import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import { IconButton } from '@mui/material';
import { Brightness4, Brightness7 } from '@mui/icons-material';
import './App.css';
import AllForecasts from './components/AllForecasts';
import AllCustomers from './components/AllCustomers';
import CustomerNotes from './components/CustomerNotes';
import { ThemeProvider, useTheme } from './contexts/ThemeContext';
import './components/AllForecasts.css';
import './components/AllCustomers.css';
import './components/CustomerNotes.css';

function RandomForecast() {
  const [weatherData, setWeatherData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetchWeatherData();
  }, []);

  const fetchWeatherData = async () => {
    setLoading(true);
    try {
      const response = await fetch('http://localhost:5207/api/Summaries');
      if (!response.ok) {
        throw new Error('Failed to fetch weather data');
      }
      const data = await response.json();
      const randomIndex = Math.floor(Math.random() * data.length);
      setWeatherData(data[randomIndex]);
      setError(null);
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="random-forecast">
      <h1>Today's Weather</h1>
      {loading && (
        <div className="loading-state">
          <div className="spinner"></div>
          <p>Loading weather data...</p>
        </div>
      )}
      {error && (
        <div className="error-state">
          <p>⚠️ {error}</p>
          <button onClick={fetchWeatherData}>Try Again</button>
        </div>
      )}
      {!loading && !error && weatherData && (
        <div className="forecast-card">
          <h3>Weather Type</h3>
          <p className="description">{weatherData.description}</p>
          {weatherData.title && <p className="title">{weatherData.title}</p>}
          <button onClick={fetchWeatherData}>Get New Forecast</button>
        </div>
      )}
    </div>
  );
}

function AppContent() {
  const { isDarkMode, toggleTheme } = useTheme();
  
  return (
    <div className={`App ${isDarkMode ? 'dark' : 'light'}`}>
      <header className="App-header">
        <nav>
          <div className="nav-links">
            <Link to="/" className="nav-link home-link">🏠 Home</Link>
            <Link to="/all" className="nav-link">All Forecasts</Link>
            <Link to="/customers" className="nav-link">All Customers</Link>
          </div>
          <IconButton onClick={toggleTheme} color="inherit" className="theme-toggle">
            {isDarkMode ? <Brightness7 /> : <Brightness4 />}
          </IconButton>
        </nav>
        
        <Routes>
          <Route path="/" element={<RandomForecast />} />
          <Route path="/all" element={<AllForecasts />} />
          <Route path="/customers" element={<AllCustomers />} />
          <Route path="/customers/:custId/notes" element={<CustomerNotes />} />
        </Routes>
      </header>
    </div>
  );
}

function App() {
  return (
    <ThemeProvider>
      <Router>
        <AppContent />
      </Router>
    </ThemeProvider>
  );
}

export default App;
