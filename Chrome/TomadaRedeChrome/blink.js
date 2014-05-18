$(document).ready(function() {

var statusVermelho = 0;
var statusAmarelo = 0;
var statusVerde = 0;

$(".lamp-vermelha").click(function() {
	valor = (statusVermelho==0)?"1":"0";
	$(".lamp-vermelha").css("background-image", "url(\"assets/"+((valor=="0")?"off":"on")+"_r.png\")");
	statusVermelho = valor;
	$.get("http://192.168.100.110?ve="+valor)
});

$(".lamp-amarela").click(function() {
	valor = (statusAmarelo==0)?"1":"0";
	$(".lamp-amarela").css("background-image", "url(\"assets/"+((valor=="0")?"off":"on")+"_y.png\")");
	statusAmarelo = valor;
	$.get("http://192.168.100.110?am="+valor)
});

$(".lamp-verde").click(function() {
	valor = (statusVerde==0)?"1":"0";
	$(".lamp-verde").css("background-image", "url(\"assets/"+((valor=="0")?"off":"on")+"_g.png\")");
	statusVerde = valor;
	$.get("http://192.168.100.110?vd="+valor)
});

});

