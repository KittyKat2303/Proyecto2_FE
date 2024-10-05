document.getElementById("descripcion").addEventListener("keypress", function (e) {
    var char = String.fromCharCode(e.which);
    var regex = /^[a-zA-Z\s]*$/; // Solo letras y espacios
    if (!regex.test(char)) {
        e.preventDefault(); // Bloquear cualquier carácter que no sea permitido
    }
});
