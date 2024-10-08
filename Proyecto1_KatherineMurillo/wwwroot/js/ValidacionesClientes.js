// Validación de campo de la identificación del cliente (solo números enteros)
document.getElementById("Identificacion").addEventListener("input", function (e) {
    this.value = this.value.replace(/\D/g, ''); // Elimina todo lo que no sea dígito
});

document.getElementById("nombreCompleto").addEventListener("keypress", function (e) {
    var char = String.fromCharCode(e.which);
    var regex = /^[a-zA-Z\s]*$/; // Solo letras y espacios
    if (!regex.test(char)) {
        e.preventDefault(); // Bloquear cualquier carácter que no sea permitido
    }
});

//Objeto que contiene las provincias y sus respectivos cantones
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

// Cantones y distritos por provincia y cantón
const distritosPorCanton = {
    "San José": {
        "San José": [
            "Carmen", "Merced", "Hospital", "Catedral", "Zapote", "San Francisco de Dos Ríos",
            "La Uruca", "Mata Redonda", "Pavas", "Hatillo", "San Sebastián", "Desamparados"
        ],
        "Escazú": [
            "San Rafael", "San Antonio", "San Miguel", "San José", "Playa Grande"
        ],
        "Desamparados": [
            "San Miguel", "San Rafael Arriba", "San Rafael Abajo", "Gravilias", "Damas", "San Cristóbal", "Rosario",
            "Frailes", "Patarrá", "San Antonio", "Aserrí", "Tarbaca", "Vuelta de Jorco", "San Gabriel", "San Marcos",
            "San Pablo", "San Pedro", "San Ignacio"
        ],
        "Puriscal": [
            "Santiago", "Barbacoas", "Grifo Alto", "Mercedes Sur", "San Rafael", "San Antonio", "Candelaria"
        ],
        "Tarrazú": [
            "San Marcos", "San Lorenzo", "San Carlos"
        ],
        "Aserrí": [
            "Tarbaca", "Aserrí", "San Gabriel"
        ],
        "Mora": [
            "Ciudad Colón", "Guayabo", "Tabarcia", "Piedras Negras"
        ],
        "Goicoechea": [
            "San Francisco", "San Isidro", "Cascajal", "Los Angeles", "El Carmen", "La Trinidad"
        ],
        "Santa Ana": [
            "Santa Ana", "Salitral", "Pozos", "Uruca"
        ],
        "Alajuelita": [
            "Alajuelita", "San Felipe", "San Josecito"
        ],
        "Vázquez de Coronado": [
            "San Isidro", "San Rafael", "Cascajal", "Dulce Nombre"
        ],
        "Acosta": [
            "San Ignacio", "Guadalupe", "Palmichal"
        ],
        "Tibás": [
            "San Juan", "Santa Teresita", "Colima", "Tibás"
        ],
        "Moravia": [
            "San Vicente", "La Trinidad"
        ],
        "Montes de Oca": [
            "San Pedro", "Sabanilla", "Mercedes"
        ],
        "Curridabat": [
            "Curridabat", "Granadilla", "Sánchez"
        ],
        "Pérez Zeledón": [
            "San Isidro", "Daniel Flores", "Rivas", "Platanares", "Cañaza", "Pérez Zeledón"
        ],
        "León Cortés": [
            "San Pablo", "San Andrés", "San Isidro", "La Lucha"
        ]
    },
    "Alajuela": {
        "Alajuela": [
            "Carrizal", "San Antonio", "Guácima", "San Isidro", "Sabanilla", "San Rafael", "Río Segundo", "Desamparados",
            "Turrúcares", "Tambor", "Garita", "San Ramón", "Santiago", "San Juan"
        ],
        "San Ramón": [
            "San Ramón", "San Juan", "Piedades", "San Isidro", "San Rafael", "San Antonio", "Palmares", "Naranjo"
        ],
        "Grecia": [
            "Grecia", "San Francisco", "Tacares", "San Isidro"
        ],
        "San Mateo": [
            "San Mateo", "Desmonte", "Pueblo Nuevo"
        ],
        "Atenas": [
            "Atenas", "Concepción", "San José", "San Antonio", "Santa Eulalia"
        ],
        "Naranjo": [
            "Naranjo", "San Miguel", "La Florida", "San Antonio", "San José"
        ],
        "Palmares": [
            "Palmares", "Zaragoza", "San Isidro", "San José"
        ],
        "Poás": [
            "San Pedro", "San Juan", "Varablanca"
        ],
        "Orotina": [
            "Orotina", "Hacienda Vieja", "La Ceiba"
        ],
        "San Carlos": [
            "Quesada", "Florencia", "Buenavista", "Aguas Zarcas", "La Fortuna"
        ],
        "Zarcero": [
            "Zarcero", "Las Aguas", "Cebadilla", "San Ramón", "San José"
        ],
        "Sarchí": [
            "Sarchí", "San Juan", "La Rosa"
        ],
        "Upala": [
            "Upala", "Aguas Claras", "Bijagua"
        ],
        "Los Chiles": [
            "Los Chiles", "El Amparo", "San Jorge"
        ],
        "Guatuso": [
            "Guatuso", "San Rafael", "San José"
        ],
        "Río Cuarto": [
            "Río Cuarto", "San Carlos"
        ]
    },
    "Cartago": {
        "Cartago": [
            "Oriental", "Occidental", "Carmen", "San Nicolás", "Agua Caliente", "Guadalupe", "Corralillo", "Tierra Blanca",
            "Dulce Nombre", "Llano Grande", "Quebradilla", "Paraíso", "Santiago", "Orosi", "Cachí", "La Unión", "Tres Ríos",
            "San Diego", "San Juan", "San Rafael"
        ],
        "Paraíso": [
            "Paraíso", "Santiago", "Orosi", "Cachí"
        ],
        "La Unión": [
            "La Unión", "San Diego", "San Juan", "San Rafael"
        ],
        "Jiménez": [
            "Jiménez", "San Antonio", "Santa Rosa", "Concepción"
        ],
        "Turrialba": [
            "Turrialba", "La Suiza", "Peralta", "Santa Cruz", "Pacayas", "Cervantes", "Capellades", "Juan Viñas"
        ],
        "Alvarado": [
            "Alvarado", "San Isidro", "San José"
        ],
        "Oreamuno": [
            "Oreamuno", "San Rafael", "San Isidro"
        ],
        "El Guarco": [
            "El Guarco", "San Francisco", "San Juan"
        ]
    },
    "Heredia": {
        "Heredia": [
            "Heredia", "Mercedes", "San Francisco", "Ulloa", "Varablanca", "Santo Domingo", "San Vicente", "San Miguel",
            "San Pablo", "Santa Rosa", "Tures", "Pará", "San Rafael", "San Isidro"
        ],
        "Barva": [
            "Barva", "San Pablo", "San Juan", "Santa Lucía"
        ],
        "Santo Domingo": [
            "Santo Domingo", "San Vicente", "San Miguel", "San Pablo"
        ],
        "Santa Bárbara": [
            "Santa Bárbara", "San Pedro", "San Pablo"
        ],
        "San Rafael": [
            "San Rafael", "San Isidro", "San Juan"
        ],
        "San Isidro": [
            "San Isidro", "San José"
        ],
        "Belén": [
            "Belén", "San Antonio", "San Rafael"
        ],
        "Flores": [
            "Flores", "San Joaquín", "San Francisco"
        ],
        "San Pablo": [
            "San Pablo", "San Juan"
        ],
        "Sarapiquí": [
            "La Virgen", "Puerto Viejo", "La Muerte", "San Juan", "San José", "San Pablo"
        ]
    },
    "Guanacaste": {
        "Liberia": [
            "Liberia", "Nicoya", "Santa Cruz", "Bagaces", "Carrillo", "Cañas", "Abangares", "Tilarán", "Nandayure", "La Cruz",
            "Hojancha"
        ],
        "Nicoya": [
            "Nicoya", "San Antonio", "San José", "San Miguel", "Sámara"
        ],
        "Santa Cruz": [
            "Santa Cruz", "Diriá", "Diriá", "Tamarindo", "Hacienda", "San Juan"
        ],
        "Bagaces": [
            "Bagaces", "La Fortuna", "Cañas Dulces"
        ],
        "Carrillo": [
            "Carrillo", "San Jorge", "La Cruz", "Cañas"
        ],
        "Cañas": [
            "Cañas", "Palmira", "San Miguel"
        ],
        "Abangares": [
            "Abangares", "Las Juntas", "San Juan"
        ],
        "Tilarán": [
            "Tilarán", "El Castillo", "San José"
        ],
        "Nandayure": [
            "Nandayure", "Mañanitas", "La Cruz"
        ],
        "La Cruz": [
            "La Cruz", "Santa Rosa", "San Juan"
        ],
        "Hojancha": [
            "Hojancha", "La Candelaria", "San José"
        ]
    },
    "Puntarenas": {
        "Puntarenas": [
            "Puntarenas", "Barranca", "La Boca", "El Roble", "Pochote", "Chacarita", "Paquera", "Puntarenas", "Lepanto",
            "Cabo Blanco", "Bolsón", "El Llano", "Isla del Caño"
        ],
        "Esparza": [
            "Esparza", "San Juan", "San Rafael"
        ],
        "Montes de Oro": [
            "Montes de Oro", "Miramar", "San Isidro"
        ],
        "Osa": [
            "Puerto Cortés", "Palmar", "Sierpe", "Piedras Blancas", "Uvita", "Bahía Ballena"
        ],
        "Golfito": [
            "Golfito", "Guaycará", "Lauda", "Cañaza", "Coto", "Pavón", "San Francisco", "Santa Rosa"
        ],
        "Coto Brus": [
            "Coto Brus", "San Vito", "Sábana", "San Pedro", "Cerro de la Muerte", "San José"
        ],
        "Corredores": [
            "Corredores", "Laurel", "San Vito"
        ],
        "Palmar": [
            "Palmar", "Río Claro", "Punta Uva"
        ]
    },
    "Limón": {
        "Limón": [
            "Limón", "La Garita", "Cahuita", "Siquirres", "Talamanca",  "Pococí", "Guápiles", "Jiménez", "Matina", "Batán"
        ],
        "Guácimo": [
            "Guácimo", "San Isidro", "La Guinea"
        ],
        "Siquirres": [
            "Siquirres", "Tierra Blanca", "Mercedes"
        ],
        "Pococí": [
            "Pococí", "Guápiles", "La Rita"
        ],
        "Talamanca": [
            "Talamanca", "Bribri", "Cahuita"
        ],
        "Matina": [
            "Matina", "La Cangreja"
        ]
    }
};

