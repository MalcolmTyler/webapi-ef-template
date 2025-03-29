import React, { useState, useEffect } from 'react';
import { format } from 'date-fns';
import { 
    IconButton, 
    Button,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper,
    Dialog,
    DialogContent
} from '@mui/material';
import { 
    Edit as EditIcon, 
    Delete as DeleteIcon, 
    Add as AddIcon,
    WorkspacePremium as CertificateIcon 
} from '@mui/icons-material';
import { useTheme } from '../contexts/ThemeContext';
import InspectionForm from './InspectionForm';
import inspectionService from '../services/inspectionService';
import './InspectionList.css';
import CertificateViewer from './CertificateViewer';

const InspectionList = ({ holdingId }) => {
    const { isDarkMode } = useTheme();
    const [inspections, setInspections] = useState([]);
    const [showForm, setShowForm] = useState(false);
    const [selectedInspection, setSelectedInspection] = useState(null);
    const [error, setError] = useState(null);
    const [showCertificate, setShowCertificate] = useState(false);
    const [certificateInspection, setCertificateInspection] = useState(null);

    useEffect(() => {
        if (holdingId) {
            loadInspections();
        }
    }, [holdingId]);

    const loadInspections = async () => {
        try {
            const data = await inspectionService.getByPlantHolding(holdingId);
            setInspections(data);
            setError(null);
        } catch (error) {
            console.error('Error loading inspections:', error);
            setError('Failed to load inspections');
        }
    };

    const handleAdd = () => {
        setSelectedInspection(null);
        setShowForm(true);
        setError(null);
    };

    const handleEdit = (inspection) => {
        setSelectedInspection(inspection);
        setShowForm(true);
        setError(null);
    };

    const handleDelete = async (id) => {
        if (window.confirm('Are you sure you want to delete this inspection?')) {
            try {
                await inspectionService.remove(id);
                await loadInspections();
                setError(null);
            } catch (error) {
                console.error('Error deleting inspection:', error);
                setError('Failed to delete inspection');
            }
        }
    };

    const handleSubmit = async (formData) => {
        try {
            const submissionData = {
                ...formData,
                holdingID: holdingId
            };
            
            if (selectedInspection) {
                await inspectionService.update(selectedInspection.uniqueRef, submissionData);
            } else {
                await inspectionService.create(submissionData);
            }
            setShowForm(false);
            await loadInspections();
            setError(null);
        } catch (error) {
            console.error('Error saving inspection:', error);
            setError('Failed to save inspection');
        }
    };

    const formatDate = (date) => {
        if (!date) return '';
        return format(new Date(date), 'dd/MM/yyyy');
    };

    const handleShowCertificate = (inspection) => {
        setCertificateInspection(inspection);
        setShowCertificate(true);
    };

    return (
        <div className={`space-y-4 ${isDarkMode ? 'dark' : 'light'}`}>
            <div className="flex justify-between items-center mb-4">
                <h2 className="text-xl font-bold">Inspections</h2>
                <Button
                    variant="contained"
                    color="primary"
                    startIcon={<AddIcon />}
                    onClick={handleAdd}
                >
                    Add Inspection
                </Button>
            </div>

            {error && (
                <div className="p-4 mb-4 text-sm text-red-700 bg-red-100 rounded-lg">
                    {error}
                </div>
            )}

            <TableContainer component={Paper}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell width="25%">Inspection Date</TableCell>
                            <TableCell width="40%">Location</TableCell>
                            <TableCell width="25%">Latest Date</TableCell>
                            <TableCell width="10%" align="center">Actions</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {inspections.map((inspection) => (
                            <TableRow key={inspection.uniqueRef} hover>
                                <TableCell>{formatDate(inspection.inspectionDate)}</TableCell>
                                <TableCell>{inspection.location}</TableCell>
                                <TableCell>{formatDate(inspection.latestDate)}</TableCell>
                                <TableCell align="center">
                                    <div className="flex justify-center space-x-2">
                                        <IconButton
                                            size="small"
                                            onClick={() => handleEdit(inspection)}
                                            color="primary"
                                        >
                                            <EditIcon fontSize="small" />
                                        </IconButton>
                                        <IconButton
                                            size="small"
                                            onClick={() => handleDelete(inspection.uniqueRef)}
                                            color="error"
                                        >
                                            <DeleteIcon fontSize="small" />
                                        </IconButton>
                                        <IconButton
                                            size="small"
                                            onClick={() => handleShowCertificate(inspection)}
                                            color="secondary"
                                        >
                                            <CertificateIcon fontSize="small" />
                                        </IconButton>
                                    </div>
                                </TableCell>
                            </TableRow>
                        ))}
                        {inspections.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={4} align="center">
                                    No inspections found
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </TableContainer>

            {showForm && (
                <div>
                    <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center p-4"></div>
                    <div className="bg-white rounded-lg shadow-xl max-w-4xl w-full max-h-[90vh] overflow-y-auto">
                        <div className="p-4">
                            <h3 className="text-lg font-semibold mb-4">
                                {selectedInspection ? 'Edit Inspection' : 'New Inspection'}
                            </h3>
                            <InspectionForm
                                inspection={selectedInspection}
                                onSubmit={handleSubmit}
                                onCancel={() => setShowForm(false)}
                                holdingId={holdingId}
                            />
                        </div>
                    </div>
                </div>
            )}

            <Dialog 
                open={showCertificate} 
                onClose={() => setShowCertificate(false)}
                maxWidth="xl"
                fullWidth
                PaperProps={{
                    style: { 
                        minHeight: '90vh',
                        maxWidth: '1200px',
                        backgroundColor: isDarkMode ? '#1a1a1a' : '#ffffff'
                    }
                }}
            >
                <DialogContent style={{ padding: 0 }}>
                    {certificateInspection && (
                        <CertificateViewer 
                            inspection={certificateInspection}
                        />
                    )}
                </DialogContent>
            </Dialog>
        </div>
    );
};

export default InspectionList;