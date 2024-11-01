﻿//Validación de campo de ID de mantenimiento 
document.getElementById("IdMantenimiento").addEventListener("input", function (e) {
    this.value = this.value.replace(/\D/g, ''); //Elimina todo lo que no sea dígito
});
//Al cargar la página se establece el valor del campo IdCliente
document.addEventListener("DOMContentLoaded", function () {
    //Recupera el valor del cliente guardado en localStorage
    const clienteId = localStorage.getItem("clienteId");
    //Establece el valor en el campo IdCliente
    if (clienteId) {
        document.getElementById("idClienteInput").value = clienteId;
    }
});
//Validación de campo de metros de propiedad 
document.getElementById("MetrosPropiedad").addEventListener("input", function (e) {
    //Elimina cualquier caracter que no sea número o un punto decimal
    this.value = this.value.replace(/[^0-9.]/g, '');
    //Evita que haya más de un punto decimal
    const parts = this.value.split('.');
    if (parts.length > 2) {
        this.value = parts[0] + '.' + parts[1]; //Solo permite un punto decimal
    }
    //No permite que el primer carácter sea un punto
    if (this.value[0] === '.') {
        this.value = '';
    }
});
//Validación de campo de metros de cerca viva 
document.getElementById("MetrosCercaViva").addEventListener("input", function (e) {
    // Elimina cualquier caracter que no sea número o un punto decimal
    this.value = this.value.replace(/[^0-9.]/g, '');
    //Evita que haya más de un punto decimal
    const parts = this.value.split('.');
    if (parts.length > 2) {
        this.value = parts[0] + '.' + parts[1]; //Solo permite un punto decimal
    }
    //No permite que el primer carácter sea un punto
    if (this.value[0] === '.') {
        this.value = '';
    }
});
//Función para calcular los días sin chapia
function calcularDiasSinChapia(fechaEjecucion) {
    //Convierte la fecha de ejecución a un objeto Date
    let fechaInicio = new Date(fechaEjecucion);
    //Obtiene la fecha actual
    let fechaActual = new Date();
    //Calcula la diferencia en milisegundos
    let diferenciaEnMilisegundos = fechaActual - fechaInicio;
    //Convierte la diferencia de milisegundos a días
    let diferenciaEnDias = Math.floor(diferenciaEnMilisegundos / (1000 * 60 * 60 * 24));
    return diferenciaEnDias;
}
//Función para mostrar los días sin chapia
function mostrarDiasSinChapia() {
    //Obtiene el valor del input
    let fechaEjecucion = document.getElementById('fechaEjecucion').value;
    //Calcula los días sin chapia
    let diasSinChapia = calcularDiasSinChapia(fechaEjecucion);
    //Muestra el resultado
    document.getElementById('resultado').value = `Cantidad de días sin chapia: ${diasSinChapia}`;
}
//Al cargar la página se establece el valor del campo preferencia de mantenimiento
document.addEventListener("DOMContentLoaded", function () {
    //Recupera el valor del cliente guardado en localStorage
    const mainten = localStorage.getItem("mantenimiento");
    //Establece el valor en el campo IdCliente
    if (mainten) {
        document.getElementById("manten").value = mainten;
    }
});
//Función para calcular la siguiente chapia
function calcularSiguienteChapia(fechaEjecutado, preferencia) {
    //Convierte la fecha de ejecutado a un objeto Date
    let fecha = new Date(fechaEjecutado);
    //Calcula el incremento en días según la preferencia del cliente
    let incrementoDias;
    if (preferencia.toLowerCase() === '15') {
        incrementoDias = 15; // 14 días para quincenal
    } else if (preferencia.toLowerCase() === '30') {
        incrementoDias = 30; // 30 días para mensual
    } else {
        throw new Error('Preferencia no válida. Use "quincenal" o "mensual".');
    }
    //Suma el incremento de días a la fecha de ejecutado
    fecha.setDate(fecha.getDate() + incrementoDias);
    //Formatea la fecha resultante  
    let siguienteChapia = fecha.toLocaleDateString();
    return siguienteChapia;
}
//Función para mostrar la siguiente chapia
function mostrarProximaChapia() {
    //Obtiene el valor del input
    let fechaEjecucion = document.getElementById('fechaEjecucion').value;
    let preferencia = document.getElementById('manten').value;
    //Calcula los días sin chapia
    let proximaChapia = calcularSiguienteChapia(fechaEjecucion,preferencia);
    //Muestra el resultado
    document.getElementById('result').value = `Fecha próxima chapia: ${proximaChapia}`;
}
function calcularCostos() {
    // Obtiene los valores del input
    const metrosPropiedad = parseFloat(document.getElementById("MetrosPropiedad").value) || 0;
    const metrosCercaViva = parseFloat(document.getElementById("MetrosCercaViva").value) || 0;
    const costoChapia = parseFloat(document.getElementById("CostoChapia").value) || 0;
    const costoProducto = parseFloat(document.getElementById("CostoProducto").value) || 0;

    // Calcula Precio Costo Chapia: (A*C) + (B*C) + IVA(13%)
    const precioCostoChapia = ((metrosPropiedad * costoChapia) + (metrosCercaViva * costoChapia)) * 1.13;
    document.getElementById("PrecioCostoChapia").value = precioCostoChapia.toFixed(2);

    // Verifica si aplica el producto
    const aplicaProducto = document.getElementById("AplicacionProducto").value === "Sí";
    let precioAplicacionProducto = 0;
    let precioTotal;

    if (aplicaProducto) {
        // Calcula Precio Aplicación Producto: Precio Costo Chapia * D + IVA(13%)
        precioAplicacionProducto = precioCostoChapia * costoProducto * 1.13;
        document.getElementById("PrecioAplicacionProducto").value = precioAplicacionProducto.toFixed(2);

        // Calcula Precio total con Aplicación Producto
        precioTotal = (((metrosPropiedad * (costoChapia + costoProducto)) + (metrosCercaViva * (costoChapia + costoProducto))) * 1.13).toFixed(2);
        document.getElementById("PrecioTotalConAplicacion").value = precioTotal;
    } else {
        // Si no aplica producto, coloca Precio total sin Aplicación Producto
        precioTotal = precioCostoChapia.toFixed(2);
        document.getElementById("PrecioAplicacionProducto").value = "0.00";
        document.getElementById("PrecioTotalConAplicacion").value = precioTotal;
    }
}





