using ProgramZaRacunovodstvo.Models;
using ProgramZaRacunovodstvo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Ui.Input;
using ClosedXML.Excel;
using System.IO;
using ProgramZaRacunovodstvo.Views;
using Microsoft.Win32;


namespace ProgramZaRacunovodstvo.ViewModels
{
    internal class IzvodiViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseKomande _database = new DatabaseKomande();
        private System.Timers.Timer _timer;
        private int _trenutnaStranica = 1;
        private int _stavkiPoStranici = 9;
        private int _totalPages;
        private string _pretragaText = string.Empty;
        private ObservableCollection<Izvod> _originalIzvod = new();
        public ICommand Detalji { get; }
        public ICommand Izvod { get; }



        public string PretragaText
        {
            get => _pretragaText;
            set
            {
                if (_pretragaText != value)
                {
                    _pretragaText = value;
                    OnPropertyChanged(nameof(PretragaText));
                    _timer.Stop();
                    _timer.Start();
                }
            }
        }

        public int TotalPages
        {
            get => _totalPages;
            private set
            {
                if (_totalPages != value)
                {
                    _totalPages = value;
                    OnPropertyChanged(nameof(TotalPages));
                    OsveziStatusKomandi();
                }
            }
        }

        public int stavkiPoStranici
        {
            get => _stavkiPoStranici;
            set
            {
                if (_stavkiPoStranici != value)
                {
                    _stavkiPoStranici = value;
                    OnPropertyChanged(nameof(stavkiPoStranici));
                    OsveziStavke();
                }
            }
        }

        private ObservableCollection<Izvod> _pagedIzvodi = new();

        public ObservableCollection<Izvod> PagedIzvodi
        {
            get => _pagedIzvodi;
            set
            {
                _pagedIzvodi = value;
                OnPropertyChanged(nameof(PagedIzvodi));
            }
        }

        public ICommand PrethodnaStranica { get; }
        public ICommand SledecaStranica { get; }

        private DateTime? _date;

        public DateTime? Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    if (Date2.HasValue && value.HasValue && value > Date2)
                    {
                        _date = Date2;
                        Pretraga();
                    }
                    else
                    {
                        _date = value;
                        Pretraga();
                    }

                    OnPropertyChanged(nameof(Date));

