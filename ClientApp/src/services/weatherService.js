import api from './api'

export const weatherService = {
	// api.get('/WeatherForecast') = GET http://localhost:3000/api/WeatherForecast
	getAll: () => api.get('/WeatherForecast'),
}
