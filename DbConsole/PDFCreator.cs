using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace PDFCreator
{
    public delegate void AfterAddPage_Handle();
    public class PDFCreator
    {
        public PDFCreator()
        {
            document = new PdfDocument();
            styles = new List<PDFStyle>();
        }

        PdfDocument document { get; set; }
        PdfPage page { get; set; }
        XGraphics graph { get; set; }
        PDFMargin margin { get; set; }
        List<PDFStyle> styles { get; set; }
        PDFCursor cursor { get; set; }
        int pageNumber { get; set; }
        const double POINT = 28.3465;
        const double PADDING = 4;
        public AfterAddPage_Handle AfterAddPage { get; set; }


        #region Private
        private PDFStyle getStyle(string StyleName)
        {
            foreach (var item in styles)
            {
                if (item.StyleName == StyleName)
                {
                    return item;
                }
            }

            return null;
        }

        private double getLineWidth(int col)
        {
            double col_size = (page.Width.Point - margin.Left - margin.Right) / 12;
            return col_size * col;
        }

        private double getCursorPosition(int ColumnNumber)
        {
            double col_size = (page.Width.Point - margin.Left - margin.Right) / 12;
            return margin.Left + ((ColumnNumber - 1) * col_size);
        }

        private bool OutOfPage(double ElementZise)
        {
            if (page == null)
            {
                return true;
            }

            return (cursor.Y + ElementZise) > (page.Height.Point - margin.Bottom);
        }

        private double getLineHeight(List<PDFColumn> Columns)
        {
            double line_height = 0;

            foreach (var item in Columns)
            {
                PDFStyle sty = getStyle(item.StyleName);
                if (sty.LineHeight > line_height)
                { line_height = sty.LineHeight; }
            }
            return line_height;
        }
        #endregion

        public void AddPage()
        {
            //Next step is to create a an Empty page.
            page = document.AddPage();

            //Then create an XGraphics Object
            graph = XGraphics.FromPdfPage(page);

            //create cursor
            cursor = new PDFCursor();
            cursor.Y = margin.Top;

            //Adiciona o número da página no rodapé
            pageNumber++;
            graph.DrawString(pageNumber.ToString(),
                new XFont("sans-serif", 10, XFontStyle.Regular),
                XBrushes.Black,
                new XRect(page.Width.Point - (margin.Right - PADDING), page.Height.Point - (margin.Bottom - PADDING), page.Width.Point, page.Height.Point),
                XStringFormats.TopLeft);

            if (AfterAddPage != null)
            {
                AfterAddPage();
            }
        }

        public void ConfigurePage(int TopCentimeter, int LeftCentimeter, int BottomCentimeter, int RightCentimeter)
        {
            margin = new PDFMargin();
            margin.Top = (int)((double)TopCentimeter * POINT);
            margin.Left = (int)((double)LeftCentimeter * POINT);
            margin.Bottom = (int)((double)BottomCentimeter * POINT);
            margin.Right = (int)((double)RightCentimeter * POINT);
        }

        public void AddStyle(string StyleName, string FontName, int FontZise)
        {
            AddStyle(StyleName, FontName, FontZise, false, false, false, (int)((double)FontZise / 0.6), 0, null);
        }

        public void AddStyle(string StyleName, string FontName, int FontZise, bool Bold, bool Italic, bool Center, PDFColumnBorder Borders) 
        {
            AddStyle(StyleName, FontName, FontZise, Bold, Italic, Center, (int)((double)FontZise / 0.6), 0, Borders);
        }

        public void AddStyle(string StyleName, string FontName, int FontZise, bool Bold, bool Italic, bool Center, int LineHeight, int LineSpacing, PDFColumnBorder Borders)
        {
            XFontStyle xfs = XFontStyle.Regular;
            if (Bold && Italic)
            {
                xfs = XFontStyle.BoldItalic;
            }
            else
            {
                if (Bold)
                {
                    xfs = XFontStyle.Bold;
                }

                if (Italic)
                {
                    xfs = XFontStyle.Italic;
                }
            }

            styles.Add(new PDFStyle()
            {
                StyleName = StyleName,
                Font = new XFont(FontName, FontZise, xfs),
                LineHeight = LineHeight,
                LineSpacing = LineSpacing,
                Center = Center,
                Borders = Borders
            });
        }

        public void Row(string StyleName, string Text)
        {
            Row(new List<PDFColumn>() { new PDFColumn() { StyleName = StyleName, Text = Text, ColumnNumber = 1, ColumnSize = 12 } });
        }


        public void Row(List<PDFColumn> Columns)
        {
            double line_height = getLineHeight(Columns);
            if (OutOfPage(line_height))
            {
                AddPage();
            }

            foreach (var item in Columns)
            {
                double line_width = getLineWidth(item.ColumnSize);
                double cursorX = getCursorPosition(item.ColumnNumber);
                PDFStyle sty = getStyle(item.StyleName);

                if (sty.LineSpacing > 0)
                {
                    cursor.Y += sty.LineSpacing;
                }

                // Borders
                if (sty.Borders != null)
                {
                    XPen pen = new XPen(XColors.Black, 0);

                    if (sty.Borders.Top)
                    { graph.DrawLine(pen, new XPoint(cursorX, cursor.Y), new XPoint(cursorX + line_width, cursor.Y)); }

                    if (sty.Borders.Left)
                    { graph.DrawLine(pen, new XPoint(cursorX, cursor.Y), new XPoint(cursorX, cursor.Y + sty.LineHeight)); }

                    if (sty.Borders.Bottom)
                    { graph.DrawLine(pen, new XPoint(cursorX, cursor.Y + sty.LineHeight), new XPoint(cursorX + line_width, cursor.Y + sty.LineHeight)); }

                    if (sty.Borders.Right)
                    { graph.DrawLine(pen, new XPoint(cursorX + line_width, cursor.Y), new XPoint(cursorX + line_width, cursor.Y + sty.LineHeight)); }

                }

                graph.DrawString(
                    item.Text,
                    sty.Font,
                    XBrushes.Black,
                    new XRect(cursorX + PADDING, cursor.Y + PADDING, line_width - PADDING * 2, sty.LineHeight - PADDING * 2),
                    sty.Center ? XStringFormats.TopCenter : XStringFormats.TopLeft);
            }

            cursor.Y += (int)line_height;
        }


        public void Save(string FileName)
        {
            document.Save(FileName);
        }

        public void Show(string FileName)
        {
            System.Diagnostics.Process.Start(FileName);
        }
    }

    public class PDFStyle
    {
        public string StyleName { get; set; }
        public XFont Font { get; set; }
        public int LineHeight { get; set; }
        public int LineSpacing { get; set; }
        public bool Center { get; set; }
        public PDFColumnBorder Borders { get; set; }
    }

    public class PDFMargin
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Bottom { get; set; }
        public int Right { get; set; }
    }

    public class PDFCursor
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class PDFColumn
    {
        public string StyleName { get; set; }
        public string Text { get; set; }
        public int ColumnNumber { get; set; }
        public int ColumnSize { get; set; }
    }

    public class PDFColumnBorder
    {
        public bool Top { get; set; }
        public bool Left { get; set; }
        public bool Bottom { get; set; }
        public bool Right { get; set; }
    }
}
