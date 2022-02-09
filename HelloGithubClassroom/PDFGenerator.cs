using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;

namespace PDFGenerator
{
    class PDFGenerator
    {
        private readonly String pdfTitle = "Zmanim for 2021";
        private readonly IZmanimGetter zGetter;

        public PDFGenerator(IZmanimGetter zGetter)
        {
            this.zGetter = zGetter;
        }

        public void GeneratePDF()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            GenerateHeader(page, gfx);
            GenerateTableHeader(gfx);
            GenerateDatesAndZmanim(document, gfx);

            document.Save("C:\\Repos\\TestPDF.pdf");
        }

        private void GenerateHeader(PdfPage page, XGraphics gfx)
        {
            gfx.DrawString(this.pdfTitle, new XFont("Arial", 20, XFontStyle.Bold), XBrushes.Black, new XRect(-75, -350, page.Width, page.Height).Center);
        }

        private void GenerateTableHeader(XGraphics gfx)
        {
            int startXPoint = 50;

            gfx.DrawString("Sunrise", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(startXPoint, 80));
            gfx.DrawString("Sof Zman KSH", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(startXPoint += 50, 80));
            gfx.DrawString("Zman Tefillah", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(startXPoint += 70, 80));
            gfx.DrawString("Chatzot", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(startXPoint += 75, 80));
            gfx.DrawString("M'Gedola", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(startXPoint += 60, 80));
            gfx.DrawString("M'Ketana", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(startXPoint += 63, 80));
            gfx.DrawString("Plag", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(startXPoint += 72, 80));
            gfx.DrawString("Sunset", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(startXPoint += 60, 80));

            gfx.DrawLine(new XPen(XColor.FromArgb(0, 0, 0)), new XPoint(40, 85), new XPoint(startXPoint + 25, 85));

        }

        private void GenerateDatesAndZmanim(PdfDocument document, XGraphics gfx)
        {
            var date = new DateTime(2021, 1, 1);
            int yCord = 85;
            int yCordForLine = 92;
            int counter = 0;

            void ResetCoordinatesAndMakeANewPage(ref int counter, ref int yCord, ref int yCordForLine)
            {
                PdfPage nPage = document.AddPage();
                gfx = XGraphics.FromPdfPage(nPage);
                GenerateTableHeader(gfx);
                counter = 0;
                yCord = 85;
                yCordForLine = 92;
            }

            while (date.Year == 2021)
            {
                if (counter == 34)
                {
                    ResetCoordinatesAndMakeANewPage(ref counter, ref yCord, ref yCordForLine);
                }

                yCord += 20;
                yCordForLine += 20;

                gfx.DrawString($"{date.Month}/{date.Day}:", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(15, yCord));
                gfx.DrawLine(new XPen(XColor.FromArgb(0, 0, 0)), new XPoint(40, yCordForLine), new XPoint(525, yCordForLine));

                gfx.DrawString($"{zGetter.GetSunrise(date).ToShortTimeString()}", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(45, yCord));
                gfx.DrawString($"{zGetter.GetSofShema(date).ToShortTimeString()}", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(110, yCord));
                gfx.DrawString($"{zGetter.GetZmanTefillah(date).ToShortTimeString()}", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(175, yCord));
                gfx.DrawString($"{zGetter.GetChatzot(date).ToShortTimeString()}", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(240, yCord));
                gfx.DrawString($"{zGetter.GetMGedolah(date).ToShortTimeString()}", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(305, yCord));
                gfx.DrawString($"{zGetter.GetMKetana(date).ToShortTimeString()}", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(370, yCord));
                gfx.DrawString($"{zGetter.GetPlag(date).ToShortTimeString()}", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(435, yCord));
                gfx.DrawString($"{zGetter.GetSunset(date).ToShortTimeString()}", new XFont("Arial", 7, XFontStyle.Regular), XBrushes.Black, new XPoint(500, yCord));

                date = date.AddDays(1);
                counter++;
            }
        }

        static void Main(string[] args)
        {
            PDFGenerator generator = new PDFGenerator(new ZmanimMock());
            generator.GeneratePDF();
        }
    }
}
