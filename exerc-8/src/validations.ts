const REGEXTELEFONE = /^\([1-9]{2}\) (?:[2-8]|9[0-9])[0-9]{3}\-[0-9]{4}$/;
const REGEXEMAIL = /^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)?$/i;

function validaTelefone(input: HTMLInputElement) {
  if (input.value.length === 0 || !input.value.match(REGEXTELEFONE)) {
    input.classList.add("is-invalid");
    input.setCustomValidity("Por favor, insira um telefone válido no formato (XX) XXXXX-XXXX");
  } else {
    input.classList.remove("is-invalid");
    input.setCustomValidity("");
  }
}

function validaNomeCompleto(input: HTMLInputElement) {
  if (input.value.length < 3 || input.value.length > 150) {
    input.classList.add("is-invalid");
    input.setCustomValidity("O nome deve ter entre 3 e 150 caracteres");
  } else {
    input.classList.remove("is-invalid");
    input.setCustomValidity("");
  }
}

function validaEmail(input: HTMLInputElement) {
  if (input.value.length === 0 || !input.value.match(REGEXEMAIL)) {
    input.classList.add("is-invalid");
    input.setCustomValidity("Por favor, insira um e-mail válido");
  } else {
    input.classList.remove("is-invalid");
    input.setCustomValidity("");
  }
}

function validaDataNascimento(input: HTMLInputElement) {
  const hoje = new Date();
  const dataNascimento = new Date(input.value);
  let idade = hoje.getFullYear() - dataNascimento.getFullYear();

  // Verifica se a data é maior que hoje
  if (dataNascimento > hoje) {
    input.classList.add("is-invalid");
    input.setCustomValidity("A data de nascimento não pode ser maior que a data atual");
    return;
  }

  // Verifica se tem menos de 16 anos
  // Ajusta a idade se ainda não fez aniversário este ano
  if (
    hoje.getMonth() < dataNascimento.getMonth() ||
    (hoje.getMonth() === dataNascimento.getMonth() &&
      hoje.getDate() < dataNascimento.getDate())
  ) {
    idade--;
  }

  if (idade < 16) {
    input.classList.add("is-invalid");
    input.setCustomValidity("Você deve ter pelo menos 16 anos de idade");
  } else {
    input.classList.remove("is-invalid");
    input.setCustomValidity("");
  }
}

export {
  validaDataNascimento,
  validaEmail,
  validaNomeCompleto,
  validaTelefone,
};
