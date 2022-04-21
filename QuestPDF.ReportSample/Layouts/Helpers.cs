using System;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPDF.ReportSample.Layouts
{
    public static class Helpers
    {
        static IContainer Cell(this IContainer container, bool background)
        {
            return container
                .Border(0.5f)
                .BorderColor(Colors.Grey.Lighten1)
                .Background(background ? Colors.Grey.Lighten4 : Colors.White)
                .Padding(5);
        }
        
        public static IContainer ValueCell(this IContainer container)
        {
            return container.Cell(false);
        }
        
        public static IContainer LabelCell(this IContainer container)
        {
            return container.Cell(true);
        }
        
        public static string Format(this Location location)
        {
            if (location == null)
                return string.Empty;
            
            var lon = location.Longitude;
            var lat = location.Latitude;
            
            var typeLon = lon > 0 ? "E" : "W";
            lon = Math.Abs(lon);
            
            var typeLat = lat > 0 ? "N" : "S";
            lat = Math.Abs(lat);
            
            return $"{lat:F5}° {typeLat}   {lon:F5}° {typeLon}";
        }
    }
}