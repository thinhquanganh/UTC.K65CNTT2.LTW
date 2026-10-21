
document.addEventListener("DOMContentLoaded", function () {
    const currentPath = window.location.pathname.toLowerCase();

    document.querySelectorAll(".sidebar-link").forEach(function (link) {
        const href = link.getAttribute("href");

        if (href && href.toLowerCase() === currentPath) {
            link.classList.add("active");
        }
    });
});
