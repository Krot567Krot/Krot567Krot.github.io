const modal = document.querySelector(".modalwindow");
const close = document.querySelector(".modalwindow-close");

setTimeout(() => { modal.classList.toggle("is-openmodalwindow") }, 5000)

function Modal() {
    close.addEventListener('click', () => {
        modal.classList.toggle("is-openmodalwindow")
    }
    )
}
Modal()