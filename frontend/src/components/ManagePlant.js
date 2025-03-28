import { useState, useEffect } from 'react';
import { useTheme } from '../contexts/ThemeContext';
import { 
  IconButton, 
  Button, 
  TextField, 
  Dialog, 
  DialogTitle, 
  DialogContent, 
  DialogActions,
  MenuItem,
  InputLabel,
  FormControl,
  Select
} from '@mui/material';
import { Delete as DeleteIcon, Edit as EditIcon } from '@mui/icons-material';
import './ManagePlant.css';

function ManagePlant() {
  const { isDarkMode } = useTheme();
  const [plants, setPlants] = useState([]);
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [editingPlant, setEditingPlant] = useState(null);
  const [plantData, setPlantData] = useState({
    plantDescription: '',
    plantCategory: '',
    normalPrice: ''
  });

  useEffect(() => {
    Promise.all([fetchPlants(), fetchCategories()]);
  }, []);

  const fetchPlants = async () => {
    try {
      const response = await fetch('http://localhost:5207/api/AllPlant');
      if (!response.ok) {
        throw new Error('Failed to fetch plants');
      }
      const data = await response.json();
      setPlants(data);
      setLoading(false);
    } catch (err) {
      setError(err.message);
      setLoading(false);
    }
  };

  const fetchCategories = async () => {
    try {
      const response = await fetch('http://localhost:5207/api/PlantCategories');
      if (!response.ok) {
        throw new Error('Failed to fetch categories');
      }
      const data = await response.json();
      setCategories(data);
    } catch (err) {
      setError(err.message);
    }
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setPlantData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleCreatePlant = async () => {
    try {
      const response = await fetch('http://localhost:5207/api/AllPlant', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(plantData),
      });

      if (!response.ok) {
        throw new Error('Failed to create plant');
      }

      const newPlant = await response.json();
      setPlants(prev => [...prev, newPlant]);
      setPlantData({
        plantDescription: '',
        plantCategory: '',
        normalPrice: ''
      });
      setDialogOpen(false);
    } catch (err) {
      setError(err.message);
    }
  };

  const handleUpdatePlant = async () => {
    try {
      const response = await fetch(`http://localhost:5207/api/AllPlant/${editingPlant.plantNameID}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          ...plantData,
          plantNameID: editingPlant.plantNameID
        }),
      });

      if (!response.ok) {
        throw new Error('Failed to update plant');
      }

      setPlants(prev => prev.map(plant => 
        plant.plantNameID === editingPlant.plantNameID 
          ? { ...plant, ...plantData }
          : plant
      ));
      setEditingPlant(null);
      setPlantData({
        plantDescription: '',
        plantCategory: '',
        normalPrice: ''
      });
      setDialogOpen(false);
    } catch (err) {
      setError(err.message);
    }
  };

  const handleDeletePlant = async (plantId) => {
    if (!window.confirm('Are you sure you want to delete this plant?')) return;

    try {
      const response = await fetch(`http://localhost:5207/api/AllPlant/${plantId}`, {
        method: 'DELETE',
      });

      if (!response.ok) {
        // Try to get the error message from the response
        const errorData = await response.text();
        if (response.status === 500 && errorData.includes("DELETE statement conflicted with the REFERENCE constraint")) {
          throw new Error('This plant cannot be deleted because it is currently in use');
        }
        throw new Error('Failed to delete plant');
      }

      setPlants(prev => prev.filter(plant => plant.plantNameID !== plantId));
    } catch (err) {
      setError(err.message);
    }
  };

  const openCreateDialog = () => {
    setEditingPlant(null);
    setPlantData({
      plantDescription: '',
      plantCategory: '',
      normalPrice: ''
    });
    setDialogOpen(true);
  };

  const openEditDialog = (plant) => {
    setEditingPlant(plant);
    setPlantData({
      plantDescription: plant.plantDescription,
      plantCategory: plant.plantCategory,
      normalPrice: plant.normalPrice
    });
    setDialogOpen(true);
  };

  const getCategoryDescription = (categoryId) => {
    const category = categories.find(cat => cat.categoryID === categoryId);
    return category ? category.categoryDescription : 'Unknown Category';
  };

  if (loading) {
    return (
      <div className={`plants-container ${isDarkMode ? 'dark' : 'light'}`}>
        <div className="loading-state">
          <div className="spinner"></div>
          <p>Loading plants...</p>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className={`plants-container ${isDarkMode ? 'dark' : 'light'}`}>
        <div className="error-state">
          <p>⚠️ {error}</p>
          <Button variant="contained" onClick={() => Promise.all([fetchPlants(), fetchCategories()])}>
            Try Again
          </Button>
        </div>
      </div>
    );
  }

  return (
    <div className={`plants-container ${isDarkMode ? 'dark' : 'light'}`}>
      <div className="plants-header">
        <h2>Manage Plants</h2>
        <Button variant="contained" color="primary" onClick={openCreateDialog}>
          Add Plant
        </Button>
      </div>

      <div className="plants-grid">
        {plants.map(plant => (
          <div key={plant.plantNameID} className="plant-card">
            <div className="plant-actions">
              <IconButton onClick={() => openEditDialog(plant)} size="small">
                <EditIcon />
              </IconButton>
              <IconButton onClick={() => handleDeletePlant(plant.plantNameID)} size="small">
                <DeleteIcon />
              </IconButton>
            </div>
            <h3>{plant.plantDescription}</h3>
            <p><strong>Category:</strong> {getCategoryDescription(plant.plantCategory)}</p>
            <p><strong>Price:</strong> £{plant.normalPrice}</p>
          </div>
        ))}
      </div>

      <Dialog open={dialogOpen} onClose={() => setDialogOpen(false)}>
        <DialogTitle>
          {editingPlant ? 'Edit Plant' : 'New Plant'}
        </DialogTitle>
        <DialogContent>
          <TextField
            autoFocus
            margin="dense"
            name="plantDescription"
            label="Plant Description"
            type="text"
            fullWidth
            value={plantData.plantDescription}
            onChange={handleInputChange}
          />
          <FormControl fullWidth margin="dense">
            <InputLabel>Category</InputLabel>
            <Select
              name="plantCategory"
              value={plantData.plantCategory}
              onChange={handleInputChange}
              label="Category"
            >
              {categories.map(category => (
                <MenuItem key={category.categoryID} value={category.categoryID}>
                  {category.categoryDescription}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          <TextField
            margin="dense"
            name="normalPrice"
            label="Price"
            type="text"
            fullWidth
            value={plantData.normalPrice}
            onChange={handleInputChange}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setDialogOpen(false)}>Cancel</Button>
          <Button onClick={editingPlant ? handleUpdatePlant : handleCreatePlant}>
            {editingPlant ? 'Update' : 'Create'}
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}

export default ManagePlant;