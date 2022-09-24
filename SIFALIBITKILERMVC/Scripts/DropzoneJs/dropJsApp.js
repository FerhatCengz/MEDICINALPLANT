Dropzone.autoDiscover = false;
export const App = (actionName, params = []) => {
  $("#mydropzone").dropzone({
    url: actionName,
    autoProcessQueue: false,
    paramName: "file",
    dictDefaultMessage: "Fotoğrafınızı Sürükle / Bırak Yaparak Seçebilirsiniz",
    maxFiles: 1,
    dictMaxFilesExceeded: "En fazla 1 Dosya Gönderebilirsiniz",
    maxFilesize: 5,
    dictFileTooBig: "Dosya boyutu fazla - Max:5Mb",
    acceptedFiles: "image/jpeg,image/png,image/gif",
    dictInvalidFileType: "Geçersiz dosya tipi (.png) olmalı !",
    addRemoveLinks: true,
    dictRemoveFile: "Dosyayı Kaldır",
    init: function () {
      const dz = this;
      this.on("sending", function (image, xhr, formData) {
        formData.append("PlantImage", image.name);
        formData.append("PlantName", params[0]);
        formData.append("PlantAbout", params[1]);
        formData.append("paramProcess", "updateImage");
        formData.append("ssQQmmLL", params[2]);
      });

      $(document).on("click", "#btnDropzonePost", function (e) {
        dz.processQueue();
      });

      dz.on("error", function (file) {
        alert("Bir Sorun İle Karşılaştık Lütfen Tekrar Deneyiniz");
      });

      dz.on("success", function (file, respone) {
        //Params indexi 3 ise belliki bir güncelleme yapılacak
        if (params[3] == 0) {
          let plantImage = $("#plantImage").attr(
            "src",
            "/PlantsPhoto/" + file.name
          );
        }

        switchFunc(respone.response);
      });
    },
  });
};

const switchFunc = (param) => {
  switch (param) {
    case "successPhoto":
      switAlertParamFunc(
        "success",
        "Güncelleme İşlemi Başarılı !",
        "Fotoğrafınız Başarılı İle Güncellendi.",
        "Tamamdır"
      );
      break;
    case "successAdded":
      switAlertParamFunc(
        "success",
        "Ekleme İşlemi Başarılı",
        "Şıfalı Bitki Başarıyla Eklendi",
        "Tamamdır"
      );
      break;

    default:
      break;
  }
};

const switAlertParamFunc = (_icon, _title, _text, _confirmButtonText) => {
  Swal.fire({
    icon: _icon,
    title: _title,
    text: _text,
    confirmButtonText: _confirmButtonText,
  });
};
