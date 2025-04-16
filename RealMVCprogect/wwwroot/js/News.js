function previewImage(event) {
    var reader = new FileReader();

    reader.onload = function () {
        var output = document.getElementById('image-preview');
        output.src = reader.result;
        output.style.display = 'block'; // Rasmni ko'rsatish
    }

    reader.readAsDataURL(event.target.files[0]); // Tanlangan rasmni o'qish
}


function validateForm() {
    var title = document.getElementById('short-news').value.trim();
    var content = document.getElementById('detailed-news').value.trim();
    var image = document.getElementById('image').files.length;

    if (!title) {
        Swal.fire({
            icon: 'warning',
            title: 'Қисқача янгилик киритилмади',
            text: 'Илтимос, қисқача янгиликни киритинг.'
        });
        return false;
    }

    if (!content) {
        Swal.fire({
            icon: 'warning',
            title: 'Тўлиқ янгилик киритилмади',
            text: 'Илтимос, тўлиқ янгиликни киритинг.'
        });
        return false;
    }

    if (image === 0) {
        Swal.fire({
            icon: 'warning',
            title: 'Расм танланмади',
            text: 'Илтимос, расм танланг.'
        });
        return false;
    }

    // Agar barcha maydonlar to‘g‘ri to‘ldirilgan bo‘lsa — Swal orqali statusni tanlaymiz
    Swal.fire({
        title: 'Status tanlang',
        text: "Yangilikni qaysi holatda saqlamoqchisiz?",
        icon: 'question',
        showCancelButton: true,
        showDenyButton: true,
        confirmButtonText: 'Prod',
        denyButtonText: 'Черновик',
        cancelButtonText: 'Bekor qilish'
    }).then((result) => {
        if (result.isConfirmed) {
            document.getElementById("Status").value = 1;
            document.querySelector("form").submit();
        } else if (result.isDenied) {
            document.getElementById("Status").value = 0;
            document.querySelector("form").submit();
        }
    });

    return false; // Formani avtomatik yuborishni to‘xtatamiz
}
