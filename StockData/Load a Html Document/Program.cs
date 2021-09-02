using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Load_a_Html_Document
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load("https://www.dse.com.bd/latest_share_price_scroll_l.php");

            //foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            //{
            //    HtmlAttribute att = link.Attributes["href"];

            //    if (att.Value.Contains("a"))
            //    {
            //        Console.WriteLine(link.ParentNode.ParentNode.Id);
            //    }

            //}


            var test = @"<table class='table table-bordered background-white shares-table fixedHeader'>

            			<thead>
            				<tr>
            					<th width=""4 % "">#</th>
            					<th width = :""12%"" > TRADING CODE</th >
            					<th width = ""12%"" > LTP *</ th >

            					< th width = ""12 %""> HIGH </ th >

            					< th width = ""12 %"" > LOW </ th >

            					< th width = ""12 %"" > CLOSEP *</ th >

            					< th width = ""12 %"" > YCP *</ th >

            					< th width = ""12 %"" > CHANGE </ th >

            					< th width = ""12 %"" > TRADE </ th >

            					< th width = ""12 %"" > VALUE(mn)</ th >


            					< th width = ""12 %"" > VOLUME </ th >

            				</ tr >

            			</ thead >

            			< tbody >

            				< tr >

            					<td width = ""4 %"" > 1 </ td >

            					<td width = ""15 %"" >
            						< a href = ""displayCompany.php?name=1JANATAMF"" class='ab1'> 1JANATAMF</a>
            					</td>
            					<td width = ""10 %"" > 9.2 </ td >
            					< td width=""10 %"" > 9.3</td>
            					<td width = ""12 %"" > 9.1 </ td >
            					< td width=""11 %"" > 0</td>
            					<td width = ""12 %"" > 9.2 </ td >
            					< td width=""12 %"" style =""color: blue"" > 0 </td>
            					<td width = ""11 %"" > 614 </ td >
            					< td width=""11 %"" > 43.907</td>
            					<td width = ""11 %"" > 4,775,652</td>

            				</tr>

            			</tbody>

            				<tr>
            					<td width = ""4 %"" > 2 </ td >
            					<td width=""15 %"" >
            						<a href = ""displayCompany.php?name=1STPRIMFMF""class='ab1'>1STPRIMFMF</a>													
            					</td>															
            					<td width = ""10 %"" > 20.4 </td>																
            					<td width=""10 %"" > 20.6</td>														
            					<td width = ""12 %"" > 20.2 </td>														
            					<td width=""11 %"" > 0</td>														
            					<td width = ""12 %"" > 20.5 </td>														
            					<td width=""12 %"" style =""color: red"" > -0.1</td>														
            					<td width = ""11 %"" > 69 </td>														
            					<td width=""11 %"" > 2.235</td>														
            					<td width = ""11 %"" > 109,843</td>														
            				</tr>
            		</tbody>
                            <tr>
            					<td width = ""4 %"" > 2 </ td >
            					<td width=""15 %"" >
            						<a href = ""displayCompany.php?name=1STPRIMFMF""class='ab1'>1STPRIMFMF------</a>													
            					</td>															
            					<td width = ""10 %"" > 20.4 </td>																
            					<td width=""10 %"" > 20.6</td>														
            					<td width = ""12 %"" > 20.2 </td>														
            					<td width=""11 %"" > 0</td>														
            					<td width = ""12 %"" > 20.5 </td>														
            					<td width=""12 %"" style =""color: red"" > -0.1</td>														
            					<td width = ""11 %"" > 69 </td>														
            					<td width=""11 %"" > 2.235</td>														
            					<td width = ""11 %"" > 109,843</td>														
            				</tr>
            		</tbody>
            </table>";

            #region MyRegion
            //var htmlDoc = new HtmlDocument();
            //htmlDoc.LoadHtml(test);



            //var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//a[@href]");

            //foreach (HtmlNode link in htmlNodes)
            //{
            //	HtmlAttribute att = link.Attributes["href"];

            //	if (att.Value.Contains("a") && att.Value.Contains("displayCompany.php?name"))
            //	{
            //		var Nodes = link.ParentNode.SelectSingleNode("//tr");
            //		var childNodes = Nodes.ChildNodes;
            //		foreach (var node in childNodes)
            //                 {

            //				Console.WriteLine(node.InnerText);
            //                 }

            //	}

            //} 
            #endregion

            #region MyRegion
            //HtmlDocument docs = new HtmlDocument();
            //docs.LoadHtml(@"<table id=""TC""><tr><th>Name</th></tr><tr><td>Techno</td></tr><tr><td>Crowds</td></tr></table>");

            //var htmlTableList = from table in doc.DocumentNode.SelectNodes("//table/tbody").Cast<HtmlNode>()
            //					from row in table.SelectNodes("tr").Cast<HtmlNode>()
            //					from cell in row.SelectNodes("td").Cast<HtmlNode>()
            //					select new { Table_Name = table.Id, Cell_Text = cell.InnerText };

            //foreach(var cell in htmlTableList)
            //             Console.WriteLine("{0}: {1}", cell.Table_Name, cell.Cell_Text); 
            #endregion

            //--------find the table with specific class name------------
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(test);
            var wholeTable = doc.DocumentNode.SelectNodes("//table[contains(@class, 'table table-bordered background-white shares-table fixedHeader')]");

            foreach(var table in wholeTable)
            {
                List<string> s = new List<string>();
                var htmlTableList = from row in table.SelectNodes("tr").Cast<HtmlNode>()
                                    from cell in row.SelectNodes("td").Cast<HtmlNode>()
                                    select new {  Type=cell.GetType(), Cell_Text = cell.InnerText };

                foreach(var cell in htmlTableList)
                {
                    s.Add(cell.Cell_Text.ToString());
                }

                int cnt = 0;
                List<string> temp = new List<string>();
                foreach (var i in s)
                {
                    cnt++;
                    temp.Add(i);

                    if(cnt==11)
                    {

                        cnt = 0;
                    }
                    Console.WriteLine(i);
;               }
            }



            //foreach(var table in wholeTable)
            //{
            //    var att = table.Se;

            //    foreach (var at in att)
            //    {
            //        if(first<=2)
            //        {
            //            first += 1;
            //            continue;
            //        }
            //        Console.WriteLine(at.InnerText);
            //    }

            //}

        }
    }
}
