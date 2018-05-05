$(document).ready(function(){
	var ctx = $("#mycanvas").get(0).getContext("2d");
	
	var data = graph_data_by_year(20,40,10, '2017-2018');
	
	var chart = new Chart(ctx).Doughnut(data);
});

//social: social data
//serach: search data
//display: display data
function graph_data_by_year(social, search, display, year)
{
		var data = [
		{
			value: social,
			color: "cornflowerblue",
			highlight: "lightskyblue",
			label: "Social"
		},
		{
			value: search,
			color: "lightgreen",
			highlight: "yellowgreen",
			label: "Paid Search"
		},
		{
			value: display,
			color: "orange",
			highlight: "darkorange",
			label: "Display"
		}
		
	];
	return data;
}