// Validación de campo de ID de mantenimiento (solo números enteros)
document.getElementById("IdMantenimiento").addEventListener("input", function (e) {
    this.value = this.value.replace(/\D/g, ''); // Elimina todo lo que no sea dígito
});

// Al cargar la página, se establece el valor del campo IdCliente
document.addEventListener("DOMContentLoaded", function () {
    // Recuperar el valor del cliente guardado en localStorage
    const clienteId = localStorage.getItem("clienteId");

    // Establecer el valor en el campo IdCliente
    if (clienteId) {
        document.getElementById("idClienteInput").value = clienteId;
    }
});


// Validación de campo de metros de propiedad (solo números decimales correctos)
document.getElementById("MetrosPropiedad").addEventListener("input", function (e) {
    // Elimina cualquier caracter que no sea número o un punto decimal
    this.value = this.value.replace(/[^0-9.]/g, '');

    // Evita que haya más de un punto decimal
    const parts = this.value.split('.');
    if (parts.length > 2) {
        this.value = parts[0] + '.' + parts[1]; // Solo permite un punto decimal
    }

    // No permite que el primer carácter sea un punto
    if (this.value[0] === '.') {
        this.value = '';
    }
});

// Validación de campo de metros de cerca viva (solo números decimales correctos)
document.getElementById("MetrosCercaViva").addEventListener("input", function (e) {
    // Elimina cualquier caracter que no sea número o un punto decimal
    this.value = this.value.replace(/[^0-9.]/g, '');

    // Evita que haya más de un punto decimal
    const parts = this.value.split('.');
    if (parts.length > 2) {
        this.value = parts[0] + '.' + parts[1]; // Solo permite un punto decimal
    }

    // No permite que el primer carácter sea un punto
    if (this.value[0] === '.') {
        this.value = '';
    }
});

function calcularDiasSinChapia(fechaEjecucion) {
    // Convertir la fecha de ejecución a un objeto Date
    let fechaInicio = new Date(fechaEjecucion);

    // Obtener la fecha actual
    let fechaActual = new Date();

    // Calcular la diferencia en milisegundos
    let diferenciaEnMilisegundos = fechaActual - fechaInicio;

    // Convertir la diferencia de milisegundos a días
    let diferenciaEnDias = Math.floor(diferenciaEnMilisegundos / (1000 * 60 * 60 * 24));

    return diferenciaEnDias;
}

function mostrarDiasSinChapia() {
    // Obtener el valor del input
    let fechaEjecucion = document.getElementById('fechaEjecucion').value;

    // Calcular los días sin chapia
    let diasSinChapia = calcularDiasSinChapia(fechaEjecucion);

    // Mostrar el resultado
   // document.getElementById('resultado').innerText = `Cantidad de días sin chapia: ${diasSinChapia}`;
    document.getElementById('resultado').value = `Cantidad de días sin chapia: ${diasSinChapia}`;
}

// Al cargar la página, se establece el valor del campo PREFERENCIA
document.addEventListener("DOMContentLoaded", function () {
    // Recuperar el valor del cliente guardado en localStorage
    const mainten = localStorage.getItem("mantenimiento");

    // Establecer el valor en el campo IdCliente
    if (mainten) {
        document.getElementById("manten").value = mainten;
    }
});

function calcularSiguienteChapia(fechaEjecutado, preferencia) {
    // Convertir la fecha de ejecutado a un objeto Date
    let fecha = new Date(fechaEjecutado);

    //let preferencia = document.getElementById('manten').value;

    // Calcular el incremento en días según la preferencia del cliente
    let incrementoDias;
    if (preferencia.toLowerCase() === '15') {
        incrementoDias = 15; // 14 días para quincenal
    } else if (preferencia.toLowerCase() === '30') {
        incrementoDias = 30; // 30 días para mensual
    } else {
        throw new Error('Preferencia no válida. Use "quincenal" o "mensual".');
    }

    // Sumar el incremento de días a la fecha de ejecutado
    fecha.setDate(fecha.getDate() + incrementoDias);

    // Formatear la fecha resultante en formato YYYY-MM-DD
    //let siguienteChapia = fecha.toISOString().split('T')[0];
    let siguienteChapia = fecha.toLocaleDateString();
    return siguienteChapia;
}

function mostrarProximaChapia() {
    // Obtener el valor del input
    let fechaEjecucion = document.getElementById('fechaEjecucion').value;

    let preferencia = document.getElementById('manten').value;

    // Calcular los días sin chapia
    let proximaChapia = calcularSiguienteChapia(fechaEjecucion,preferencia);

    // Mostrar el resultado
    // document.getElementById('resultado').innerText = `Cantidad de días sin chapia: ${diasSinChapia}`;
    document.getElementById('result').value = `Fecha próxima chapia: ${proximaChapia}`;
}

// Ejemplo de uso:
/*let fechaEjecutado = '2024-10-08';
let preferencia = 'quincenal';
console.log(calcularSiguienteChapia(fechaEjecutado, preferencia)); // Salida: 2024-10-22
*/

 /*<h1>Calcular Días Sin Chapia</h1>
    <label for="fechaEjecucion">Fecha de Ejecución:</label>
    <input type="date" id="fechaEjecucion">
    <button onclick="mostrarDiasSinChapia()">Calcular</button>
    <div id="resultado"></div> */

// Ejemplo de uso
/*let fechaEjecucion = '2024-01-01'; // Cambia esta fecha según sea necesario
let diasSinChapia = calcularDiasSinChapia(fechaEjecucion);
console.log(`Cantidad de días sin chapia: ${diasSinChapia}`);*/

/*function capturarValor() {
    // Obtener el valor del campo de entrada
    var inputElement = document.getElementById('inputCampo');
    var valor = inputElement.value;

    // Mostrar el valor en la otra vista
    var valorCapturadoElement = document.getElementById('valorCapturado');
    valorCapturadoElement.textContent = valor;

    // Ocultar la primera vista y mostrar la segunda vista
    document.getElementById('vista1').style.display = 'none';
    document.getElementById('vista2').style.display = 'block';
}*/

