

function validateUserForm() {
    var name = document.getElementById('Name').value.trim();
    var email = document.getElementById('Email').value.trim();
    var password = document.getElementById('PasswordHash').value.trim();
    var phone = document.getElementById('PhoneNumber').value.trim();

    if (!name) {
        Swal.fire({
            icon: 'warning',
            title: 'Исм киритилмади',
            text: 'Илтимос, админ исмини киритинг.'
        });
        return false;
    }

    if (!email) {
        Swal.fire({
            icon: 'warning',
            title: 'Email киритилмади',
            text: 'Илтимос, email манзилингизни киритинг.'
        });
        return false;
    }

    if (!password) {
        Swal.fire({
            icon: 'warning',
            title: 'Пароль киритилмади',
            text: 'Илтимос, парольни киритинг.'
        });
        return false;
    }

    if (!phone) {
        Swal.fire({
            icon: 'warning',
            title: 'Телефон рақам киритилмади',
            text: 'Илтимос, телефон рақамингизни киритинг.'
        });
        return false;
    }

    return true;
}


document.addEventListener("DOMContentLoaded", function () {
    const select = document.getElementById("language");
    const inputContainer = document.getElementById("languageInputContainer");
    const inputField = document.getElementById("Language");

    let selectedLanguages = [];

    // Selectdan til tanlaganda ishlaydi
    select.addEventListener("change", function () {
        const selectedValue = select.value;

        if (selectedValue) {
            if (!selectedLanguages.includes(selectedValue)) {
                selectedLanguages.push(selectedValue);
            }

            updateUI();
        }
    });

    // Input maydonida bosilganda tahrirlashni yoqish
    inputField.addEventListener("click", function () {
        let newValues = prompt("Тилни танланг:", selectedLanguages.join(", "));

        if (newValues !== null) {
            selectedLanguages = newValues.split(",").map(lang => lang.trim()).filter(lang => lang);
            updateUI();
        }
    });

    function updateUI() {
        // Input maydoniga tanlangan tillarni qo‘yish
        inputField.value = selectedLanguages.join(", ");
        inputContainer.style.display = selectedLanguages.length > 0 ? "block" : "none";

        // Select menyusini tozalash
        select.innerHTML = `<option value="">Тилни танланг</option>`;
        const allLanguages = ["English", "O'zbek", "Русский"];

        // O'chirilgan tillarni qaytarish
        allLanguages.forEach(lang => {
            if (!selectedLanguages.includes(lang)) {
                const option = document.createElement("option");
                option.value = lang;
                option.textContent = lang;
                select.appendChild(option);
            }
        });

        // Agar hammasi tanlangan bo'lsa, select menyusini yashirish
        select.style.display = selectedLanguages.length === allLanguages.length ? "none" : "block";
    }
});

$(document).ready(function () {
    // Ismni tekshirish
    $('#Name').on('blur', function () {
        let name = $(this).val();

        if (name.length === 0) return;

        $.ajax({
            type: "POST",
            url: "/Users/CheckName",
            data: { name: name },
            success: function (response) {
                if (response.exists) {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Исм мавжуд',
                        text: 'Бу исм аллақачон мавжуд, илтимос бошқа исм киритинг!',
                    });

                    $('#Name').val('');
                }
            },
            error: function () {
                console.error("Ismni tekshirishda xatolik yuz berdi.");
            }
        });
    });

    // Parolni tekshirish
    $('#PasswordHash').on('blur', function () {
        let password = $(this).val();

        if (password.length === 0) return;

        $.ajax({
            type: "POST",
            url: "/Users/CheckPassword",
            data: { password: password },
            success: function (response) {
                if (response.exists) {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Пароль ишлатилган',
                        text: 'Ушбу паролдан фойдаланилган, илтимос бошқа парол киритинг!',
                    });

                    $('#PasswordHash').val('');
                }
            },
            error: function () {
                console.error("Parol tekshiruvda xatolik yuz berdi.");
            }
        });
    });

    // Email tekshiruvi
    $('#Email').on('blur', function () {
        let email = $(this).val();

        if (email.length === 0) return;

        $.ajax({
            type: "POST",
            url: "/Users/CheckEmail",
            data: { email: email },
            success: function (response) {
                if (response.exists) {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Email мавжуд',
                        text: 'Бу email аллақачон мавжуд, илтимос бошқа email киритинг!',
                    });

                    $('#Email').val('');
                }
            },
            error: function () {
                console.error("Email tekshiruvda xatolik yuz berdi.");
            }
        });
    });

});

$(document).ready(function () {
    $('#PhoneNumber').mask('+998 (00) 000 00 00');
});

function showPassword() {
    document.getElementById("PasswordHash").type = "text";
}

function hidePassword() {
    document.getElementById("PasswordHash").type = "password";
}