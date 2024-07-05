import type { Config } from "tailwindcss";

const config: Config = {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      screens: {
        sm: "576px",
        md: "768px",
        lg: "992px",
        xl: "1200px",
      },
      animation: {
        fall: "fall 2s ease",
        down: "down 2s ease",
        "fade-in-up": "fade-in-up 0.6s ease-in-out",
      },
      keyframes: {
        fall: {
          "0%": { transform: " translate3d(0,40px,0)" },
          "50%": { transform: "translate3d(0,0,0)" },
        },
        down: {
          "0%": { transform: " translate3d(0,0,0)" },
          "50%": { transform: "translate3d(0,40px,0)" },
        },
        "fade-in-up": {
          "0%": {
            opacity: "0",
            transform: "translateY(20px)",
          },
          "100%": {
            opacity: "1",
            transform: "translateY(0)",
          },
        },
      },
    },
  },
  plugins: [],
};
export default config;
