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
    document.getElementById('resultado').innerText = `Cantidad de días sin chapia: ${diasSinChapia}`;
}

 /*<h1>Calcular Días Sin Chapia</h1>
    <label for="fechaEjecucion">Fecha de Ejecución:</label>
    <input type="date" id="fechaEjecucion">
    <button onclick="mostrarDiasSinChapia()">Calcular</button>
    <div id="resultado"></div> */

// Ejemplo de uso
/*let fechaEjecucion = '2024-01-01'; // Cambia esta fecha según sea necesario
let diasSinChapia = calcularDiasSinChapia(fechaEjecucion);
console.log(`Cantidad de días sin chapia: ${diasSinChapia}`);*/

