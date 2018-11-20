$(document).ready(function () {
	var x = 0;
	var s = "";
	console.log("hello");

	var button = $("#buyButton");
	button.on("click", function () {
		console.log("buying item");
	});

	var $loginToggle = $("#loginToggle");
	var $popupForm = $(".popup-form");

	$loginToggle.on("click", function () {
		$popupForm.toggle(1000);
	});
});