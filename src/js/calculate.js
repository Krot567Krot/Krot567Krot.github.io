$(document).ready(() => {

    function calculate() {
        let sum = parseInt($("#select1 option:selected").val()) + parseInt($("#select2 option:selected").val()) + parseInt($("#select3 option:selected").val())
        let days = parseInt($("#select1 option:selected").attr("days")) + parseInt($("#select2 option:selected").attr("days")) + parseInt($("#select3 option:selected").attr("days"))
        $(".prise-cost .cost-exactly").text(sum)
        $(".prise-term .temp-exactly").text(days)
    }
    $("select").on("change", () => {
        calculate()
    });
});
console.log(15)