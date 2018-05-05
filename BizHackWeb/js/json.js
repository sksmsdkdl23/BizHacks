var DisplayRows = [];
var SearchRows = [];
var SocialRows = [];

$(document).ready(function() {

class Row {
	constructor(fiscalYear, fiscalMonth, channel, campName, impression, clicks, ctr, costs, visits, totalOnlineOrders, totalOnlineRevenue, bounceRate) {
		this.fiscalYear = fiscalYear;
		this.fiscalMonth = fiscalMonth;
		this.channel = channel;
		this.campName = campName;
		this.impression = impression;
		this.clicks = clicks;
		this.ctr = ctr;
		this.costs = costs;
		this.visits = visits;
		this.totalOnlineRevenue = totalOnlineRevenue;
		this.totalOnlineOrders = totalOnlineOrders;
		this.bounceRate = bounceRate;
	}
}


function getRows() {
	   $.getJSON('./json/Display.json', function(data) {
       $.each(data, function(i, f) {
       		var row = new Row(f.fiscalYear,
       			f.fiscalMonth, 
       			"Display",
       			f.campaignName,
       			f.impressions,
       			f.clicks.replace("-", ""),
       			f.ctr.replace("-", ""),
       			f.cost.replace("-", ""),
       			f.visit.replace("-", ""),
       			f.totalOnlineOrders.replace("-", ""),
       			f.totalOnlineRevenue.replace("-", ""),
       			f.bounceRate.replace("-", ""));
       		DisplayRows.push(row);
     });
       $.getJSON('./json/Search.json', function(data) {
       $.each(data, function(i, f) {
			var row = new Row(f.fiscalYear,
       			f.fiscalMonth, 
       			"Paid search",
       			f.campaignName,
       			f.impressions,
       			f.clicks.replace("-", ""),
       			f.ctr.replace("-", ""),
       			f.cost.replace("-", ""),
       			f.visit.replace("-", ""),
       			f.totalOnlineOrders.replace("-", ""),
       			f.totalOnlineRevenue.replace("-", ""),
       			f.bounceRate.replace("-", ""));
       		SearchRows.push(row);
     });
       $.getJSON('./json/Social.json', function successfulResponse(data) {

       $.each(data, function(i, f) {


			var row = new Row(f.fiscalYear,
       			f.fiscalMonth, 
       			"Social",
       			f.campaignName,
       			f.impressions,
       			f.clicks.replace("-", ""),
       			f.ctr.replace("-", ""),
       			f.cost.replace("-", ""),
       			f.visit.replace("-", ""),
       			f.totalOnlineOrders.replace("-", ""),
       			f.totalOnlineRevenue.replace("-", ""),
       			f.bounceRate.replace("-", ""));
       			SocialRows.push(row);

	     	});
			   	var ctx = $("#mycanvas").get(0).getContext("2d");		
				var data = graph_data_by_year(averageCost(SocialRows), averageCost(SearchRows),
					averageCost(DisplayRows), '2017 - 2018');
				var chart = new Chart(ctx).Doughnut(data);

				var ctx2 = $("#mycanvastwo").get(0).getContext("2d");		
				var data2 = graph_data_by_year(averageCostByYear(SocialRows, "2017"), averageCostByYear(SearchRows, "2017"),
					averageCostByYear(DisplayRows, "2017"), '2017');
				var chart = new Chart(ctx2).Doughnut(data2);

			   	var ctx3 = $("#mycanvasthree").get(0).getContext("2d");		
				var data3 = graph_data_by_year(averageCostByYear(SocialRows, "2018"), averageCostByYear(SearchRows, "2018"),
					averageCostByYear(DisplayRows, "2018"), '2018');
				var chart = new Chart(ctx3).Doughnut(data3);

	   		});
	   	});
	   });
	}
	getRows();
})

function averageCostByYear(channel, year) {
	var sum = 0.0;
	for (var i = 0; i < channel.length; i++) {
		if (channel[i].fiscalYear == year) {
			sum += parseFloat(channel[i].costs);
		}
	}
	return sum / channel.length;
}

function averageCost(channel) {
	var sum = 0.0;
	for (var i = 0; i < channel.length; i++) {
		sum += parseFloat(channel[i].costs);
	}
	console.log(sum);
	return sum / channel.length;
}

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
