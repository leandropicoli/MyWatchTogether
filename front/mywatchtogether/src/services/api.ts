import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:44343/api/playlist'
});

export default api;