<!-- ClientApp/src/views/AboutView.vue -->
<template>
    <v-container class="mt-10">
        <v-row justify="center">
            <v-col cols="12" md="8">
                <v-card elevation="2">
                    <v-card-title class="headline">Sobre</v-card-title>
                    <v-card-text>
                        <p>
                            Esta é uma aplicação de exemplo em <strong>Vue 3 + Vuetify 3</strong> que consome
                            uma Web API em <strong>.NET 8</strong>.
                        </p>
                        <p>
                            Ao clicar em “Carregar Previsão” na página inicial, a API retorna
                            uma lista de previsões simuladas.
                        </p>
                    </v-card-text>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>

<script setup>
// Nada especial aqui
</script>

<style scoped>
.headline {
    font-weight: 600;
}
a {
    color: #1976D2;
    text-decoration: none;
}
</style>
