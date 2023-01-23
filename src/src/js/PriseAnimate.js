const time = 100;
const step = 2;
function outNum(num, elem) {
    let l = document.querySelector('#' + elem);
    n = 0;
    let t = Math.round(time / (num / step));
    let interval = setInterval(() => {
        n = n + step;
        if (n == num) {
            clearInterval(interval)
        }
        l.innerHTML = n;
    },
        t)
}
const time2 = 80;
const step2 = 50;
function outNum2(num2, elem2) {
    let l2 = document.querySelector('#' + elem2);
    n2 = 0;
    let t2 = Math.round(time2 / (num2 / step2));
    let interval2 = setInterval(() => {
        n2 = n2 + step2;
        if (n2 == num2) {
            clearInterval(interval2)
        }
        l2.innerHTML = n2;
    },
        t2)
}
const time3 = 1500;
const step3 = 1;
function outNum3(num3, elem3) {
    let l3 = document.querySelector('#' + elem3);
    n3 = 0;
    let t3 = Math.round(time3 / (num3 / step3));
    let interval3 = setInterval(() => {
        n3 = n3 + step3;
        if (n3 == num3) {
            clearInterval(interval3)
        }
        l3.innerHTML = n3;
    },
        t3)
}
const time4 = 100;
const step4 = 5;
function outNum4(num4, elem4) {
    let l4 = document.querySelector('#' + elem4);
    n4 = 0;
    let t4 = Math.round(time4 / (num4 / step4));
    let interval4 = setInterval(() => {
        n4 = n4 + step4;
        if (n4 == num4) {
            clearInterval(interval4)
        }
        l4.innerHTML = n4;
    },
        t4)
}

let flag = true;


$(document).ready(() => {

    let options = { threshold: [0.5] };
    let observer = new IntersectionObserver(onEntry, options);
    elements = $('.card-text')
    elements.each((i, el) => {
        observer.observe(el);
    });

});

function onEntry(entry) {
    entry.forEach(change => {
        if (change.isIntersecting && flag) {
            outNum(120, 'card-digit1')
            outNum2(4600, 'card-digit2')
            outNum3(23, 'card-digit3')
            outNum4(340, 'card-digit4')
            flag = false

        }
    });

}


