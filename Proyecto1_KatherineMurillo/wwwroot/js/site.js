// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var input = document.querySelectorAll('input');         //FUNCION AUTO LENGTH
for (i = 0; i < input.length; i++) {
    input[i].setAttribute('size', input[i].getAttribute('placeholder').length);
}


function validarFormulario() {

    const feedbackElement = document.getElementById('estadoFeedback');
    valor = document.getElementById("estado").value;
    if (valor == null || valor.length == 0 || /^\s+$/.test(valor)) {
        return false;
        feedbackElement.textContent = "debe digitar algún estado";
    }

}