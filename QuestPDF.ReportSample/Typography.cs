﻿using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPDF.ReportSample
{
    public static class Typography
    {
        public static TextStyle Title => TextStyle.Default.FontType(Fonts.Calibri).Color(Colors.Blue.Darken3).Size(26).Black();
        public static TextStyle Headline => TextStyle.Default.FontType(Fonts.Calibri).Color(Colors.Blue.Medium).Size(16).SemiBold();
        public static TextStyle Normal => TextStyle.Default.FontType(Fonts.Verdana).Color(Colors.Black).Size(10).LineHeight(1.2f);
    }
}