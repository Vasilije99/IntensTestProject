import axios from "axios";

export default axios.create({
    baseURL: 'http://localhost:15967/api'
})