
let summ = 0;
let days = 0;
typeVebSite = prompt(`какой тип сайта: 1) визитка 2) справочник 3) интернет магазин `)

desisgneVebSite = prompt(`какой дизайн: 1) шаблонный 2) по макету 3) уникальный `)

adaptiveVebSite = prompt(`адаптивность: 1) не адаптивный 2) адаптивный под мобильные устройства 3) адаптип под все устройства `)


const user = {
    typesite: typeVebSite,
    desinesite: desisgneVebSite,
    adaptivesite: adaptiveVebSite
}

if (user['typesite'] == '1') {
    user['typesite'] = 1000,
        days += 1
} else if (user['typesite'] == '2') {
    user['typesite'] = 2000,
        days += 3
} else if (user['typesite'] == '3') {
    user['typesite'] = 4000,
        days += 10
} else (console.log('error'))

if (user['desinesite'] == '1') {
    user['desinesite'] = 500,
        days += 2
} else if (user['desinesite'] == '2') {
    user['desinesite'] = 3000,
        days += 4
} else if (user['desinesite'] == '3') {
    user['desinesite'] = 6000,
        days += 7
} else (console.log('error'))

if (user['adaptivesite'] == '1') {
    user['adaptivesite'] = 1000,
        days += 2
} else if (user['adaptivesite'] == '2') {
    user['adaptivesite'] = 2000,
        days += 4
} else if (user['adaptivesite'] == '3') {
    user['adaptivesite'] = 3000,
        days += 7
} else (console.log('error'))



let InvoiceAmount = () => {
    summ = user['typesite'] + user['desinesite'] + user['adaptivesite']
    alert('сумма: ' + summ + ' дни:' + days)
}
InvoiceAmount()