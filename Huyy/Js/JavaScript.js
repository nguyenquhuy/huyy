document.getElementById("loginBtn").addEventListener("click", function () {
    var dropdownMenu = document.getElementById("dropdownMenu");
    dropdownMenu.classList.toggle("show");
});

// Close the dropdown menu if the user clicks outside of it
window.addEventListener("click", function (event) {
    var dropdownMenu = document.getElementById("dropdownMenu");
    if (!event.target.matches("#loginBtn")) {
        if (dropdownMenu.classList.contains("show")) {
            dropdownMenu.classList.remove("show");
        }
    }
});