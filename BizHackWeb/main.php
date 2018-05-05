<html>
 <head>
  <title>PHP Test</title>
  <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">
  <link rel="stylesheet" type="text/css" href="css/image.css">
  <link rel="stylesheet" type="text/css" href="css/body.css">
  <link href="https://fonts.googleapis.com/css?family=Indie+Flower" rel="stylesheet">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script type='text/javascript' src='js/json.js'></script>
  <script type='text/javascript' src='js/bootstrap.min.js'></script>
  <script type='text/javascript' src='js/masonry.pkgd.min.js'></script>
  <script type='text/javascript' src='js/masonryImage.js'></script>
  <script type='text/javascript' src='js/functions.js'></script>
  <script type='text/javascript' src='js/sample.js'></script>
  <script src="js/chart.js"></script>
 </head>
 <body>
  <div id="header">
    <section id="header-section">
      <div class="container">
          <div class="dropdown">
            Period View
            <div class="dropdown-content">
              <div class="dropdown-content-header">Year</div>              
              <div class="dropdown-sub">2018</div>
              <div class="dropdown-sub">2017</div>
              <div class="dropdown-content-header border-top">Month</div>
              <div class="dropdown-sub">Dec</div>
              <div class="dropdown-sub">Nov</div>
              <div class="dropdown-sub">Jan</div>
            </div>
          </div>
          <div class="dropdown">
            Channels View
            <div class="dropdown-content">
              <div class="dropdown-sub">Social</div>
              <div class="dropdown-sub">Display</div>
              <div class="dropdown-sub">Paid search</div>
            </div>
          </div>
          <div class="dropdown">
            Mode
            <div class="dropdown-content">
              <div class="dropdown-sub">Raw Table</div>
              <div class="dropdown-sub">Pie Chart</div>
            </div>
          </div>
      </div>
    </section>
  </div>

  <div id="main">
    <section id="main-section">
    </section>
  </div>

  <div class="wrapper">
    <div class="profile">
     <table id= "userdata" border="1">
      <tr>
        <th>Fiscal Year</th>
        <th>Fiscal Month</th>
        <th>Channel</th>
        <th>Campaign Name</th>
        <th>Impression</th>
        <th>Clicks</th>
        <th>Ctr</th>
        <th>Costs</th>
        <th>Visits</th>
        <th>totalOnlineRevenue</th>
        <th>totalOnlineOrders</th>
        <th>BounceRate</th>
      </tr>
     </table>
     <div id="chart-container">
        <div>
          <canvas class="pie-charts" id="mycanvas" width="255" height="255"></canvas>
          <canvas class="pie-charts" id="mycanvastwo" width="255" height="255"></canvas>
          <canvas class="pie-charts" id="mycanvasthree" width="255" height="255"></canvas>
        </div>
        <div class="left" style="padding: 0px 55px">2018 and 2017</div><div class="left" style="padding: 0px 145px">2017</div><div class="left" style="padding-left: 80px">2018</div>
     </div>

  </div>

 </body>
</html>