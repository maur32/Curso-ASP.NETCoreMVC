const alertMessage = $(".alert").addClass("d-none")
const form = $("form")

function validate() {
    if ($("#nome").val().trim() === "") {
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Nome' é obrigatório!")
        return false
    } else if ($("#nome").val().length > 50) {
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Nome' deve conter no máximo 50 caracteres!")
        return false
    } else if ($("#email").val().trim() === "") {
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'E-mail' é obrigatório!")
        return false
    } else if ($("#email").val().length > 70) {
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'E-mail' deve conter no máximo 70 caracteres!")
        return false
    } else if (!isEmail($("#email").val())) {
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'E-mail' é inválido!")
        return false
    } else if ($("#assunto").val().trim() === "") {
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Assunto' é obrigatório!")
        return false
    } else if ($("#assunto").val().length > 50) {
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Assunto' deve conter no máximo 70 caracteres!")
        return false
    } else if ($("#mensagem").val().trim() === "") {
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Mensagem' é obrigatório!")
        return false
    } else if ($("#mensagem").val().length > 50) {
        alertMessage.removeClass("d-none")
        alertMessage.html("O campo 'Assunto' deve conter no máximo 2000 caracteres!")
        return false
    } else {
        return true
    }
}


function isEmail(email) {
    return /^[^\s@]+@[^\s@]+$/.test(email)
}