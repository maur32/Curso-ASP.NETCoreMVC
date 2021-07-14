const alertMessage = $(".alert").addClass("d-none")
const form = $("form")

form.submit(function (e) {
    if ($("#nome").val().trim() === "") {
        e.preventDefault()
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Nome' é obrigatório!")
    } else if ($("#nome").val().length > 50) {
        e.preventDefault()
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Nome' deve conter no máximo 50 caracteres!")
    } else if ($("#email").val().trim() === "") {
        e.preventDefault()
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'E-mail' é obrigatório!")
    } else if ($("#email").val().length > 70) {
        e.preventDefault()
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'E-mail' deve conter no máximo 70 caracteres!")
    } else if (!isEmail($("#email").val())) {
        e.preventDefault()
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'E-mail' é inválido!")
    } else if ($("#assunto").val().trim() === "") {
        e.preventDefault()
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Assunto' é obrigatório!")
    } else if ($("#assunto").val().length > 50) {
        e.preventDefault()
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Assunto' deve conter no máximo 70 caracteres!")
    } else if ($("#mensagem").val().trim() === "") {
        e.preventDefault()
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Mensagem' é obrigatório!")
    } else if ($("#mensagem").val().length > 50) {
        e.preventDefault()
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Assunto' deve conter no máximo 2000 caracteres!")
    }
})


function isEmail(email) {
    return /^[^\s@]+@[^\s@]+$/.test(email)
}