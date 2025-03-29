import React, { useState, useEffect } from 'react';
import DatePicker from 'react-datepicker';
import { format } from 'date-fns';
import "react-datepicker/dist/react-datepicker.css";
import "./InspectionForm.css";

const InspectionForm = ({ inspection, onSubmit, onCancel, holdingId }) => {
    const [formData, setFormData] = useState({
        holdingID: holdingId || '',
        inspectionDate: null,
        location: '',
        vehicleInspectedOn: '',
        recentCheck: '',
        previousCheck: '',
        safeWorking: '',
        defects: '',
        rectified: '',
        latestDate: null,
        testDetails: '',
        miscNotes: '',
        hasSubPlant: false
    });

    useEffect(() => {
        if (inspection) {
            setFormData({
                ...inspection,
                inspectionDate: inspection.inspectionDate ? new Date(inspection.inspectionDate) : null,
                latestDate: inspection.latestDate ? new Date(inspection.latestDate) : null,
                vehicleInspectedOn: inspection.vehicleInspectedOn?.toString() || ''
            });
        } else {
            setFormData(prev => ({
                ...prev,
                holdingID: holdingId
            }));
        }
    }, [inspection, holdingId]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setFormData(prev => ({
            ...prev,
            [name]: type === 'checkbox' ? checked : value
        }));
    };

    const handleDateChange = (date, fieldName) => {
        setFormData(prev => ({
            ...prev,
            [fieldName]: date
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        const submissionData = {
            ...formData,
            holdingID: parseInt(holdingId),
            vehicleInspectedOn: formData.vehicleInspectedOn ? parseInt(formData.vehicleInspectedOn) : null,
            inspectionDate: formData.inspectionDate ? formData.inspectionDate.toISOString() : null,
            latestDate: formData.latestDate ? formData.latestDate.toISOString() : null
        };
        onSubmit(submissionData);
    };

    return (
        <form onSubmit={handleSubmit} className="space-y-6 max-w-4xl mx-auto p-4">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-x-6 gap-y-8">
                <div className="form-group">
                    <label className="block text-sm font-medium text-gray-700 mb-2">Inspection Date</label>
                    <DatePicker
                        selected={formData.inspectionDate}
                        onChange={(date) => handleDateChange(date, 'inspectionDate')}
                        dateFormat="dd/MM/yyyy"
                        className="w-full px-3 py-2 rounded-md border border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
                        placeholderText="Select date"
                    />
                </div>

                <div className="form-group">
                    <label className="block text-sm font-medium text-gray-700 mb-2">Location</label>
                    <input
                        type="text"
                        name="location"
                        value={formData.location || ''}
                        onChange={handleChange}
                        className="w-full px-3 py-2 rounded-md border border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
                    />
                </div>

                <div className="form-group">
                    <label className="block text-sm font-medium text-gray-700 mb-2">Vehicle Inspected On</label>
                    <input
                        type="number"
                        name="vehicleInspectedOn"
                        value={formData.vehicleInspectedOn || ''}
                        onChange={handleChange}
                        className="w-full px-3 py-2 rounded-md border border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
                    />
                </div>

                <div className="form-group">
                    <label className="block text-sm font-medium text-gray-700 mb-2">Recent Check</label>
                    <input
                        type="text"
                        name="recentCheck"
                        value={formData.recentCheck || ''}
                        onChange={handleChange}
                        className="w-full px-3 py-2 rounded-md border border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
                    />
                </div>

                <div className="form-group">
                    <label className="block text-sm font-medium text-gray-700 mb-2">Previous Check</label>
                    <input
                        type="text"
                        name="previousCheck"
                        value={formData.previousCheck || ''}
                        onChange={handleChange}
                        className="w-full px-3 py-2 rounded-md border border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
                    />
                </div>

                <div className="form-group">
                    <label className="block text-sm font-medium text-gray-700 mb-2">Safe Working</label>
                    <input
                        type="text"
                        name="safeWorking"
                        value={formData.safeWorking || ''}
                        onChange={handleChange}
                        className="w-full px-3 py-2 rounded-md border border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
                    />
                </div>

                <div className="form-group md:col-span-2">
                    <label className="block text-sm font-medium text-gray-700 mb-2">Defects</label>
                    <textarea
                        name="defects"
                        value={formData.defects || ''}
                        onChange={handleChange}
                        rows="3"
                        className="w-full px-3 py-2 rounded-md border border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
                    />
                </div>

                <div className="form-group md:col-span-2">
                    <label className="block text-sm font-medium text-gray-700 mb-2">Rectified</label>
                    <textarea
                        name="rectified"
                        value={formData.rectified || ''}
                        onChange={handleChange}
                        rows="3"
                        className="w-full px-3 py-2 rounded-md border border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
                    />
                </div>

                <div className="form-group">
                    <label className="block text-sm font-medium text-gray-700 mb-2">Latest Date</label>
                    <DatePicker
                        selected={formData.latestDate}
                        onChange={(date) => handleDateChange(date, 'latestDate')}
                        dateFormat="dd/MM/yyyy"
                        className="w-full px-3 py-2 rounded-md border border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
                        placeholderText="Select date"
                    />
                </div>

                <div className="form-group md:col-span-2">
                    <label className="block text-sm font-medium text-gray-700 mb-2">Test Details</label>
                    <textarea
                        name="testDetails"
                        value={formData.testDetails || ''}
                        onChange={handleChange}
                        rows="3"
                        className="w-full px-3 py-2 rounded-md border border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
                    />
                </div>

                <div className="form-group md:col-span-2">
                    <label className="block text-sm font-medium text-gray-700 mb-2">Miscellaneous Notes</label>
                    <textarea
                        name="miscNotes"
                        value={formData.miscNotes || ''}
                        onChange={handleChange}
                        rows="3"
                        className="w-full px-3 py-2 rounded-md border border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500"
                    />
                </div>

                <div className="form-group">
                    <label className="flex items-center space-x-2">
                        <input
                            type="checkbox"
                            name="hasSubPlant"
                            checked={formData.hasSubPlant || false}
                            onChange={handleChange}
                            className="rounded border-gray-300 text-indigo-600 focus:ring-indigo-500"
                        />
                        <span className="text-sm font-medium text-gray-700">Has Sub Plant</span>
                    </label>
                </div>
            </div>

            <div className="flex justify-end space-x-3 pt-6">
                <button
                    type="button"
                    onClick={onCancel}
                    className="px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 bg-white hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
                >
                    Cancel
                </button>
                <button
                    type="submit"
                    className="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
                >
                    {inspection ? 'Update' : 'Create'}
                </button>
            </div>
        </form>
    );
};

export default InspectionForm;