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
using ProgramZaRacunovodstvo.Services;
using System.Diagnostics.Eventing.Reader;
using System.Net.Sockets;
using PdfSharp.Charting;

namespace ProgramZaRacunovodstvo.ViewModels
{
    internal class GlavnaStrana
    {

        private static readonly CultureInfo culture = new("sr-RS");

        private static readonly SKTypeface customFont;

        private decimal prihodi = 0;
        private decimal rashodi = 0;
        public decimal stanje { get; set; }
        public int UlazneFakture { get; set; }
        public int IzlazneFakture { get; set; }
        public List<ISeries> KlijentiSeries { get; set; }
        public List<LiveChartsCore.SkiaSharpView.Axis> KlijentiXAxes { get; set; }
        public List<LiveChartsCore.SkiaSharpView.Axis> KlijentiYAxes { get; set; }
        public List<ISeries> DobavljaciSeries { get; set; }
        public List<LiveChartsCore.SkiaSharpView.Axis> DobavljaciXAxes { get; set; }
        public List<LiveChartsCore.SkiaSharpView.Axis> DobavljaciYAxes { get; set; }
        public List<LiveChartsCore.SkiaSharpView.Axis> PrihodiRashodiYAxes { get; set; }
        public List<ISeries> PrihodiRashodiMesec { get; set; }
        public List<LiveChartsCore.SkiaSharpView.Axis> PrihodiRashodiXAxes { get; set; }


        private readonly DatabaseKomande _database = new();
        public string StanjeFormatted => stanje.ToString("#,0.00", culture) + " RSD";




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

