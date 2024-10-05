// Objeto que contiene las provincias y sus respectivos cantones
const cantonesPorProvincia = {
    "San José": ["San José", "Escazú", "Desamparados", "Puriscal", "Tarrazú", "Aserrí", "Mora", "Goicoechea",
        "Santa Ana", "Alajuelita", "Vázquez de Coronado", "Acosta", "Tibás", "Moravia", "Montes de Oca", "Curridabat",
        "Pérez Zeledón", "León Cortés"],
    "Alajuela": ["Alajuela", "San Ramón", "Grecia", "San Mateo", "Atenas", "Naranjo", "Palmares", "Poás", "Orotina",
        "San Carlos", "Zarcero", "Sarchí", "Upala", "Los Chiles", "Guatuso", "Río Cuarto"],
    "Cartago": ["Cartago", "Paraíso", "La Unión", "Jiménez", "Turrialba", "Alvarado", "Oreamuno", "El Guarco"],
    "Heredia": ["Heredia", "Barva", "Santo Domingo", "Santa Bárbara", "San Rafael", "San Isidro", "Belén", "Flores",
        "San Pablo", "Sarapiquí"],
    "Guanacaste": ["Liberia", "Nicoya", "Santa Cruz", "Bagaces", "Carrillo", "Cañas", "Abangares", "Tilarán",
        "Nandayure", "La Cruz", "Hojancha"],
    "Puntarenas": ["Puntarenas", "Esparza", "Buenos Aires", "Montes de Oro", "Osa", "Quepos", "Golfito",
        "Coto Brus", "Parrita", "Corredores", "Garabito"],
    "Limón": ["Limón", "Pococí", "Siquirres", "Talamanca", "Matina", "Guácimo"]
};

// Función para cargar los cantones en base a la provincia seleccionada
function cargarCantones() {
    const provinciaSeleccionada = document.getElementById('provincia').value;
    const cantonSeleccionado = document.getElementById('canton');

    // Limpiar el selector de cantones
    cantonSeleccionado.innerHTML = ''; // Limpiar todas las opciones

    // Si se selecciona una provincia válida, agregar los cantones correspondientes
    if (provinciaSeleccionada && cantonesPorProvincia[provinciaSeleccionada]) {
        const cantones = cantonesPorProvincia[provinciaSeleccionada];

        // Añadir el primer cantón automáticamente
        const option = document.createElement('option');
        option.value = cantones[0]; // Valor del primer cantón
        option.text = cantones[0]; // Texto del primer cantón
        cantonSeleccionado.appendChild(option);

        // Añadir los restantes cantones
        cantones.slice(1).forEach(function (canton) { // Comenzar desde el segundo cantón
            const option = document.createElement('option');
            option.value = canton;
            option.text = canton;
            cantonSeleccionado.appendChild(option);
        });
    }
}

// Llama a la función para cargar los cantones al cargar la página
window.onload = cargarCantones;

// Agregar el evento para cambiar de provincia
document.getElementById('provincia').addEventListener('change', cargarCantones);

document.getElementById("nombreCompleto").addEventListener("keypress", function (e) {
    var char = String.fromCharCode(e.which);
    var regex = /^[a-zA-Z\s]*$/; // Solo letras y espacios
    if (!regex.test(char)) {
        e.preventDefault(); // Bloquear cualquier carácter que no sea permitido
    }
});

document.getElementById("direccionExacta").addEventListener("keypress", function (e) {
    var char = String.fromCharCode(e.which);
    var regex = /^[0-9a-zA-Z\s]*$/; // Solo letras y espacios
    if (!regex.test(char)) {
        e.preventDefault(); // Bloquear cualquier carácter que no sea permitido
    }
});