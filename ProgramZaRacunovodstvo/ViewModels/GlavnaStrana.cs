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
            rashodi = _database.Rashodi(Id.Instance.firmaid);
            prihodi = _database.Prihodi(Id.Instance.firmaid);
            stanje = prihodi-rashodi;

            int firmaId = Id.Instance.firmaid;
            UlazneFakture = _database.BrojUlaznihFaktura(firmaId);
            IzlazneFakture = _database.BrojIzlaznihFaktura(firmaId);

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