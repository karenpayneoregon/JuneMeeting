// Language dictionary
const translations = {
    en: {
        greeting: "Welcome",
        message: "This is a simple language toggle example."
    },
    es: {
        greeting: "Bienvenido",
        message: "Este es un ejemplo simple de alternancia de idioma."
    }
};

// Get current language or default to English
const currentLang = localStorage.getItem('lang') || 'en';

// Apply translations to the page
function applyLanguage(lang) {
    const elements = translations[lang];
    for (let id in elements) {
        const el = document.getElementById(id);
        if (el) el.textContent = elements[id];
    }
}

// Toggle between English and Spanish and refresh
function toggleLanguage() {
    const newLang = currentLang === 'en' ? 'es' : 'en';
    localStorage.setItem('lang', newLang);
    location.reload(); // refresh the page
}

// Set initial language on page load
window.onload = function () {
    applyLanguage(currentLang);
};