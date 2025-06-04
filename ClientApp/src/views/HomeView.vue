<template>
    <v-container class="mt-10">
        <v-row justify="center">
            <v-col cols="12" md="8">
                <v-card elevation="2">
                    <v-card-title class="headline">
                        Previsão tempo com deploy automatico com cache
                    </v-card-title>
                    <v-card-text>
                        <v-btn color="primary" @click="loadForecasts">
                            Carregar Previsão
                        </v-btn>

                        <v-list two-line subheader>
                            <v-subheader>
                                {{ forecasts.length }} dias encontrados
                            </v-subheader>
                            <v-divider></v-divider>

                            <v-list-item
                                v-for="item in forecasts"
                                :key="item.date"
                            >
                                <v-list-item-content>
                                    <v-list-item-title>
                                        {{ formatDate(item.date) }} — {{ item.summary }}
                                    </v-list-item-title>
                                    <v-list-item-subtitle>
                                        Temperatura: {{ item.temperatureC }}°C ({{ toFahrenheit(item.temperatureC) }}°F)
                                    </v-list-item-subtitle>
                                </v-list-item-content>
                            </v-list-item>
                        </v-list>
                    </v-card-text>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>

<script setup>
import { ref } from 'vue'
import { weatherService } from '@/services/weatherService'

// Array reativo que guardará as previsões
const forecasts = ref([])

// Função assíncrona para carregar previsões da API
const loadForecasts = async () => {
    try {
        const { data } = await weatherService.getAll()
        forecasts.value = data
    } catch (err) {
        console.error('Erro ao buscar previsões:', err)
    }
}

// Função auxiliar para formatar DateOnly (por exemplo, “2025-06-10” → “10/06/2025”)
const formatDate = (dateString) => {
    const date = new Date(dateString)
    return date.toLocaleDateString('pt-BR', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric'
    })
}

// Converte Celsius para Fahrenheit
const toFahrenheit = (c) => Math.round(c * 9 / 5 + 32)
</script>

<style scoped>
.headline {
    font-weight: 600;
}
</style>
