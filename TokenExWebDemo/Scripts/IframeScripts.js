//Cross Browser Compatible Document Ready Check
function ready(fn) {
    if (document.addEventListener) {
        document.addEventListener('DOMContentLoaded', fn);
    } else {
        document.attachEvent('onreadystatechange', function () {
            if (document.readyState === 'complete') {
                fn();
            }
        });
    }
}

//Setup DOM elements and Iframe
ready(function () {
    var paymentForm = document.getElementById("iframeform");
    // This will be null if the success page was loaded
    if (paymentForm === null) return;

    var iframe = TokenEx.Iframe("tokenExIframe", iframeConfig);
    SetupIframeEvents(iframe, paymentForm);
    iframe.load();

    var submitButton = document.getElementById("btnSubmit");
    submitButton.onclick = function () {
        iframe.tokenize();
    }
});

function SetupIframeEvents(iframe, paymentForm) {
    iframe.on("load",
        function () {
            console.info("Iframe loaded");
        });

    iframe.on("focus",
        function () {
            console.info("Iframe focused");
        });

    iframe.on("blur",
        function () {
            console.info("Iframe lost focus");
        });

    iframe.on("change",
        function () {
            iframe.validate();
            console.info("Iframe value changed");
        });

    iframe.on("cardTypeChange",
        function (data) {
            console.info("Iframe card type changed", data);
        });

    iframe.on("error",
        function (data) {
            console.error("Iframe error", data);
        });

    iframe.on("validate",
        function (data) {
            data.isValid
                ? console.info("Iframe validated PCI data")
                : console.info("Iframe validation failed");
        });
    iframe.on("tokenize",
        function (data) {
            console.log("Iframe tokenized data:", data);
            if (data.token) {
                document.getElementById("token").value = data.token;
                document.getElementById("iframeData").value = data.tokenHMAC;
                paymentForm.submit();
            }
        });
    iframe.on("cvvFocus",
        function () {
            console.info("Iframe CVV focused");
        });

    iframe.on("cvvBlur",
        function () {
            console.info("Iframe CVV lost focus");
        });
}