        public GlavnaStrana()
        {
            

            int firmaId = Id.Instance.firmaid;
            rashodi = _database.Rashodi(firmaId);
            prihodi = _database.Prihodi(firmaId);
            stanje = prihodi - rashodi;
            UlazneFakture = _database.BrojUlaznihFaktura(firmaId);
            IzlazneFakture = _database.BrojIzlaznihFaktura(firmaId);
            var topKlijenti = _database.Top10Klijenti(firmaId);
            var topDobavljaci = _database.Top10Dobavljaci(firmaId);
            var (prihodi1, rashodi1, meseci) = _database.PrihodiRashodi(Id.Instance.firmaid);

            PrihodiRashodiXAxes = new List<LiveChartsCore.SkiaSharpView.Axis>
            {
                new LiveChartsCore.SkiaSharpView.Axis
                {
                    Labels = meseci,
                    LabelsRotation = 0,
                    TextSize = 14,
                    NamePaint = new SolidColorPaint { Color = SKColors.Black }
                }
            };
            PrihodiRashodiYAxes = new List<LiveChartsCore.SkiaSharpView.Axis>
            {
                new LiveChartsCore.SkiaSharpView.Axis
                {
                    Labeler = value => FormatLargeNumbers(value),
                    TextSize = 14,
                    Name = "Ukupno (RSD)",
                    NamePaint = new SolidColorPaint { Color = SKColors.Black }
                }
            };
            PrihodiRashodiMesec = new List<ISeries> {
                new ColumnSeries<decimal>
                {
                    Values = prihodi1,
                    Stroke = null,
                    MaxBarWidth = 40,
                    IgnoresBarPosition = true
                },
                new ColumnSeries<decimal>
                {
                    Values = rashodi1,
                    Stroke = null,
                    MaxBarWidth = 30,
                    IgnoresBarPosition = true
                }
             };

            KlijentiXAxes = new List<LiveChartsCore.SkiaSharpView.Axis>
            {
                new LiveChartsCore.SkiaSharpView.Axis
                {
                    Labels = topKlijenti.Select(k => k.Klijent).ToList(),
                    LabelsRotation = 0,
                    TextSize = 14,
                    NamePaint = new SolidColorPaint { Color = SKColors.Black }
                }
            };

            KlijentiYAxes = new List<LiveChartsCore.SkiaSharpView.Axis>
            {
                new LiveChartsCore.SkiaSharpView.Axis
                {
                    Labeler = value => FormatLargeNumbers(value),
                    TextSize = 14,
                    Name = "Ukupno (RSD)",
                    NamePaint = new SolidColorPaint { Color = SKColors.Black }
                }
            };

            KlijentiSeries = new List<ISeries>
            {
                new ColumnSeries<double>
                {
                    Values = topKlijenti.Select(k => (double)k.Ukupno).ToArray(),
                    Name = "Prihodi po klijentu",
                    DataLabelsPaint = new SolidColorPaint { Color = SKColors.Black },
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    DataLabelsFormatter = value => FormatLargeNumbers(value.Model)

                }
            };

            DobavljaciXAxes = new List<LiveChartsCore.SkiaSharpView.Axis>
            {
                new LiveChartsCore.SkiaSharpView.Axis
                {
                    Labels = topDobavljaci.Select(k => k.Dobavljac).ToList(),
                    LabelsRotation = 0,
                    TextSize = 14,
                    NamePaint = new SolidColorPaint { Color = SKColors.Black }
                }
            };

            DobavljaciYAxes = new List<LiveChartsCore.SkiaSharpView.Axis>
            {
                new LiveChartsCore.SkiaSharpView.Axis
                {
                    Labeler = value => FormatLargeNumbers(value),
                    TextSize = 14,
                    Name = "Ukupno (RSD)",
                    NamePaint = new SolidColorPaint { Color = SKColors.Black }
                }
            };

            DobavljaciSeries = new List<ISeries>
            {
                new ColumnSeries<double>
                {
                    Values = topDobavljaci.Select(k => (double)k.Ukupno).ToArray(),
                    Name = "Prihodi po klijentu",
                    DataLabelsPaint = new SolidColorPaint { Color = SKColors.Black },
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    DataLabelsFormatter = value => FormatLargeNumbers(value.Model)

                }
            };

            PrihodiRashodi = new List<ISeries>
            {
                new PieSeries<double>
                {
                    Values = new[] { (double)prihodi },
                    Name = "Prihodi",
                    DataLabelsSize = 16,
                    DataLabelsPaint = new SolidColorPaint { SKTypeface = customFont, Color = SKColors.White },
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter = value => value.Model.ToString("#,0.00", culture) + " RSD"
                },
                new PieSeries<double>
                {
                    Values = new[] { (double)rashodi },
                    Name = "Rashodi",
                    DataLabelsSize = 16,
                    DataLabelsPaint = new SolidColorPaint { SKTypeface = customFont, Color = SKColors.White },
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter = value => value.Model.ToString("#,0.00", culture) + " RSD"
                }
            };
        }
        public IEnumerable<ISeries> PrihodiRashodi { get; set; }


        public LabelVisual PrihodiRashodiNaslov { get; set; } =
            new LabelVisual
            {

                Text = "Prihodi i rashodi za " + DateTime.Now.ToString("MMMM", new CultureInfo("sr-Latn-RS")),
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

               Text = "Najveći dobavljači za " + DateTime.Now.ToString("MMMM", new CultureInfo("sr-Latn-RS")),
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

               Text = "Najveći klijenti za " + DateTime.Now.ToString("MMMM", new CultureInfo("sr-Latn-RS")),
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

               Text = "Prihodi i rashodi za prethodnih 12 meseci",
               TextSize = 25,
               Padding = new LiveChartsCore.Drawing.Padding(15),
               Paint = new SolidColorPaint
               {
                   SKTypeface = customFont,
                   Color = SKColors.Black
               }
           };

        private static string FormatLargeNumbers(double value)
        {
            if (value >= 1_000_000_000) return (value / 1_000_000_000).ToString("0.##") + "B";
            if (value >= 1_000_000) return (value / 1_000_000).ToString("0.##") + "M";
            if (value >= 1_000) return (value / 1_000).ToString("0.##") + "K";
            return value.ToString("N0");
        }
    }
}