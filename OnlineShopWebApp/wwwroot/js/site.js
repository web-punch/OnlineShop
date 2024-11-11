// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const buttonLogin = document.getElementById("buttonLogin");
if (buttonLogin != null) {
    buttonLogin.addEventListener('click', function (event) {
        let returnUrl = window.location.pathname;
        if (returnUrl == "/") {
            returnUrl = window.location.href;
        }
        window.location.replace("/Authorization/Login?returnUrl=" + returnUrl);
    });
}

document.addEventListener('click', function (event) {
    let element = event.target;
    if (element.classList[0] == "buttonAddToCart") {
        let productId = element.dataset.productid;
        $.ajax({
            type: "POST",
            url: "/Cart/AddProductPartial",
            data: { productId: productId },
            success: function (result) {
                $("#updateNavbarIcons").html(result);
            },
            error: function (errorCode, ex) {
                if (errorCode.status == 401) {
                    let currentUrl = window.location.pathname
                    if (currentUrl == "/") {
                        currentUrl = window.location.href
                    }
                    let returnUrl = "/Cart/AddProduct?productId=" + productId + "&comeBackUrl=" + currentUrl;
                    window.location.replace("/Authorization/Login?returnUrl=" + returnUrl);
                }
            },
        });
        return;
    }
    if (element.classList[0] == "buttonAddToFavorites") {
        let productId = element.dataset.productid;
        $.ajax({
            type: "POST",
            url: "/Favorites/AddProductPartial",
            data: { productId: productId },
            success: function (result) {
                $("#updateNavbarIcons").html(result);
            },
            error: function (errorCode, ex) {
                if (errorCode.status == 401) {
                    let currentUrl = window.location.pathname
                    if (currentUrl == "/") {
                        currentUrl = window.location.href
                    }
                    let returnUrl = "/Favorites/AddProduct?productId=" + productId + "&comeBackUrl=" + currentUrl;
                    window.location.replace("/Authorization/Login?returnUrl=" + returnUrl);
                }
            },

        });
        return;
    }
    if (element.classList[0] == "buttonReduceQuantity") {
        let productId = element.dataset.productid;
        $.ajax({
            type: "POST",
            url: "/Cart/ReduceQuantityProductPartial",
            data: { productId: productId },
            success: function (result) {
                $("#updateCartItem-" + productId).html(result);
                $.ajax({
                    type: "POST",
                    url: "/Cart/UpdateProductsCartPartial",
                    success: function (result) {
                        $("#updateNavbarIcons").html(result);
                    }
                });
                $.ajax({
                    type: "POST",
                    url: "/Cart/UpdateCartCostPartial",
                    success: function (result) {
                        $("#updateCartCost").html(result);
                    }
                });
            }
        });
        return;
    }
    if (element.classList[0] == "buttonIncreaseQuantity") {
        let productId = element.dataset.productid;
        $.ajax({
            type: "POST",
            url: "/Cart/AddProductPartial",
            data: { productId: productId },
            success: function (result) {
                $("#updateNavbarIcons").html(result);
                $.ajax({
                    type: "POST",
                    url: "/Cart/UpdateQuantityProductPartial",
                    data: { productId: productId },
                    success: function (result) {
                        $("#updateCartItem-" + productId).html(result);
                    },
                });
                $.ajax({
                    type: "POST",
                    url: "/Cart/UpdateCartCostPartial",
                    success: function (result) {
                        $("#updateCartCost").html(result);
                    }
                });
            },
        });
    }
});


