   M S B A M L   `   `   `  ���� Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ProgramZaRacunovodstvo.ViewModels!ProgramZaRacunovodstvo.ViewModels  1    +ProgramZaRacunovodstvo.Views.KreirajNabavku   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  ;local/clr-namespace:ProgramZaRacunovodstvo.ViewModels    � 	Resources  6  0ProgramZaRacunovodstvo.ViewModels.DatumConverter   DatumConverter��%   &	          .���� $
��Auto=�.��� 
������� � RowDefinitions �� $	��100 ��� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $��* �.+��� $��Kreiraj nabavku��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��28(�$��
20,40,0,20q�$	��759��$
��Left=�$	��Top=�  Wpf.Ui.Controls.TextBox  $��1��$��40��$	��220��$
��Left=�$	��Top=�$��20q�   PlaceholderText$ Broj fakture������ *BrojFakture+�� 
�������$��1q�$��40��$	��220�� �� CornerRadius$ 10�� �� Padding$ 5q�$
��Left=�$	��Top=�$��1��$��	20,70,0,0q�._��  �� $
��Auto ��� $��* �.+��� -   $��DatumTextbox��$��Center=�$
��Left=�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��12(�$��0,2,5,0q�$��0������ *Date+ �� StringFormat$ {0:d}�� �� FallbackValue$ Datum slanja�� �� 	Converter# [  	 �� ConverterParameter$	 slanje��(  "Wpf.Ui.Controls.CalendarDatePicker  -   $��DatumPocetni��$��40��$��40��$��Right=�$��Center=�$��0q�$��1��
   Date
 �� *Date+ �� Mode$ TwoWay=��� $��/slike/kalendar.png��$��Right=�$��12��$��12��$��Center=� J� IsHitTestVisible$ False��$��1�� K� ZIndex$ 10��$��2q�z���  �� ScaleX$ -1Q��� $��1��$��	9,120,0,0q�$
��Left=�$	��Top=� d� 	IsChecked �� *	Placeno+.��
Plaćeno�� $	��Top=�$
��Left=�$��
280,20,0,0q�$��0��$��1��._�� .+��� -   $��40��$	��220��$	��Top=�$
��Left=����� *ListaPravnihLica+ �� SelectedItem �� *SelectedPravnoLice+$ TwoWay=��� -   $��ComboboxTekst��$��Izaberite dobavljača��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��12(�
�������$��Center=�$
��Left=�$��10,0,0,0q�$ 1���� -   $��0��$��1��$	��220��$��40��$	��Top=�$
��Left=�$��280,70,20,20q�$��0q�
�������$��Dodaj dokumente��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��15(����� *AddFilesCommand+ J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 10Q�   	Direction$	 320Q�   Color$
 Gray��   Opacity$	 0.5Q�   
BlurRadius$ 30Q�����  �� 
TargetType" ��.���  �� Property � �� �� Value �	#FF4F72FF��  � �� ��  �� 
TargetType" ��.R��� #��z��#��z��#��z��$ 13��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#82A6FFP�  � ��$
 True��. ���  � �� �#3D64C2&   System.Windows.Controls.DataGrid  -   $��fajlovi��$��2��$��1��   
IsReadOnly$
 True��$	��Top=�   CanUserReorderColumns$ False��$
��Left=�    AutoGenerateColumns$  False��$��False��$��580,00,20,20q����� *SelectedFiles+  =  7System.Windows.Controls.Primitives.DataGridColumnHeader)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell! �� Triggers��%/  '        '  �     '  z    �� "  .���  � �� �	#FF4F72FF��  � ��
 �������  � ��$
 Bold"���  � ��$ 10q���  � ��$ Center=���  � �� �� "  .R��� #��z��$ 10q�$��0q�._��� $��Center=���  � y�$ 	Collapsed=��� "  .���  � ��$ 50����  � ��
 �������  � ��
 ���� ��  �@�OverridesDefaultStyle$ False���� "  .���  � ��
 ���� ��  � ��
 ���� ! P�  �@ 
IsSelected$
 True��. ���  � ��
 ���� ��  � ��
 �   �"   Columns" 4	  .System.Windows.Controls.DataGridTemplateColumn	  ,
  &System.Windows.Controls.DataGridColumn# 
  Header$# Slika��$ 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
$ Auto % 
  MinWidth$% 50Q�& 	  CellTemplate& �� .R��� $��/slike/file.png��$��50��$��50��0  *System.Windows.Controls.DataGridTextColumn  $# 	Ime fajla��$
$ Auto $% 50Q�1  +System.Windows.Controls.DataGridBoundColumn'   Binding' �� *
imeFajla+(   ElementStyle( �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�  Wpf.Ui.Controls.TextBlock  $��0��$��2��$��0��$��0,0,0,0q�$��Bottom=�$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)�
���  ��$��Center=����� *Greska+�� $ 20��$ 0q�
�������$��1��$	��228��$	��228��$��20,170,20,60q�$��2��   $ 10Q�$	 320Q�$
 Gray��$	 0.5Q�$ 30Q�._�  -   $��StavkeDataGrid��$  False��)   CanUserAddRows$) False��
������ *   CanUserResizeRows$* False��$ False��+   GridLinesVisibility$
+ None=�,   HeadersVisibility$, Column=�
������ $��0q�$��16(�$
 True��$1��+pack://application:,,,/Fonts/#Poppins Light)�-   HorizontalGridLinesBrush
- ���� .   VerticalGridLinesBrush
. ���� $
��auto��$	��228��$	��228��$��1��$��0��$��Stretch=�$��False��$��Disabled=�$
��Auto=����� *Stavke+  ��%  '        '  �     '  W    �� "  .���  � ��
 �������  � ��
 �   ���  � ��$
 Bold"���  � ��$ 10q���  � ��$ Center=���  � �� �� "  .R��� #��z��$ 10q�$��0q�._��� $��Center=��� "  .���  � ��$ 48����  � ��
 �������  � ��
 ���� ��  �@�OverridesDefaultStyle$ False���� "  .���  � ��
 ���� ��  � ��
 ���� ! P�  �@ 
IsSelected$
 True��. ���  � ��
 ���� ��  � ��
 �   �"   $# Šifra��$$ * $% 50Q�' �� *sifra+( �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�  $# Naziv��$$ * $% 80Q�' �� *naziv+( �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�  $# 	Količina��$$ * $% 80Q�' �� *
kolicina+( �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�  $
# Cena��$$ * $% 80Q�' �� *	cenaRSD+( �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�  $# Iznos bez PDV��$$ * $% 80Q�' �� *osnovicaRSD+( �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�  $# PDV %��$$ * $	% 100Q�' �� *
pdvposto+( �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�  $# Iznos sa PDV��$$ * $	% 100Q�' �� *	ukupnoRSD+( �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�	  $# Akcije��$	% 120Q�$
$ Auto & �� .R��� / �� Orientation$/ 
Horizontal=�$��Center=�.+��� $��40��$��30��$��0q�
�������0 � Cursor$
0 Hand��$��0,0,10,0q����� *DataContext.DeleteCommand+1 �� RelativeSource1 �� 2 �� AncestorType2 UserControl���� ���� " ��.���  � �� �#F44336��  � �� �� " ��.R��� #��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#F88780P�  � ��$
 True��. ���  � �� �#D32F2F! P�  �@J�IsMouseOver$
 True��. ���  � �� �#F88780P�  � ��$
 True��. ���  � �� �#D32F2F.���� $��/slike/izbrisi.png��$��25��$��20��$��Center=�$��Center=�  -   $��2��$��2��$��40��$��90��$��90��$
��Left=�$	��Top=�$ Šifra��$��20,0,0,0q����� *Sifra+  $��2��$��2��$��40��$	��100��$	��100��$
��Left=�$	��Top=�$ Naziv��$��	120,0,0,0q����� *Naziv+  -	   $��2��$��2��$��40��$��71��$��71��$
��Left=�$	��Top=�$ 	Količina��$��	230,0,0,0q����� *
Kolicina+  -
   $��2��$��2��$��40��$��90��$��90��$
��Left=�$	��Top=�$
 Cena��$��	310,0,0,0q����� *Cena+  $��2��$��2��$��40��$	��111��$	��111��${�False��$
��Left=�$	��Top=�$ Iznos bez PDV��$��	415,0,0,0q����� *IznosbezPDV+  -   $��2��$��2��$��40��$��66��$��66��$
��Left=�$	��Top=�$ PDV %��$��	540,0,0,0q����� *
PDVPosto+  $��2��$��2��$��40��$	��103��$	��103��${�False��$
��Left=�$	��Top=�$ Iznos sa PDV��$��	615,0,0,0q����� *Ukupno+�� $��2��$��2��$	��160��$��40��$	��Top=�$
��Left=�$��
730,0,20,0q�$��0q�
�������$��Dodaj novu stavku��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��15(����� *AddStavkaCommand+   $ 10Q�$	 320Q�$
 Gray��$	 0.5Q�$ 30Q����� " ��.���  � �� �	#FF4F72FF��  � �� �� " ��.R��� #��z��#��z��#��z��$ 13��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#82A6FFP�  � ��$
 True��. ���  � �� �#3D64C2�� $1��+pack://application:,,,/Fonts/#Poppins Light)�$��23(�3 � Language$3 
sr-Latn-RS�$��2��$��2��$��	20,80,0,0q����� *UkupnoOsnovica+$ Iznos pre PDV: {0:N2} RSD���� $1��+pack://application:,,,/Fonts/#Poppins Light)�$��23(�$3 
sr-Latn-RS�$��2��$��2��$��
20,130,0,0q����� *	ukupnoPDV+$ PDV iznos: {0:N2} RSD���� $1��+pack://application:,,,/Fonts/#Poppins Light)�$��23(�$3 
sr-Latn-RS�$��2��$��2��$��20,180,0,100q����� *UkupnoUkupno+$ Ukupan iznos: {0:N2} RSD���� $��2��$��0��$��2��$	��220��$��40��$��Bottom=�$��Center=�$��-260,180,20,20q�$��0q�
�������$��Sačuvaj��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��15(����� *SacuvajCommand+   $ 10Q�$	 320Q�$
 Gray��$	 0.5Q�$ 30Q����� " ��.���  � �� �#4CAF50��  � �� �� " ��.R��� #��z��#��z��#��z��$ 13��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#81C784P�  � ��$
 True��. ���  � �� �#388E3C�� -   $��2��$��2��$	��220��$��40��$��Bottom=�$��Center=�$��240,180,20,20q�$��0q�
�������$��Nazad��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��15(�   $ 10Q�$	 320Q�$
 Gray��$	 0.5Q�$ 30Q����� " ��.���  � �� �#F44336��  � �� �� " ��.R��� #��z��#��z��#��z��$ 13��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#F88780P�  � ��$
 True��. ���  � �� �#D32F2F