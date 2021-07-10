const form = document.querySelector("form")
const nome = document.querySelector("input[name='nome']")
const email = document.querySelector("input[name='email']")
const assunto = document.querySelector("input[name='assunto']")
const mensagem = document.querySelector("textarea")
const alertMessage = document.querySelector(".alert")

alertMessage.style.display = "none"

form.onsubmit = function (e) {
    if (nome.value.trim() === "") {
        e.preventDefault()
        alertMessage.style.display = "block"
        alertMessage.innerText = "O campo 'Nome' é obrigatório!"
    } else if (nome.value.length > 50) {
        e.preventDefault()
        alertMessage.style.display = "block"
        alertMessage.innerText = "O campo 'Nome' deve conter no máximo 50 caracteres!"
    } else if (email.value.trim() === "") {
        e.preventDefault()
        alertMessage.style.display = "block"
        alertMessage.innerText = "O campo 'Email' é obrigatório!"
    } else if (email.value.length > 70) {
        e.preventDefault()
        alertMessage.style.display = "block"
        alertMessage.innerText = "O campo 'Nome' deve conter no máximo 70 caracteres!"
    }
    else if (!isEmail(email.value)) {
        e.preventDefault()
        alertMessage.style.display = "block"
        alertMessage.innerText = "O campo 'E-mail' é inválido!"
    } else if (assunto.value.trim() === "") {
        e.preventDefault()
        alertMessage.style.display = "block"
        alertMessage.innerText = "O campo 'Assunto' é obrigatório!"
    } else if (assunto.value.length > 70) {
        e.preventDefault()
        alertMessage.style.display = "block"
        alertMessage.innerText = "O campo 'Assunto' deve conter no máximo 70 caracteres!"
    } else if (mensagem.value.trim() === "") {
        e.preventDefault()
        alertMessage.style.display = "block"
        alertMessage.innerText = "O campo 'Mensagem' é obrigatório!"
    } else if (mensagem.value.length > 2000) {
        e.preventDefault()
        alertMessage.style.display = "block"
        alertMessage.innerText = "O campo 'Mensagem' deve conter no máximo 2000 caracteres!"
    }
}

function isEmail(email) {
    return /^[^\s@]+@[^\s@]+$/.test(email)
}
