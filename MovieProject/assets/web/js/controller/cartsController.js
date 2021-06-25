//Payment
$(document).ready(function () {
    $('.price').number(true, 0, ',', '.');
    $("#paymentPrice").number(true, 0, ',', '.');
});




var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $("#btnContinue").off('click').on('click', () => {
            window.location.href = "/";
        });

        $("#btnUpdate").off('click').on('click', function() {
             var listProduct = $('.txtQuantity');
             var cartList = [];
             $.each(listProduct, function (i, item) {
                cartList.push({
                Quantity: $(item).val(),
                Movie: {
                    MovieID: $(item).data('id')
                }
        });
    });
    $.ajax({
        url: '/Cart/Update',
        data: { cartModel: JSON.stringify(cartList) },
        dataType: 'json',
        type: "POST",
        success: (res) => {
            if (res.status == true) {
                window.location.href = "/gio-hang";
            }
        }
    })
});

        $("#btnPayment").off('click').on('click', () => {
            window.location.href = "/thanh-toan";
        });

        $("#btnDeleteAll").off('click').on('click', () => {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: "POST",
                success: (res) => {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        $(".btn-delete").off('click').on('click', function(e) {
            e.preventDefault();
            var smt = $(this).value;
            console.log(smt);

            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: "POST",
                success: (res) => {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
        let x = document.querySelectorAll(".price");
        var price = 0;
        for (var i = 0; i < x.length; i++) {
            price += Number(x[i].getAttribute("value"));
        }
        document.getElementById("totalPrice").innerHTML = price;
        document.getElementById("totalPrice").value = price;
        document.getElementById("paymentPrice").value = price;
    }
}
cart.init();



