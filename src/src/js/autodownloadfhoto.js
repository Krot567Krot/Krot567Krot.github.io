$(document).ready(() => {

    let options = { threshold: [0.5] };
    let observer = new IntersectionObserver(onEntry, options);
    elements = $('.info-iconparent')
    elements.each((i, el) => {
        observer.observe(el);
    });

});

function onEntry(entry) {
    entry.forEach(change => {
        if (change.isIntersecting) {

            change.target.src = change.target.dataset.src

        }
    });

}