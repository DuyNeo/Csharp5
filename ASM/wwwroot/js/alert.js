function ShowAlert(message, type) {
    const main = document.getElementById("alertMessage");
    if (main) {
        const alert = document.createElement("div");

        var icon;
        var title;
        switch (type) {
            case true: icon = "fas fa-check-circle"; title = "Thành công"; break;
            case false: icon = "fas fa-times-circle"; title = "Thất bại"; break;
        }
        var idtime = setTimeout(() => {
            main.removeChild(alert);
        }, 5000);
        alert.onclick = function (e) {
            if (e.target.closest(".alert-close")) {
                main.removeChild(alert);
                clearTimeout(idtime);
            }
        };
        alert.classList.add("alertMessage");
        alert.innerHTML = `
        <div class="alert-icon">
            <i class="${icon}"></i>
        </div>
        <div class="alert-body">
            <h3 class="alert-title">${title}</h3>
            <p class="alert-desc">${message}</p>
        </div>
        <div class="alert-close">
            <i class="fa fa-times"></i>
        </div>
    `;
        alert.classList.add(`alert--${type}`);
        main.appendChild(alert);
    }
}