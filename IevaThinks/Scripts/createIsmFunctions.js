$(document).ready(function () {
    // Send an AJAX request
    
    $("#ismConfigurationId").change(function () {
        var urlEndpoint = $(this).data("endpoint") + "/" + $(this).val();
        $.getJSON(urlEndpoint)
        .done(function (item) {
               // BaseImageUrl: "~/Images/kristineSpeech.jpg"
              //  BubbleTextInputHeight: "190"
              //  BubbleTextInputLeft: "640"
               // BubbleTextInputTop: "60"
              //  BubbleTextInputWidth: "280"
               // CreatedOn: "2014-02-06T05:20:49.11"
               // Id: 3
               // Isms: null
              //  TargetName: "Kristine"
                // Username: "darragh.oriordan@gmail.com"
                var baseImage = $("#BaseImage");
                baseImage.attr("src", baseImage.data("basepath") + item.BaseImageUrl.substring(2))

                var txtEntry = $("#txtMessage");
                txtEntry.css({ width: item.BubbleTextInputWidth,height: item.BubbleTextInputHeight,left: item.BubbleTextInputLeft+'px',top: item.BubbleTextInputTop +'px'});
               // txtEntry.css({width: item.BubbleTextInputWidth});
              //  txtEntry.css("height", item.BubbleTextInputHeight);
              //  txtEntry.css("left", item.BubbleTextInputLeft);
              //  txtEntry.css("top", item.BubbleTextInputTop);
            });
        });
    });