   M S B A M L   `   `   `  ���� d  `Microsoft.Web.WebView2.Wpf, Version=1.0.3171.0, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf  Q MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProgramZaRacunovodstvo.ViewsProgramZaRacunovodstvo.Views 1   +ProgramZaRacunovodstvo.Views.DetaljiFakture   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     \wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  6local*clr-namespace:ProgramZaRacunovodstvo.Views  .���� -     ��Name$  MainScrollViewer��$
��Auto=�.��� 
������� � RowDefinitions �� $	��120 ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $	��250 ��� $	��310 ��� $��* �.+��� $��Detalji fakture��$��2��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��28(�$��
20,40,0,20q�$	��759��$
��Left=�$	��Top=��� $��1��$��0��.+��� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Broj fakture��  Wpf.Ui.Controls.TextBox  $��	20,10,0,0q� �� 
IsReadOnly$
 True������ *BrojFakture+�� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Datum slanja��  $��	20,10,0,0q�$
 True������ *DatumSlanja+�� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Iznos fakture��  $��	20,10,0,0q�$
 True������ *Iznos+�� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Tip fakture��  $��	20,10,0,0q�$
 True������ *
TipFakture+�� $��1��$��1��$��60,0,0,0q�.+��� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��
Dobavljač��  $��	20,10,0,0q�$
 True������ *	Dobavljac+�� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Kupac��  $��	20,10,0,0q�$
 True������ *Kupac+�� $��	10,20,0,0q� d� 	IsChecked �� *	Placeno+ �� Mode$ TwoWay=����� *
Checkbox+���� *	Placeno+.��
Plaćeno�� $��📥 Preuzmi fakturu��$��10q�$��40��$	��200��
�������$��	20,20,0,0q����� *PreuzmiFakturuCommand+����  �� 
TargetType" ��.���  �� Property � �� �� Value �	#FF4F72FF��  � �� �� 	 �� 
TargetType"	 ��.R��� #��z��#��z��$��0q�
 �� CornerRadius$
 5��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#82A6FFP�  � ��$
 True��. ���  � �� �#3D64C2�� -   $��Nazad��$��10q�$��40��$	��200��
�������$��	20,20,0,0q����� " ��.���  � �� �#F44336��  � �� �� "	 ��.R��� #��z��#��z��$��0q�$
 5��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#F88780P�  � ��$
 True��. ���  � �� �#D32F2F�� $��	60,20,0,0q�$��15(�$��2��$��1��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Prilozi��&   System.Windows.Controls.DataGrid  -   $��fajlovi��$��2��$��1��   
IsReadOnly$
 True��   CanUserReorderColumns$ False��$	��Top=�$
��Left=�   AutoGenerateColumns$ False��$��False��$��50,20,20,20q����� *	Fajlovi+ � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Padding)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell �� Triggers��%,  '        '  �     '  w    �� "  .���  � �� �	#FF4F72FF��  � ��
 �������  � ��$
 Bold"���  � ��$ 10q���  � ��$ Center=���  � �� �� "	  .R��� #��z��$ 10q�$��0q�._��� $��Center=���  � y�$ Hidden=��� "  .���  � ��$ 50����  � ��
 �������  � ��
 ���� ��  �@�OverridesDefaultStyle$ False���� "  .���  � ��
 ���� ��  � ��
 ����  P�  �@ 
IsSelected$
 True��. ���  � ��
 ���� ��  � ��
 �   �   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Slika��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    MinWidth$ 50Q�   CellTemplate �� .R��� $��/slike/file.png��$��50��$��50��0	  *System.Windows.Controls.DataGridTextColumn	  $ 	Ime fajla��$
 Auto $ 50Q�1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *
NazivFajla+ 
  ElementStyle �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�  $ Preuzmi��$
 Auto $ 80Q� �� .R��� $��📥 Preuzmi��$��5q�$��5q�$��80��$��30��
����������� *DataContext.Sacuvaj+ �� RelativeSource ��  �� AncestorType UserControl���� ���� " ��.���  � �� �	#FF4F72FF��  � �� �� "	 ��.R��� #��z��#��z��$��0q�$
 5��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#82A6FFP�  � ��$
 True��. ���  � �� �#3D64C2)   #Microsoft.Web.WebView2.Wpf.WebView2  -     Name$ 	pdfViewer��$��0��$��3��$��2��$��20,40,20,20q�$��0��$	��900��$
��1200��$��Center=�$��Stretch=�   Source �� *PdfUrl+