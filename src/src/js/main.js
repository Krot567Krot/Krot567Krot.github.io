const Burger = document.querySelector(".burger");
const List = document.querySelector(".header-navigation");


Burger.addEventListener('click', toggleModal
)

function toggleModal() {
    List.classList.toggle("is-open")
}
