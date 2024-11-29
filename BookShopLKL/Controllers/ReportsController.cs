using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BookShopLKL.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StocksReport()
        {
            try
            {
                string connectionString = @"Data Source=LAPTOP-4TDM0UV2\SQL2022;Initial Catalog=BookShopLKL;Integrated Security=True;integrated security=True;trustservercertificate=True;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Products p INNER JOIN Categories c ON c.CategoryID = p.CategoryID INNER JOIN Suppliers s ON s.SupplierID = p.SupplierID", con);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Products");

                    // Create PDF Document
                    MemoryStream stream = new MemoryStream();
                    Document document = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);
                    document.Open();

                    // Add report title
                    document.Add(new Paragraph("Stock Report", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK)));
                    document.Add(new Paragraph(" "));

                    // Create a table to hold data
                    PdfPTable table = new PdfPTable(ds.Tables["Products"].Columns.Count);
                    table.WidthPercentage = 100; // Make the table fill the page width
                    table.DefaultCell.BorderWidth = 1; // Add borders to cells

                    // Add column headers with styling
                    foreach (DataColumn column in ds.Tables["Products"].Columns)
                    {
                        PdfPCell headerCell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE)));
                        headerCell.BackgroundColor = BaseColor.DARK_GRAY; // Header background color
                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(headerCell);
                    }

                    // Add data rows with alternate row coloring
                    bool alternate = false;
                    foreach (DataRow row in ds.Tables["Products"].Rows)
                    {
                        foreach (var cell in row.ItemArray)
                        {
                            PdfPCell dataCell = new PdfPCell(new Phrase(cell.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                            dataCell.BorderWidth = 1;
                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER;

                            // Alternate row coloring for better readability
                            if (alternate)
                                dataCell.BackgroundColor = new BaseColor(230, 230, 230); // Light gray
                            else
                                dataCell.BackgroundColor = BaseColor.WHITE;

                            table.AddCell(dataCell);
                        }
                        alternate = !alternate; // Toggle the color for the next row
                    }

                    document.Add(table);
                    document.Close();

                    return File(stream.ToArray(), "application/pdf", "StocksReport.pdf");
                }
            }
            catch (Exception ex)
            {
                return Content("<h2>Error: " + ex.Message + "</h2>", "text/html");
            }
        }

        public ActionResult CustomersReport()
        {
            try
            {
                string connectionString = @"Data Source=LAPTOP-4TDM0UV2\SQL2022;Initial Catalog=BookShopLKL;Integrated Security=True;integrated security=True;trustservercertificate=True;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Customers", con);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Customers");

                    // Create PDF Document
                    MemoryStream stream = new MemoryStream();
                    Document document = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);
                    document.Open();

                    // Add report title
                    document.Add(new Paragraph("Customers Report", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK)));
                    document.Add(new Paragraph(" "));

                    // Create a table to hold data
                    PdfPTable table = new PdfPTable(ds.Tables["Customers"].Columns.Count);
                    table.WidthPercentage = 100;
                    table.DefaultCell.BorderWidth = 1;

                    // Add column headers with styling
                    foreach (DataColumn column in ds.Tables["Customers"].Columns)
                    {
                        PdfPCell headerCell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE)));
                        headerCell.BackgroundColor = BaseColor.DARK_GRAY;
                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(headerCell);
                    }

                    // Add data rows with alternate row coloring
                    bool alternate = false;
                    foreach (DataRow row in ds.Tables["Customers"].Rows)
                    {
                        foreach (var cell in row.ItemArray)
                        {
                            PdfPCell dataCell = new PdfPCell(new Phrase(cell.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                            dataCell.BorderWidth = 1;
                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER;

                            // Alternate row coloring
                            if (alternate)
                                dataCell.BackgroundColor = new BaseColor(230, 230, 230); // Light gray
                            else
                                dataCell.BackgroundColor = BaseColor.WHITE;

                            table.AddCell(dataCell);
                        }
                        alternate = !alternate;
                    }

                    document.Add(table);
                    document.Close();

                    return File(stream.ToArray(), "application/pdf", "CustomersReport.pdf");
                }
            }
            catch (Exception ex)
            {
                return Content("<h2>Error: " + ex.Message + "</h2>", "text/html");
            }
        }

        public ActionResult SalesReport()
        {
            try
            {
                string connectionString = @"Data Source=LAPTOP-4TDM0UV2\SQL2022;Initial Catalog=BookShopLKL;Integrated Security=True;integrated security=True;trustservercertificate=True;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM OrderDetails od INNER JOIN Orders o ON o.OrderID = od.OrderID INNER JOIN Products p ON p.ProductID = od.ProductID", con);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Sales");

                    // Create PDF Document
                    MemoryStream stream = new MemoryStream();
                    Document document = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);
                    document.Open();

                    // Add report title
                    document.Add(new Paragraph("Sales Report", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK)));
                    document.Add(new Paragraph(" "));

                    // Create a table to hold data
                    PdfPTable table = new PdfPTable(ds.Tables["Sales"].Columns.Count);
                    table.WidthPercentage = 100;
                    table.DefaultCell.BorderWidth = 1;

                    // Add column headers with styling
                    foreach (DataColumn column in ds.Tables["Sales"].Columns)
                    {
                        PdfPCell headerCell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE)));
                        headerCell.BackgroundColor = BaseColor.DARK_GRAY;
                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(headerCell);
                    }

                    // Add data rows with alternate row coloring
                    bool alternate = false;
                    foreach (DataRow row in ds.Tables["Sales"].Rows)
                    {
                        foreach (var cell in row.ItemArray)
                        {
                            PdfPCell dataCell = new PdfPCell(new Phrase(cell.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                            dataCell.BorderWidth = 1;
                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER;

                            // Alternate row coloring
                            if (alternate)
                                dataCell.BackgroundColor = new BaseColor(230, 230, 230); // Light gray
                            else
                                dataCell.BackgroundColor = BaseColor.WHITE;

                            table.AddCell(dataCell);
                        }
                        alternate = !alternate;
                    }

                    document.Add(table);
                    document.Close();

                    return File(stream.ToArray(), "application/pdf", "SalesReport.pdf");
                }
            }
            catch (Exception ex)
            {
                return Content("<h2>Error: " + ex.Message + "</h2>", "text/html");
            }
        }
    }
}
