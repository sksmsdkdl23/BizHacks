$(document).ready(function() {
	$(".dropdown-sub").click(function() {
		if (this.innerHTML == 'Social') {
		   	$("#userdata").find("tr:gt(0)").remove();
		   	clearTable();
       		addRow(SocialRows, "Social");
		}

		if (this.innerHTML == 'Display') {
			$("#userdata").find("tr:gt(0)").remove();
		   	clearTable();
		   	addRow(DisplayRows, "Display");
		}

		if (this.innerHTML == 'Paid search') {
		    $("#userdata").find("tr:gt(0)").remove();
		   	clearTable();
			addRow(SearchRows, "Paid search");
		}

		if (this.innerHTML == '2018') {
		   	clearTable();
       		addRow(SocialRows, "Social");
		   	addRow(DisplayRows, "Display");
			addRow(SearchRows, "Paid search");
			$("#userdata tr td:contains('2017')").each(function() {
				$(this).parent().remove();
			})
		}

		if (this.innerHTML == '2017') {
		   	clearTable();
       		addRow(SocialRows, "Social");
		   	addRow(DisplayRows, "Display");
			addRow(SearchRows, "Paid search");
			$("#userdata tr td:contains('2018')").each(function() {
				$(this).parent().remove();
			})
		}

		if (this.innerHTML == 'Dec') {
		   	clearTable();
       		addRow(SocialRows, "Social");
		   	addRow(DisplayRows, "Display");
			addRow(SearchRows, "Paid search");
			$("#userdata tr td:contains('nov')").each(function() {
				$(this).parent().remove();
			})
			$("#userdata tr td:contains('jan')").each(function() {
				$(this).parent().remove();
			})
		}

		if (this.innerHTML == 'Nov') {
		   	clearTable();
       		addRow(SocialRows, "Social");
		   	addRow(DisplayRows, "Display");
			addRow(SearchRows, "Paid search");
			$("#userdata tr td:contains('dec')").each(function() {
				$(this).parent().remove();
			})
			$("#userdata tr td:contains('jan')").each(function() {
				$(this).parent().remove();
			})
		}

		if (this.innerHTML == 'Jan') {
		   	clearTable();
       		addRow(SocialRows, "Social");
		   	addRow(DisplayRows, "Display");
			addRow(SearchRows, "Paid search");
			$("#userdata tr td:contains('nov')").each(function() {
				$(this).parent().remove();
			})
			$("#userdata tr td:contains('dec')").each(function() {
				$(this).parent().remove();
			})
		}

		if (this.innerHTML == 'Raw Table') {
			$('#userdata').css("display", "block");
			$('#chart-container').css("display", "none");
		}

		if (this.innerHTML == 'Pie Chart') {
			$('#userdata').css("display", "none");
			$('#chart-container').css("display", "block");
		}

	})
});

function addRow(channel, channelName) {
	for(var i = 0; i < channel.length; i++) {
		var tblRow = "<tr>" + "<td>" + channel[i].fiscalYear + "</td>";
		tblRow += "<td>" + channel[i].fiscalMonth + "</td>";
		tblRow += "<td>" + channelName + "</td>";
		tblRow += "<td>" + channel[i].campName + "</td>";
		tblRow += "<td>" + channel[i].impression + "</td>";
		tblRow += "<td>" + channel[i].clicks + "</td>";
		tblRow += "<td>" + channel[i].ctr + "</td>";
		tblRow += "<td>" + channel[i].costs + "</td>";
		tblRow += "<td>" + channel[i].visits + "</td>";
		tblRow += "<td>" + channel[i].totalOnlineOrders + "</td>";
		tblRow += "<td>" + channel[i].totalOnlineRevenue + "</td>";
		tblRow += "<td>" + channel[i].bounceRate + "</td>" + "</tr>";
		$(tblRow).appendTo("#userdata");		
	}
}

function clearTable() {
	$("#userdata").find("tr:gt(0)").remove();
}
