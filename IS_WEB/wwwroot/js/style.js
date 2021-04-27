
function loadPagination(total) {
    total = Math.ceil(total / length);
    $('#pagination').html("");
    $('#pagination').append("<li class='paginate_button page-item previous disabled' id='dataTable_previous'><a class='page-link'>Trước</a></li>");
    for (let i = 1; i <= total; i++) {
        $('#pagination').append(`<li class="paginate_button page-item item " value='${i}'><a class='page-link'>${i}</a></li>`)
    }
    $('#pagination').append(`<li class="paginate_button page-item next" id="dataTable_next"><a class='page-link'>Sau</a></li>`)
    var PaginationElement = document.querySelectorAll("li.item");
    $('.page-item.item').click(function () {

        PaginationElement.forEach(function (ele) {
            ele.classList.remove("active");
            ele.classList.remove("disabled");

        })
        this.classList.add("active");
        start = this.value;
        loadData(start, length, object);
    })

    $('.previous').click(function () {
        if (start > 1) {

            start--;
            loadData(start, length, object);

            this.classList.remove("disabled");
            PaginationElement.forEach(function (ele) {
                ele.classList.remove("active");
                ele.classList.remove("disabled");
                if (ele.value == start) ele.classList.add("active");

            })
        }
        else this.classList.add("disabled");
    })

    $('.next').click(function () {

        if (start < total) {

            start++;
            loadData(start, length, object);

            this.classList.remove("disabled");
            PaginationElement.forEach(function (ele) {
                ele.classList.remove("active");
                ele.classList.remove("disabled");
                if (ele.value == start) ele.classList.add("active");

            })
        }
        else this.classList.add("disabled");
    })
}

function check() {
    var inputs = document.querySelectorAll("#form-main > div > .form-control");
    inputs.forEach(function (val) {
        val.onblur = function () {
            if (val.value == '' || val.value === null) {
                val.parentNode.children[3].innerHTML = "Vui lòng nhập trường này";
                val.parentNode.children[3].style.color = "red";
            }

        }
        val.oninput = function () {
            val.parentNode.children[3].innerHTML = "";
        }
    })
}