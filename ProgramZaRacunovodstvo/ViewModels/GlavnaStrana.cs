using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Globalization;
using System.IO;
using HarfBuzzSharp;
using ProgramZaRacunovodstvo.ViewModel;

namespace ProgramZaRacunovodstvo.ViewModels
{
    internal class GlavnaStrana
    {

        private static readonly CultureInfo culture = new("sr-RS");

        private static readonly SKTypeface customFont;

        static GlavnaStrana()
        {
            try
            {
                string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts", "Poppins-Light.ttf");
                customFont = SKTypeface.FromFile(fontPath);
                if (customFont == null)
                {

                    System.Diagnostics.Debug.WriteLine($"Error: Font file not found at {fontPath}");
                    customFont = SKTypeface.Default;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading font: {ex.Message}");
                customFont = SKTypeface.Default;
            }
        }
        public IEnumerable<ISeries> PrihodiRashodi { get; set; } =
        [
            new PieSeries<double>
            {
                Values = new[] { 4000000.75 },
                Name = "Prihodi",
                DataLabelsSize = 16,
                DataLabelsPaint = new SolidColorPaint
                {
                    SKTypeface = customFont,
                    Color = SKColors.White
                },
                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                DataLabelsFormatter = value => value.Model.ToString("#,0.00", culture)
            },
            new PieSeries<double>
            {
                Values = new[] { 1500000.50 },
                Name = "Rashodi",
                DataLabelsSize = 16,
                DataLabelsPaint = new SolidColorPaint
                {
                    SKTypeface = customFont,
                    Color = SKColors.White
                },
                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                DataLabelsFormatter = value => value.Model.ToString("#,0.00", culture)
            }
        ];

        public LabelVisual PrihodiRashodiNaslov { get; set; } =
            new LabelVisual
            {

                Text = "Prihodi i rashodi za " + DateTime.Now.ToString("MMMM"),
                TextSize = 25,
                Padding = new LiveChartsCore.Drawing.Padding(15),
                Paint = new SolidColorPaint
                {
                    SKTypeface = customFont,
                    Color = SKColors.Black
                }
            };
        public LabelVisual DobavljaciNaslov { get; set; } =
           new LabelVisual
           {

               Text = "Najveći dobavljači za " + DateTime.Now.ToString("MMMM"),
               TextSize = 25,
               Padding = new LiveChartsCore.Drawing.Padding(15),
               Paint = new SolidColorPaint
               {
                   SKTypeface = customFont,
                   Color = SKColors.Black
               }
           };

        public LabelVisual KlijentiNaslov { get; set; } =
           new LabelVisual
           {

               Text = "Najveći klijenti za " + DateTime.Now.ToString("MMMM"),
               TextSize = 25,
               Padding = new LiveChartsCore.Drawing.Padding(15),
               Paint = new SolidColorPaint
               {
                   SKTypeface = customFont,
                   Color = SKColors.Black
               }
           };

        public LabelVisual PrihodiRashodiVise { get; set; } =
           new LabelVisual
           {

               Text = "Prihodi i rashodi za prethodnih 6 meseci",
               TextSize = 25,
               Padding = new LiveChartsCore.Drawing.Padding(15),
               Paint = new SolidColorPaint
               {
                   SKTypeface = customFont,
                   Color = SKColors.Black
               }
           };
    }
}