// Función para cargar cantones
function cargarCantones() {
    const provinciaSeleccionada = document.getElementById('provincia').value;
    const cantonSeleccionado = document.getElementById('canton');
    cantonSeleccionado.innerHTML = ''; // Limpiar el selector de cantones

    // Cargar los cantones de la provincia seleccionada
    if (distritosPorCanton[provinciaSeleccionada]) {
        const cantones = Object.keys(distritosPorCanton[provinciaSeleccionada]);

        cantones.forEach(function (canton) {
            const option = document.createElement('option');
            option.value = canton;
            option.text = canton;
            cantonSeleccionado.appendChild(option);
        });

        // Cargar el distrito del primer cantón por defecto
        cargarDistritos();
    }
}

// Función para cargar distritos
function cargarDistritos() {
    const provinciaSeleccionada = document.getElementById('provincia').value;
    const cantonSeleccionado = document.getElementById('canton').value;
    const distritoSeleccionado = document.getElementById('distrito');

    distritoSeleccionado.innerHTML = ''; // Limpiar el selector de distritos

    if (provinciaSeleccionada && cantonSeleccionado && distritosPorCanton[provinciaSeleccionada][cantonSeleccionado]) {
        const distritos = distritosPorCanton[provinciaSeleccionada][cantonSeleccionado];

        distritos.forEach(function (distrito) {
            const option = document.createElement('option');
            option.value = distrito;
            option.text = distrito;
            distritoSeleccionado.appendChild(option);
        });

        // Si la provincia es San José y el cantón es Carmen, establece "Carmen" como predeterminado
        if (provinciaSeleccionada === "San José" && cantonSeleccionado === "Carmen") {
            distritoSeleccionado.value = "Carmen"; // Establecer "Carmen" como el distrito seleccionado
        } else if (distritoSeleccionado.options.length > 0) {
            // Establecer el primer distrito como predeterminado si no es "Carmen"
            distritoSeleccionado.value = distritos[0]; // Asignar el primer distrito como seleccionado
        }
    }
}

// Eventos para cuando cambie la provincia o el cantón
document.getElementById('provincia').addEventListener('change', cargarCantones);
document.getElementById('canton').addEventListener('change', cargarDistritos);

// Cargar los cantones y distritos por defecto al cargar la página
window.onload = function () {
    cargarCantones(); // Carga los cantones de la provincia por defecto (San José)
};

/*Función para almacenar el ID del cliente entre vistas
document.addEventListener("DOMContentLoaded", function () {
    const identificacionElemento = document.getElementById("identificacionCliente");
    console.log(identificacionElemento); // Verifica que el elemento no sea nulo

    // Escuchar el evento submit del formulario
    document.querySelector("form").addEventListener("submit", function () {
        // Obtener el valor de la identificación del cliente
        const identificacionCliente = identificacionElemento.value;

        // Guardar el valor en localStorage
        if (identificacionCliente) {
            localStorage.setItem("clienteId", identificacionCliente);
        }
    });
});*/
