import "./DropzoneJs/dropzone.js";
import { App } from "./DropzoneJs/dropJsApp.js?v1.0";

//Arka tarafta ki sekron değerini beklerken kullancıya bilgi vermek amacıyla yapılmıştır
const loadingProcess = () => {
  Swal.fire({
    title: "İşlem Gerçekleşiyor",
    timerProgressBar: true,
    didOpen: () => {
      Swal.showLoading();
    },
  });
};

let pathName = window.location.pathname;

// Ekleme Sayfası İçin !
const addPlant = () => {
  $(document).ready(function () {
    if (pathName == "/AddPlant/AddPlantIndex") {
      let propsArray = [];
      $("#PlantName").keyup(function (e) {
        propsArray[0] = e.target.value;
      });
      $("#PlantAbout").keyup(function (e) {
        propsArray[1] = e.target.value;
      });

      App(pathName, propsArray);
    }
  });
};

//Günceleme Sayfası İçin
const updatePlant = () => {
  let _getpathName = pathName.search("/UpdatePlant/UpdatePlantIndex/");

  $(document).ready(function () {
    if (_getpathName == 0) {
      let propsArray = [];
      propsArray[3] = _getpathName;
      //dataNumberi propsArraya Atıyorum ve diğer tarafta bu değeri karşılayacağım.
      $("#btnDropzonePost").click(function (e) {
        propsArray[2] = Number(e.target.getAttribute("data-number"));
        e.preventDefault();
      });

      $("#PlantName").keyup(function (e) {
        propsArray[0] = e.target.value;
      });
      $("#PlantAbout").keyup(function (e) {
        propsArray[1] = e.target.value;
      });
      App("/UpdatePlant/UpdatePlantIndex", propsArray);

      // PlantInfo Upadate

      $("#sendBtnPlant").click(function (e) {
        let PlantName = $("#PlantName").val();
        let PlantAbout = $("#PlantAbout").val();
        let ssQQmmLL = $(e.target).attr("data-number");

        var requestData = {
          PlantName: PlantName,
          PlantAbout: PlantAbout,
          ssQQmmLL: ssQQmmLL,
        };
        loadingProcess();
        $.ajax({
          url: "/UpdatePlant/UpdatePlantIndex",
          type: "POST",
          data: JSON.stringify(requestData),
          dataType: "json",
          contentType: "application/json; charset=utf-8",
          success: function (response) {
            if ((response.response = "successUpdate")) {
              setTimeout(() => {
                Swal.fire({
                  icon: "success",
                  title: "Başarılı ",
                  text: "Bilgi Değişimi Başarılı !",
                  confirmButtonText: "Tamamdır",
                });
              }, 3000);
            }
          },
        });
      });
    }
  });
};

//Silme Sayfası
const removePlant = () => {
  $(document).ready(function () {
    if (pathName.search("/ReadPlants/IndexList") == 0) {
      let dataNumberArray;
      $(".btnRemove").click((e) => {
        dataNumberArray = e.target.getAttribute("data-number");
        // let hrefSendBtnDeletePlant = $("#sendBtnDeletePlant").attr("href");
        // $("#sendBtnDeletePlant").attr(
        //   "href",
        //   hrefSendBtnDeletePlant + dataNumberArray
        // );
      });

      $("#sendBtnDeletePlant").click(() => {
        loadingProcess();
        $.ajax({
          url: "/DeletePlant/DeletePlantIndex",
          type: "POST",
          data: JSON.stringify({ id: dataNumberArray }),
          dataType: "json",
          contentType: "application/json; charset=utf-8",
          success: function (response) {
            if (response.response == "successDeleted") {
              setTimeout(() => {
                Swal.fire({
                  icon: "success",
                  title: "Başarılı ",
                  text: "Silme İşlemi Başarılı !",
                  confirmButtonText: "Tamamdır",
                });
              }, 3000);
              setTimeout(() => {
                window.location.reload();
              }, 1200);
            }
          },
        });
      });

      $("#btnClearText").hide(0);
      $("#searchText").keyup(function (e) {
        if (e.target.value != null || e.target.value != "") {
          $("#btnClearText").show(750);
          $("#btnClearText").click(function (e) {
            $("#searchText").val("");
            $("#btnClearText").hide(750);
          });
        } else {
          $("#btnClearText").hide(750);
        }
      });
    }
  });
};

removePlant();
addPlant();
updatePlant();
