
$(document).ready(function () {


    $(".card-body").find("div.modal-content").LoadingOverlay("show");

    fetch("/Negocio/Obtener")
        .then(response => {
            $("#modalData").find("div.modal-content").LoadingOverlay("hide");//.card-body
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
 
            console.log(responseJson)
            if (responseJson.estado) {
                const d = responseJson.objeto;

                $("#txtNumeroDocumento").val(d.numeroDocumento)
                $("#txtRazonSocial").val(d.nombre)
                $("#txtCorreo").val(d.correo)
                $("#txtDireccion").val(d.direccion)
                $("#txtTelefono").val(d.telefono)
                $("#txtImpuesto").val(d.porcentajeImpuesto)
                $("#txtSimboloMoneda").val(d.simboloMoneda)
                $("#imgLogo").attr("src", d.urlLogo)

            } else {
                swal("Lo sentimos", responseJson.mensaje, "error");
            }
        });

})

$("#btnGuardarCambios").click(function () {

    const inputs = $("input.input-validar").serializeArray();
    const inputs_sin_valor = inputs.filter((item)=>item.value.trim()=="")

    if (inputs_sin_valor > 0) {
        const mensaje = `Debe completar el campo: "${inputs_sin_valor[0].name}"`;
        toastr.warning("", mensaje);
        $(`input[name="${inputs_sin_valor[0].name}"]`).focus()
        return
    }

    const modelo = {
        numeroDocumento: $("#txtNumeroDocumento").val(),
        nombre:$("#txtRazonSocial").val(),
        correo:$("#txtCorreo").val(),
        direccion: $("#txtDireccion").val(),
        // Ver porque no lo envia
        telefono: $("#txtTelefono").val(),
        porcentajeImpuesto:$("#txtImpuesto").val(),
        simboloMoneda:$("#txtSimboloMoneda").val()
    }

    const inputLogo = document.getElementById("txtLogo");
    const formData = new FormData;
    console.log(JSON.stringify(modelo))
    formData.append("logo", inputLogo.files[0])
    formData.append("modelo", JSON.stringify(modelo));

    $(".card-body").find("div.modal-content").LoadingOverlay("show");

    fetch("/Negocio/GuardarCambios", { method: "POST", body: formData })
        .then(response => {
            $(".card-body").LoadingOverlay("hide");
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.estado) {
                const d = responseJson.objeto;
                $("#imgLogo").attr("src", d.urlLogo);
            } else {
                swal("Lo sentimos", responseJson.mensaje, "error");
            }
        });

})
