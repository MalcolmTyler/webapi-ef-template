import axios from 'axios';

const baseUrl = process.env.REACT_APP_API_URL || 'http://localhost:5207/api';

const getAll = async () => {
    const response = await axios.get(`${baseUrl}/inspection`);
    return response.data;
};

const getById = async (id) => {
    const response = await axios.get(`${baseUrl}/inspection/${id}`);
    return response.data;
};

const getByPlantHolding = async (holdingId) => {
    const response = await axios.get(`${baseUrl}/inspection/plantholding/${holdingId}`);
    return response.data;
};

const create = async (inspection) => {
    const response = await axios.post(`${baseUrl}/inspection`, inspection);
    return response.data;
};

const update = async (id, inspection) => {
    const response = await axios.put(`${baseUrl}/inspection/${id}`, inspection);
    return response.data;
};

const remove = async (id) => {
    await axios.delete(`${baseUrl}/inspection/${id}`);
};

const inspectionService = {
    getAll,
    getById,
    getByPlantHolding,
    create,
    update,
    remove
};

export default inspectionService;