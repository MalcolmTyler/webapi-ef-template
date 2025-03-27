import { useState, useEffect } from 'react';
import { useTheme } from '../contexts/ThemeContext';
import { IconButton, Button, TextField, Dialog, DialogTitle, DialogContent, DialogActions } from '@mui/material';
import { Delete as DeleteIcon, Edit as EditIcon } from '@mui/icons-material';
import './PlantCategories.css';

function PlantCategories() {
  const { isDarkMode } = useTheme();
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [editingCategory, setEditingCategory] = useState(null);
  const [categoryDescription, setCategoryDescription] = useState('');

  useEffect(() => {
    fetchCategories();
  }, []);

  const fetchCategories = async () => {
    try {
      const response = await fetch('http://localhost:5207/api/PlantCategories');
      if (!response.ok) {
        throw new Error('Failed to fetch categories');
      }
      const data = await response.json();
      setCategories(data);
      setLoading(false);
    } catch (err) {
      setError(err.message);
      setLoading(false);
    }
  };

  const handleCreateCategory = async () => {
    try {
      const response = await fetch('http://localhost:5207/api/PlantCategories', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          categoryDescription: categoryDescription
        }),
      });

      if (!response.ok) {
        throw new Error('Failed to create category');
      }

      const newCategory = await response.json();
      setCategories(prev => [...prev, newCategory]);
      setCategoryDescription('');
      setDialogOpen(false);
    } catch (err) {
      setError(err.message);
    }
  };

  const handleUpdateCategory = async () => {
    try {
      const response = await fetch(`http://localhost:5207/api/PlantCategories/${editingCategory.categoryID}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          categoryID: editingCategory.categoryID,
          categoryDescription: categoryDescription
        }),
      });

      if (!response.ok) {
        throw new Error('Failed to update category');
      }

      setCategories(prev => prev.map(cat => 
        cat.categoryID === editingCategory.categoryID 
          ? { ...cat, categoryDescription: categoryDescription }
          : cat
      ));
      setEditingCategory(null);
      setCategoryDescription('');
      setDialogOpen(false);
    } catch (err) {
      setError(err.message);
    }
  };

  const handleDeleteCategory = async (categoryId) => {
    if (!window.confirm('Are you sure you want to delete this category?')) return;

    try {
      const response = await fetch(`http://localhost:5207/api/PlantCategories/${categoryId}`, {
        method: 'DELETE',
      });

      if (!response.ok) {
        throw new Error('Failed to delete category');
      }

      setCategories(prev => prev.filter(cat => cat.categoryID !== categoryId));
    } catch (err) {
      setError(err.message);
    }
  };

  const openCreateDialog = () => {
    setEditingCategory(null);
    setCategoryDescription('');
    setDialogOpen(true);
  };

  const openEditDialog = (category) => {
    setEditingCategory(category);
    setCategoryDescription(category.categoryDescription);
    setDialogOpen(true);
  };

  if (loading) {
    return (
      <div className={`categories-container ${isDarkMode ? 'dark' : 'light'}`}>
        <div className="loading-state">
          <div className="spinner"></div>
          <p>Loading categories...</p>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className={`categories-container ${isDarkMode ? 'dark' : 'light'}`}>
        <div className="error-state">
          <p>⚠️ {error}</p>
          <Button variant="contained" onClick={fetchCategories}>Try Again</Button>
        </div>
      </div>
    );
  }

  return (
    <div className={`categories-container ${isDarkMode ? 'dark' : 'light'}`}>
      <div className="categories-header">
        <h2>Plant Categories</h2>
        <Button variant="contained" color="primary" onClick={openCreateDialog}>
          Add Category
        </Button>
      </div>

      <div className="categories-grid">
        {categories.map(category => (
          <div key={category.categoryID} className="category-card">
            <div className="category-actions">
              <IconButton onClick={() => openEditDialog(category)} size="small">
                <EditIcon />
              </IconButton>
              <IconButton onClick={() => handleDeleteCategory(category.categoryID)} size="small">
                <DeleteIcon />
              </IconButton>
            </div>
            <h3>{category.categoryDescription}</h3>
          </div>
        ))}
      </div>

      <Dialog open={dialogOpen} onClose={() => setDialogOpen(false)}>
        <DialogTitle>
          {editingCategory ? 'Edit Category' : 'New Category'}
        </DialogTitle>
        <DialogContent>
          <TextField
            autoFocus
            margin="dense"
            label="Category Description"
            type="text"
            fullWidth
            value={categoryDescription}
            onChange={(e) => setCategoryDescription(e.target.value)}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setDialogOpen(false)}>Cancel</Button>
          <Button onClick={editingCategory ? handleUpdateCategory : handleCreateCategory}>
            {editingCategory ? 'Update' : 'Create'}
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}

export default PlantCategories;