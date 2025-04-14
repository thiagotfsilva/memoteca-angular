import { mascaraTelefone } from "./mask.js";
import { validaDataNascimento, validaEmail, validaNomeCompleto, validaTelefone, } from "./validations.js";
const form = document.querySelector("#form");
form.addEventListener("submit", (event) => {
    event.preventDefault();
    const inputNomeCompleto = form.querySelector("#nomeCompleto");
    const inputEmail = form.querySelector("#email");
    const inputTelefone = form.querySelector("#telefone");
    const inputDataNascimento = form.querySelector("#dataNascimento");
    // Valida todos os campos
    validaNomeCompleto(inputNomeCompleto);
    validaEmail(inputEmail);
    validaTelefone(inputTelefone);
    validaDataNascimento(inputDataNascimento);
    // Verifica se algum campo está inválido
    const camposInvalidos = form.querySelectorAll(".is-invalid");
    if (camposInvalidos.length > 0) {
        return; // Impede o envio se houver campos inválidos
    }
    const obj = {
        "Nome": inputNomeCompleto.value,
        "Email": inputEmail.value,
        "Telefone": inputTelefone.value,
        "Data Nascimento": inputDataNascimento.value,
    };
    form.reset();
    console.log(obj);
});
// Adiciona o evento de input para aplicar a máscara
const inputTelefone = form.querySelector("#telefone");
const inputNome = form.querySelector("#nomeCompleto");
const inputEmail = form.querySelector("#email");
const inputDataNascimento = form.querySelector("#dataNascimento");
inputTelefone.addEventListener("input", (event) => {
    const target = event.target;
    target.value = mascaraTelefone(target.value);
});
inputTelefone.addEventListener("blur", () => {
    validaTelefone(inputTelefone);
});
inputNome.addEventListener("blur", () => {
    validaNomeCompleto(inputNome);
});
inputEmail.addEventListener("blur", () => {
    validaEmail(inputEmail);
});
inputDataNascimento.addEventListener("blur", () => {
    validaDataNascimento(inputDataNascimento);
});
