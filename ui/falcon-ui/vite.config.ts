import { defineConfig, loadEnv } from "vite";
import react from "@vitejs/plugin-react";
import path from "path";

export default defineConfig(({ command, mode }) => {
  const env = loadEnv(mode, process.cwd(), "");

  return {
    // server: {
    //   port: 5173,
    //   host: "app.falconone.com",

    // },
    resolve: {
      alias: {
        "@": path.resolve(__dirname, "./src"),
        "@feature-components": path.resolve(
          __dirname,
          "./src/components/features"
        ),
        "@ui-components": path.resolve(
          __dirname,
          "./src/components/ui-components"
        ),
        "@models": path.resolve(__dirname, "./src/models"),
        "@slices": path.resolve(__dirname, "./src/store/slices"),
        "@services": path.resolve(__dirname, "./src/services"),
        "@endpoints": path.resolve(__dirname, "./src/endpoints"),
        "@validation-schemes": path.resolve(
          __dirname,
          "./src/validation-schemes"
        ),
        "@enumerations": path.resolve(__dirname, "./src/enumerations"),
        "@utilities": path.resolve(__dirname, "./src/utilities"),
        "@pages": path.resolve(__dirname, "./src/pages"),
        "@routes": path.resolve(__dirname, "./src/routes"),
        "@guards": path.resolve(__dirname, "./src/guards"),
        "@layouts": path.resolve(__dirname, "/src/layouts"),
        "@locales": path.resolve(__dirname, "/src/locales"),
      },
    },
    define: {
      __APP_ENV__: env.APP_ENV,
    },
    plugins: [react()],
  };
});
