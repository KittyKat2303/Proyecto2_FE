// Validación de campo de cédula (solo números enteros)
document.getElementById("Cedula").addEventListener("input", function (e) {
    this.value = this.value.replace(/\D/g, ''); // Elimina todo lo que no sea dígito
});

// Validación de campo de salario por hora (solo números decimales correctos)
document.getElementById("SalarioHora").addEventListener("input", function (e) {
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