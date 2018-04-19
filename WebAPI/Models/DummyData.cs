using BizHacks.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BizHacks.Models
{
    public class DummyData
    {
        public static void Initialize(ApiDbContext db)
        {
            Random rng = new Random();
            if (!db.Displays.Any())
            {
                using (var reader = new StreamReader("C:\\Users\\Phili\\Desktop\\WebApi\\Models\\data.csv"))
                {
                    var line = reader.ReadLine();
                    string[] row = line.Split(',');
                    //above two lines  read columns


                    var line2 = reader.ReadLine();
                    //start loop from here until eof
                    while (line2 != null)
                    {
                        string[] str = line2.Split(',');
                        string FisYear = str[0];
                        string FisMonth = str[1];
                        string CampName = str[3];

                        /*r.FiscalYear = str[0];
                        r.FiscalMonth = str[1];
                        r.Channel = str[2];
                        r.CampName = str[3];*/

                        //separates numbers
                        string[] data = line2.Split('\"');
                        string[] data1 = new string[9];
                        int count = 0;
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (data[i] == ",")
                                continue;
                            else
                            {
                                data1[count] = data[i];
                                data1[count] = string.Join("", data1[count].Split(',', '$', '%', ' '));
                                count++;
                            }
                        }
                        string data_1;
                        string data_2;
                        string data_3;
                        string data_4;
                        string data_5;
                        string data_6;
                        string data_7;
                        string data_8;

                        data_1 = data1[1];

                        if (data_1 == null)
                        {
                            data_1 = rng.Next(0, 10000000).ToString();
                        }

                        data_2 = data1[2];
                        //r.Clicks = data1[2];
                        if (data_2 == null)
                        {
                            data_2 = rng.Next(0, 50000).ToString();
                        }

                        data_3 = data1[3];

                        //r.CTR = data1[3];
                        if (data_3 == null)
                        {
                            data_3 = rng.Next(0, 1).ToString();
                        }

                        data_4 = data1[4];

                        //r.Costs = data1[4];
                        if (data_4 == null)
                        {
                            data_4 = rng.Next(0, 100000).ToString();
                        }

                        data_5 = data1[5];
                        //r.Visits = data1[5];
                        if (data_5 == null)
                        {
                            data_5 = rng.Next(0, 100000).ToString();
                        }

                        data_6 = data1[6];
                        //r.TotalOnlineOrders = data1[6];
                        if (data_6 == null)
                        {
                            data_6 = rng.Next(0, 30000).ToString();
                        }

                        data_7 = data1[7];
                        //r.TotalOnlineRevenue = data1[7];
                        if (data_7 == null)
                        {
                            data_7 = rng.Next(0, 200000).ToString();
                        }


                        data_8 = data1[8];
                        //r.BounceRate = data1[8];
                        if (data_8 == null)
                        {
                            data_8 = rng.Next(0, 80).ToString();
                        }

                        if (str[2] == "Display")
                        {
                            db.Displays.Add(new Display
                            {
                                CampaignName = CampName,
                                FiscalYear = FisYear,
                                FiscalMonth = FisMonth,
                                Impressions = data_1,
                                Clicks = data_2,
                                CTR = data_3,
                                Cost = data_4,
                                Visit = data_5,
                                TotalOnlineOrders = data_6,
                                TotalOnlineRevenue = data_7,
                                BounceRate = data_8
                            });
                        }
                        line2 = reader.ReadLine();
                    }
                }
            }

            if (!db.Socials.Any())
            {
                using (var reader = new StreamReader("C:\\Users\\Phili\\Desktop\\WebApi\\Models\\data.csv"))
                {
                    var line = reader.ReadLine();
                    string[] row = line.Split(',');
                    //above two lines  read columns


                    var line2 = reader.ReadLine();
                    //start loop from here until eof
                    while (line2 != null)
                    {
                        string[] str = line2.Split(',');
                        string FisYear = str[0];
                        string FisMonth = str[1];
                        string CampName = str[3];

                        /*r.FiscalYear = str[0];
                        r.FiscalMonth = str[1];
                        r.Channel = str[2];
                        r.CampName = str[3];*/

                        //separates numbers
                        string[] data = line2.Split('\"');
                        string[] data1 = new string[9];
                        int count = 0;
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (data[i] == ",")
                                continue;
                            else
                            {
                                data1[count] = data[i];
                                data1[count] = string.Join("", data1[count].Split(',', '$', '%', ' '));
                                count++;
                            }
                        }
                        string data_1;
                        string data_2;
                        string data_3;
                        string data_4;
                        string data_5;
                        string data_6;
                        string data_7;
                        string data_8;

                        data_1 = data1[1];

                        if (data_1 == null)
                        {
                            data_1 = rng.Next(0, 10000000).ToString();
                        }

                        data_2 = data1[2];
                        //r.Clicks = data1[2];
                        if (data_2 == null)
                        {
                            data_2 = rng.Next(0, 50000).ToString();
                        }

                        data_3 = data1[3];

                        //r.CTR = data1[3];
                        if (data_3 == null)
                        {
                            data_3 = rng.Next(0, 1).ToString();
                        }

                        data_4 = data1[4];

                        //r.Costs = data1[4];
                        if (data_4 == null)
                        {
                            data_4 = rng.Next(0, 100000).ToString();
                        }

                        data_5 = data1[5];
                        //r.Visits = data1[5];
                        if (data_5 == null)
                        {
                            data_5 = rng.Next(0, 100000).ToString();
                        }

                        data_6 = data1[6];
                        //r.TotalOnlineOrders = data1[6];
                        if (data_6 == null)
                        {
                            data_6 = rng.Next(0, 30000).ToString();
                        }

                        data_7 = data1[7];
                        //r.TotalOnlineRevenue = data1[7];
                        if (data_7 == null)
                        {
                            data_7 = rng.Next(0, 200000).ToString();
                        }


                        data_8 = data1[8];
                        //r.BounceRate = data1[8];
                        if (data_8 == null)
                        {
                            data_8 = rng.Next(0, 80).ToString();
                        }



                        if (str[2] == "Social")
                        {
                            db.Socials.Add(new Social
                            {
                                CampaignName = CampName,
                                FiscalYear = FisYear,
                                FiscalMonth = FisMonth,
                                Impressions = data_1,
                                Clicks = data_2,
                                CTR = data_3,
                                Cost = data_4,
                                Visit = data_5,
                                TotalOnlineOrders = data_6,
                                TotalOnlineRevenue = data_7,
                                BounceRate = data_8
                            });
                        }
                        line2 = reader.ReadLine();
                    }
                }
            }

            if (!db.Searches.Any())
            {
                using (var reader = new StreamReader("C:\\Users\\Phili\\Desktop\\WebApi\\Models\\data.csv"))
                {
                    var line = reader.ReadLine();
                    string[] row = line.Split(',');
                    //above two lines  read columns


                    var line2 = reader.ReadLine();
                    //start loop from here until eof
                    while (line2 != null)
                    {
                        string[] str = line2.Split(',');
                        string FisYear = str[0];
                        string FisMonth = str[1];
                        string CampName = str[3];

                        /*r.FiscalYear = str[0];
                        r.FiscalMonth = str[1];
                        r.Channel = str[2];
                        r.CampName = str[3];*/

                        //separates numbers
                        string[] data = line2.Split('\"');
                        string[] data1 = new string[9];
                        int count = 0;
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (data[i] == ",")
                                continue;
                            else
                            {
                                data1[count] = data[i];
                                data1[count] = string.Join("", data1[count].Split(',', '$', '%', ' '));
                                count++;
                            }
                        }
                        string data_1;
                        string data_2;
                        string data_3;
                        string data_4;
                        string data_5;
                        string data_6;
                        string data_7;
                        string data_8;

                        data_1 = data1[1];

                        if (data_1 == null)
                        {
                            data_1 = rng.Next(0, 10000000).ToString();
                        }

                        data_2 = data1[2];
                        //r.Clicks = data1[2];
                        if (data_2 == null)
                        {
                            data_2 = rng.Next(0, 50000).ToString();
                        }

                        data_3 = data1[3];

                        //r.CTR = data1[3];
                        if (data_3 == null)
                        {
                            data_3 = rng.Next(0, 1).ToString();
                        }

                        data_4 = data1[4];

                        //r.Costs = data1[4];
                        if (data_4 == null)
                        {
                            data_4 = rng.Next(0, 100000).ToString();
                        }

                        data_5 = data1[5];
                        //r.Visits = data1[5];
                        if (data_5 == null)
                        {
                            data_5 = rng.Next(0, 100000).ToString();
                        }

                        data_6 = data1[6];
                        //r.TotalOnlineOrders = data1[6];
                        if (data_6 == null)
                        {
                            data_6 = rng.Next(0, 30000).ToString();
                        }

                        data_7 = data1[7];
                        //r.TotalOnlineRevenue = data1[7];
                        if (data_7 == null)
                        {
                            data_7 = rng.Next(0, 200000).ToString();
                        }


                        data_8 = data1[8];
                        //r.BounceRate = data1[8];
                        if (data_8 == null)
                        {
                            data_8 = rng.Next(0, 80).ToString();
                        }



                        if (str[2] == "Search")
                        {
                            db.Searches.Add(new Search
                            {
                                CampaignName = CampName,
                                FiscalYear = FisYear,
                                FiscalMonth = FisMonth,
                                Impressions = data_1,
                                Clicks = data_2,
                                CTR = data_3,
                                Cost = data_4,
                                Visit = data_5,
                                TotalOnlineOrders = data_6,
                                TotalOnlineRevenue = data_7,
                                BounceRate = data_8
                            });
                        }
                        line2 = reader.ReadLine();
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
