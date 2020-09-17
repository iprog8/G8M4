// JavaScript source code
const server = "https://localhost:44399/api"
const currency = "/currency"
$.getJSON(server + currency, function (currencies) {
    var valute = [];
    for (const i in currencies) {
        const currency = currencies[i];
        valute.push(`<li id='${currency.Id}'>1 ${currency.Valuta} = ${currency.Paritate} RON</li>`)
    }
    $("<ul/>", {
        class: "currencies",
        html: valute.join("")
    }).appendTo("div#valute")
});