                    if (Date2.HasValue && Date.HasValue && Date2 < Date)
                    {
                        Date2 = Date;
                        Pretraga();
                    }
                }
            }
        }

        private DateTime? _date2;


        public DateTime? Date2
        {
            get => _date2;
            set
            {
                if (_date2 != value)
                {
                    if (Date.HasValue && value.HasValue && value < Date)
                    {
                        _date2 = Date;
                        Pretraga();
                    }
                    else
                    {
                        _date2 = value;
                        Pretraga();
                    }

                    OnPropertyChanged(nameof(Date2));
                }
            }
        }


        private ObservableCollection<Izvod> _izvodi = new();

        public ObservableCollection<Izvod> Izvodi
        {
            get => _izvodi;
            set
            {
                _izvodi = value;
                OnPropertyChanged(nameof(Izvodi));
            }
        }

        public IzvodiViewModel()
        {
            PrethodnaStranica = new RelayCommand<object>(_ => PrethodnaStrana(), _ => _trenutnaStranica > 1);
            SledecaStranica = new RelayCommand<object>(_ => SledecaStrana(), _ => _trenutnaStranica < TotalPages);
            Detalji = new RelayCommand(DetaljiIzvod);
            Izvod = new RelayCommand(IzvozUExcel);
            ucitajPodatke();

            _timer = new System.Timers.Timer(300);
            _timer.AutoReset = false;
            _timer.Elapsed += (s, e) => Pretraga();


        }

        private void Pretraga()
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                var filter = _originalIzvod.AsEnumerable();

                if (!string.IsNullOrWhiteSpace(PretragaText))
                {
                    filter = filter.Where(n =>
                        (n.BrojFakture?.Contains(PretragaText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (n.TipFakture != null && n.TipFakture.StartsWith(PretragaText, StringComparison.OrdinalIgnoreCase)) ||
                        (n.PravnoLice?.Contains(PretragaText, StringComparison.OrdinalIgnoreCase) ?? false)

                    );
                }

                if (Date.HasValue)
                {
                    DateOnly startDate = DateOnly.FromDateTime(Date.Value);
                    filter = filter.Where(n => n.DatumSlanja >= startDate);
                }

                if (Date2.HasValue)
                {
                    DateOnly endDate = DateOnly.FromDateTime(Date2.Value);
                    filter = filter.Where(n => n.DatumSlanja <= endDate);
                }

                Izvodi = new ObservableCollection<Izvod>(filter);
                OsveziStavke();
            });
        }

        public void IzvozUExcel(object parameter)
        {
           
            if (Izvodi.Count > 0)
            {
                string formattedDate = string.Empty;

                if (Date.HasValue && !Date2.HasValue)
                {
                    formattedDate = DateOnly.FromDateTime(Date.Value).ToString("dd.MM.yyyy") + "-" + Izvodi.Max(i => i.DatumSlanja).ToString("dd.MM.yyyy");
                }
                else if (Date2.HasValue && !Date.HasValue)
                {
                    formattedDate = Izvodi.Min(i => i.DatumSlanja).ToString("dd.MM.yyyy") + "-" + DateOnly.FromDateTime(Date2.Value).ToString("dd.MM.yyyy");
                }
                else if (Date.HasValue && Date2.HasValue)
                {
                    formattedDate = DateOnly.FromDateTime(Date.Value).ToString("dd.MM.yyyy") + "-" + DateOnly.FromDateTime(Date2.Value).ToString("dd.MM.yyyy");
                }
                else
                {
                    formattedDate = Izvodi.Min(i => i.DatumSlanja).ToString("dd.MM.yyyy") + " - " + Izvodi.Max(i => i.DatumSlanja).ToString("dd.MM.yyyy");
                }

                string dynamicFilename = "Izvod " + formattedDate + ".xlsx";
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    FileName = dynamicFilename,
                    Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                };

                if (saveDialog.ShowDialog() == true)
                {
                    string outputPath = saveDialog.FileName;
                    string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Template", "Template.xlsx");

                    using (var stream = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
                    using (var workbook = new XLWorkbook(stream))
                    {
                        var worksheet = workbook.Worksheet(1);
                        decimal OsnovicaProdaja = 0;
                        decimal OsnovicaNabavke = 0;
                        decimal PDVProdaja = 0;
                        decimal PDVNabavke = 0;
                        decimal UkupnoProdaja = 0;
                        decimal UkupnoNabavke = 0;
                        decimal Promet = 0;
                        decimal PDVStanje = 0;
                        int startRow = 6;
                        int startCol = 2;
                        int endCol = 9;
                        int redniBroj = 1;

                        App.Current.Dispatcher.Invoke(() =>
                        {
                            foreach (var izvod in Izvodi)
                            {
                                worksheet.Row(startRow).InsertRowsAbove(1);

                                worksheet.Cell(startRow, 2).Value = redniBroj + ".";
                                worksheet.Cell(startRow, 3).Value = izvod.BrojFakture;
                                worksheet.Cell(startRow, 4).Value = izvod.TipFakture;
                                worksheet.Cell(startRow, 5).Value = izvod.PravnoLice;

                                worksheet.Cell(startRow, 6).Value = izvod.Osnovica;
                                worksheet.Cell(startRow, 6).Style.NumberFormat.Format = "#,##0.00";

                                worksheet.Cell(startRow, 7).Value = izvod.Pdv;
                                worksheet.Cell(startRow, 7).Style.NumberFormat.Format = "#,##0.00";

                                worksheet.Cell(startRow, 8).Value = izvod.Ukupno;
                                worksheet.Cell(startRow, 8).Style.NumberFormat.Format = "#,##0.00";

                                worksheet.Cell(startRow, 9).Value = izvod.DatumSlanja.ToString("dd.MM.yyyy.");
                                if (izvod.TipFakture == "Nabavka")
                                {
                                    OsnovicaNabavke += izvod.Osnovica;
                                    PDVNabavke += izvod.Pdv;
                                    UkupnoNabavke += izvod.Ukupno;
                                }
                                else
                                {
                                    OsnovicaProdaja += izvod.Osnovica;
                                    PDVProdaja += izvod.Pdv;
                                    UkupnoProdaja += izvod.Ukupno;
                                }

                                for (int col = startCol; col <= endCol; col++)
                                {
                                    worksheet.Cell(startRow, col).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                    worksheet.Cell(startRow, col).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                    worksheet.Cell(startRow, col).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                    worksheet.Cell(startRow, col).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                    worksheet.Cell(startRow, col).Style.Border.TopBorderColor = XLColor.Black;
                                    worksheet.Cell(startRow, col).Style.Border.BottomBorderColor = XLColor.Black;
                                    worksheet.Cell(startRow, col).Style.Border.LeftBorderColor = XLColor.Black;
                                    worksheet.Cell(startRow, col).Style.Border.RightBorderColor = XLColor.Black;
                                }

                                startRow++;
                                redniBroj++;
                            }

                            Promet = UkupnoProdaja - UkupnoNabavke;
                            PDVStanje = PDVNabavke - PDVProdaja;
                            int summaryRow = startRow + 1;
                            worksheet.Cell(summaryRow, 8).Value = OsnovicaProdaja;
                            worksheet.Cell(summaryRow, 8).Style.NumberFormat.Format = "#,##0.00";
                            worksheet.Cell(summaryRow + 2, 8).Value = PDVProdaja;
                            worksheet.Cell(summaryRow + 2, 8).Style.NumberFormat.Format = "#,##0.00";
                            worksheet.Cell(summaryRow + 4, 8).Value = UkupnoProdaja;
                            worksheet.Cell(summaryRow + 4, 8).Style.NumberFormat.Format = "#,##0.00";
                            worksheet.Cell(summaryRow + 7, 8).Value = OsnovicaNabavke;
                            worksheet.Cell(summaryRow + 7, 8).Style.NumberFormat.Format = "#,##0.00";
                            worksheet.Cell(summaryRow + 9, 8).Value = PDVNabavke;
                            worksheet.Cell(summaryRow + 9, 8).Style.NumberFormat.Format = "#,##0.00";
                            worksheet.Cell(summaryRow + 11, 8).Value = UkupnoNabavke;
                            worksheet.Cell(summaryRow + 11, 8).Style.NumberFormat.Format = "#,##0.00";
                            worksheet.Cell(summaryRow + 14, 8).Value = PDVStanje;
                            worksheet.Cell(summaryRow + 14, 8).Style.NumberFormat.Format = "#,##0.00";
                            worksheet.Cell(summaryRow + 17, 8).Value = Promet;
                            worksheet.Cell(summaryRow + 17, 8).Style.NumberFormat.Format = "#,##0.00";

                            if (Date.HasValue && !Date2.HasValue)
                            {
                                worksheet.Cell(2, 2).Value = "Izvod: " + DateOnly.FromDateTime(Date.Value) + " -  " + Izvodi.Max(i => i.DatumSlanja);
                            }
                            else if (Date2.HasValue && !Date.HasValue)
                            {
                                worksheet.Cell(2, 2).Value = "Izvod: " + Izvodi.Min(i => i.DatumSlanja) + " -  " + DateOnly.FromDateTime(Date2.Value);
                            }
                            else if (Date.HasValue && Date2.HasValue)
                            {
                                worksheet.Cell(2, 2).Value = "Izvod: " + DateOnly.FromDateTime(Date.Value) + " -  " + DateOnly.FromDateTime(Date2.Value);
                            }
                            else
                            {
                                worksheet.Cell(2, 2).Value = "Izvod: " + Izvodi.Min(i => i.DatumSlanja) + " - " + Izvodi.Max(i => i.DatumSlanja);
                            }

                            worksheet.Range(6, startCol, startRow - 1, endCol).Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                            worksheet.Range(6, startCol, startRow - 1, endCol).Style.Border.OutsideBorderColor = XLColor.Black;
                        });

                        workbook.SaveAs(outputPath);
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outputPath) { UseShellExecute = true });
                    }
                }
            }
            
        }

        private void DetaljiIzvod(object parameter)
        {
            if (parameter is Models.Izvod izvod && PagedIzvodi.Contains(izvod))
            {
                if(izvod.TipFakture == "Nabavka")
                {
                    Id.Instance.TipFakture = "Nabavka";
                }
                else
                {
                    Id.Instance.TipFakture = "Prodaja";
                }
                Id.Instance.FakturaId = izvod.Id;
                Navigation.Instance.NavigateTo(new Views.DetaljiFakture(Navigation.Instance.GetMainWindow()));
            }
        }

        private void OsveziStatusKomandi()
        {
            (PrethodnaStranica as RelayCommand<object>)?.NotifyCanExecuteChanged();
            (SledecaStranica as RelayCommand<object>)?.NotifyCanExecuteChanged();
        }

        private void ucitajPodatke()
        {
            _originalIzvod = new ObservableCollection<Izvod>(_database.Izvodi(Id.Instance.firmaid).OrderByDescending(n => n.Id));
            Izvodi = new ObservableCollection<Izvod>(_originalIzvod);

            OsveziStavke();

        }


        private void OsveziStavke()
        {

            TotalPages = (Izvodi.Count + stavkiPoStranici - 1) / stavkiPoStranici;

            if (_trenutnaStranica > TotalPages) _trenutnaStranica = TotalPages;

            PagedIzvodi = new ObservableCollection<Izvod>(
                Izvodi.Skip((_trenutnaStranica - 1) * stavkiPoStranici).Take(stavkiPoStranici)
            );

            OsveziStatusKomandi();

        }

        private void PrethodnaStrana()
        {
            if (_trenutnaStranica > 1)
            {
                _trenutnaStranica--;
                OsveziStavke();
                OsveziStatusKomandi();

            }
        }

        private void SledecaStrana()
        {
            if (_trenutnaStranica < TotalPages)
            {
                _trenutnaStranica++;
                OsveziStavke();
                OsveziStatusKomandi();

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
