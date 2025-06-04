import axios from 'axios'

const getBaseURL = () => {
	return import.meta.env.DEV
		   ? 'https://localhost:7044'
		   : window.location.origin
}

const api = axios.create({
	baseURL: getBaseURL(),
	timeout: 60000,
})

export default api
