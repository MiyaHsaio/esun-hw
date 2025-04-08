/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./index.html", "./src/**/*.{vue,js,ts,jsx,tsx}"],
  theme: {
    extend: {
      fontFamily: {
        body: ["Roboto", "Noto Sans TC", "sans-serif"],
      },
      fontSize: {
        xss: "0.625rem",
      },
      colors: {
        primary100: "#E7F0E6",
        primary400: "#4caf50",
        primary500: "#288a31",
        primary600: "#2A874F",
        primary: "#288a31",
        silver400: "#C1C1C1",
        silver500: "#b0b1b1",
        silver: "#b0b1b1",
        hint: "#ff6767",
        red: "#FF0000",
        error: "#ef5241",
      },
      opacity: {
        65: ".65",
      },
      boxShadow: {
        table: "0 5px 5px rgba(0,0,0,0.15)",
      },
      screens: {
        xs: "480px",
        desktop: "1920px",
      },
    },
  },
};
