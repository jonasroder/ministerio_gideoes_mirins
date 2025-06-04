import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vuetify from 'vite-plugin-vuetify'
import path from 'path'

export default defineConfig(({ mode }) => ({
  plugins: [
    vue(),
    vuetify({ autoImport: true }),
  ],
  resolve: {
    alias: {
      '@': path.resolve(__dirname, 'src'),
    },
  },
  server: {
    proxy: {
      '^/api': {
        target: 'https://localhost:7044',
        changeOrigin: true,
        secure: false,
        // remove o “/api” antes de mandar para o controller
        rewrite: (path) => path.replace(/^\/api/, '')
      },
    },
  },

  build: {
    outDir: 'dist',
  },
}))
