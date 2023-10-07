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

function redirectToLogin() {
    window.location.href = 'Login.aspx';
}

function enterKeyPressed(event) {
    if (event.keyCode == 13) {
        var searchQuery = document.getElementById("searchInput").value;
        if (searchQuery.trim() !== "") {
            window.location.href = "Search.aspx?query=" + encodeURIComponent(searchQuery);
        }
        return false;
    }
    return true;
}








