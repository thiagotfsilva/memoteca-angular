
// Função para aplicar a máscara de telefone
function mascaraTelefone(telefone: string): string {
    const numeros = telefone.replace(/\D/g, '');
    if (numeros.length <= 2) {
        return `(${numeros}`;
    }
    if (numeros.length <= 6) {
        return `(${numeros.slice(0, 2)}) ${numeros.slice(2)}`;
    }
    if (numeros.length <= 10) {
        return `(${numeros.slice(0, 2)}) ${numeros.slice(2, 6)}-${numeros.slice(6)}`;
    }
    return `(${numeros.slice(0, 2)}) ${numeros.slice(2, 7)}-${numeros.slice(7, 11)}`;
}

export { mascaraTelefone }