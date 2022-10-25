$(document).ready(function () {
    LoadList();
    Event();
})

function Event() {
    // btn add cart 
    $(document).on("click", ".btnAddCart", function () {
        var _id = $(this).data("id");
        $.ajax({

            url: "/GioHang/Add",
            type: "post",
            data: {
                id: _id,
                quantity: 1
            },
            success: function (response) {
                if (response.isSuccess) {
                    LoadList();
                }
                ShowAlert(response.message, response.isSuccess);
            }
        })
    })

    // btn remove cart 
    $(document).on("click", ".btnRemoveCart", function () {
        var _id = $(this).data("id");
        $.ajax({

            url: "/GioHang/Remove",
            type: "delete",
            data: {
                id: _id,
            },
            success: function (response) {
                if (response.isSuccess) {
                    LoadList();
                }
                ShowAlert(response.message, response.isSuccess);
            }
        })
    })
}












function LoadList()
{
    $.ajax({
        url: "/GioHang/Carts",
        type: "get",
        success: function (response) {
            console.log(response);
            InsertList(response.data);
        }
    })
}

function InsertList(data) {
    $("#tblCart").empty();
    if (data.length <= 0 || data == null) {
        var tr = "<lable> Không có sản phẩm nào !</lable>";

        $("#tblCart").append(tr);
    }
    var count = 0;
    $.each(data, function (k, v) {
        var html = `<div class="box">
                <i data-id=` + v.chitietId + ` class="fas fa-times btnRemoveCart" ></i>
                <img width="50" height="40" src="/Image/` + v.monAn.hinh +`" alt="">
                <div class="content">
                    <h3> ` + v.monAn.tenMon + `</h3>
                    <span class="quantity">` + v.soluong + `</span>
                    <span class="multiply">x</span>
                    <span class="price">$ ` + v.monAn.gia + `</span>
                </div>
            </div>`

        count += parseInt(v.soluong);

        $("#tblCart").append(html);

    })
    $("#cartCount").text(count);
}