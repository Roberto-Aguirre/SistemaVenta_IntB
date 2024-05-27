$(document).ready(function () {
    fetch("/Negocio/Obtener")
        .then(response => {

            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            console.log(responseJson)
            let { nombre, urlLogo } = responseJson.objeto
            $("#nombreNegocio").text(nombre)
            const logo = document.createElement("img")
            logo.src = urlLogo
            $(".sidebar-brand-icon").append(logo)

        })

})