   M S B A M L   `   `   `  ���� Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ProgramZaRacunovodstvo.ViewModels!ProgramZaRacunovodstvo.ViewModels  )    #ProgramZaRacunovodstvo.Views.OFirmi   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  ;local/clr-namespace:ProgramZaRacunovodstvo.ViewModels  .���� $
��Auto=�.��� 
�������  � RowDefinitions  �� $	��120 ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $	��300 ��� $	��360 ��� $��* �.+��� $��O firmi��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��28(�$��
20,40,0,20q�$	��759��$
��Left=�$	��Top=��� $��1��$��0��.+��� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Naziv firme��  Wpf.Ui.Controls.TextBox  $��	20,10,0,0q� �� 
IsReadOnly$
 True������ *Naziv+�� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$	��PIB��  $��	20,10,0,0q�$
 True������ *PIB+�� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Matični broj��  $��	20,10,0,0q�$
 True������ *MaticniBroj+�� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Adresa��  $��	20,10,0,0q�$
 True������ *Adresa+�� $��1��$��1��$��60,0,0,0q�.+��� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$
��Grad��  $��	20,10,0,0q�$
 True������ *Grad+�� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Broj računa��  $��	20,10,0,0q�$
 True������ *
BrojRacuna+�� $��	20,20,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��	Zastupnik��  $��	20,10,0,0q�$
 True������ *	Zastupnik+�� $��2��$��0��$��3��$��0,50,0,0q�$��Center=�.+��� $��	20,20,0,0q�$��20(�$��2��$��1��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Administratori firme����  �� CornerRadius$ 20�� �� Padding$ 0q�
�������$��1��$	��228��$	��910��$	��228��$��20,10,20,20q�$��2�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 10Q�   	Direction$	 320Q�   Color$
 Gray��	   Opacity$		 0.5Q�
   
BlurRadius$
 30Q�._�&   System.Windows.Controls.DataGrid  -   $��administratori��   
IsReadOnly$
 True��$	��910��
������ $��Center=�   AutoGenerateColumns$ False��   CanUserReorderColumns$ False��   GridLinesVisibility$
 None=�   HeadersVisibility$ Column=�
������ $��0q�$��16(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��False��$��Disabled=����� *Administratori+ �� UpdateSourceTrigger$ PropertyChanged=� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value �� 
TargetType)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell �� Triggers P� Property P� Value��%  '        '  �     '  ]    �� "  .���  � �� �	#FF4F72FF��  � ��
 �������  � ��$
 Bold"���  � ��$ 10q���  � ��$ Center=���  � �� �� "  .R��� #��z��$ 10q�$��0q�._��� $��Center=��� "  .���  � ��$ 50����  � ��
 �������  � ��
 ���� ��  �@�OverridesDefaultStyle$ False���� "  .���  � ��
 ���� ��  � ��
 ����  P�  �@ 
IsSelected$
 True��. ���  � ��
 ���� ��  � ��
 �   �   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��   Width5	  /System.Windows.Controls.DataGridLengthConverter$	 170	    MinWidth$	 170Q�1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *Ime+ 
  ElementStyle �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�  $ Prezime��$
 Auto	 $	 270Q� �� *	Prezime+ �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�  $ Email��$
 Auto	 $	 350Q� �� *Email+ �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  �@��Padding$ 10q�4  .System.Windows.Controls.DataGridTemplateColumn  $ Akcije��$	 120Q�$
 Auto	    CellTemplate �� .R���   �� Orientation$  
Horizontal=�$��Center=�.+��� $��40��$��30��$��0q�
�������! � Cursor$
! Hand��$��0,0,10,0q����� *DataContext.Izbrisi+" �� RelativeSource" �� # �� AncestorType# UserControl���� ���� " ��.���  � �� �#F44336��  � �� �� " ��.R��� #��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=�$ �� Triggers$ P�  �@J�IsMouseOver$
 True��. ���  � �� �#F88780P�  � ��$
 True��. ���  � �� �#D32F2F P�  �@J�IsMouseOver$
 True��. ���  � �� �#F88780P�  � ��$
 True��. ���  � �� �#D32F2F.���� $��/slike/izbrisi.png��$��25��$��20��$��Center=�$��Center=��� $��1��$��2��$��60,0,0,0q�.+��� $��	20,20,0,0q�$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Dodaj administratora���� $��	20,60,0,0q�$��15(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Email administratora��  $��	20,10,0,0q�$
��Left=�$	��280��%   PlaceholderText$% Unesite email��$	��280������ *Email+�� $��Dodaj administratora��$��10q�$��40��$	��280��
�������$
��Left=�$��	20,27,0,0q����� *DodajAdmina+���� " ��.���  � �� �	#FF4F72FF��  � �� �� " ��.R��� #��z��#��z��$��0q�$ 5��._��� $��Center=�$��Center=�$ P�  �@J�IsMouseOver$
 True��. ���  � �� �#82A6FFP�  � ��$
 True��. ���  � �� �#3D64C2  Wpf.Ui.Controls.TextBlock  $
��Left=�$��	20,20,0,0q�$��17(�
���  ��$1��+pack://application:,,,/Fonts/#Poppins Light)����� *Greska+