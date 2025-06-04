<template>
    <v-app>
        <v-main>
            <router-view /> <!-- rendeiriza a rota atual; se não usar rotas, chame HomeView diretamente -->
        </v-main>
    </v-app>
</template>

<script setup>
// Nenhum código adicional aqui; o <router-view> carregará a view apropriada
</script>

<style>
/* Você pode adicionar estilos globais aqui */
body {
    margin: 0;
    font-family: Roboto, sans-serif;
}
</style>
