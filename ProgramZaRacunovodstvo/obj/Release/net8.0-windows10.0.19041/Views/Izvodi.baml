   M S B A M L   `   `   `  ���� Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ProgramZaRacunovodstvo.ViewModels!ProgramZaRacunovodstvo.ViewModels  )    #ProgramZaRacunovodstvo.Views.Izvodi   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  ;local/clr-namespace:ProgramZaRacunovodstvo.ViewModels    � 	Resources  6  0ProgramZaRacunovodstvo.ViewModels.DatumConverter   DatumConverter��%   &	          .��� 
������� � RowDefinitions �� $	��250 ��� $��* �.+��� $��Izvodi��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��28(�$��
20,40,0,20q�$	��759��$
��Left=�$	��Top=��� $��0��$	��200��$��40��$��Bottom=�$��Right=�$��	0,0,20,20q�$��0q�
�������$��Izvoz u excel��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��15(����� *Izvod+ J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 10Q�   	Direction$	 320Q�   Color$
 Gray��   Opacity$	 0.5Q�   
BlurRadius$ 30Q�����  �� 
TargetType" ��.��� 	 �� Property	 � ��
 �� Value
 �	#FF4F72FF�� 	 � ��
 ��  �� 
TargetType" ��.R��� #��z��#��z��#��z�� �� CornerRadius$ 13��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ��� 	 � ��
 �#82A6FFP�  � ��$
 True��. ��� 	 � ��
 �#3D64C2�� 
�������$��1q�$��40��$	��220��$ 10�� �� Padding$ 5q�$
��Left=�$��Bottom=�$��20q�._��  � ColumnDefinitions �� $
��Auto ��� $��* �.+��� -   $��DatumTextbox��$��Center=�$
��Left=�$��0,0,5,0q�$��0������ *Date+ �� StringFormat$ {0:d}�� �� FallbackValue$ Odaberite početni datum�� �� 	Converter# [   �� ConverterParameter$ start��(  "Wpf.Ui.Controls.CalendarDatePicker  -   $��DatumPocetni��$��40��$��40��$��Right=�$��Center=�$��0q�$��1��   Date �� *Date+ �� Mode$ TwoWay=��� $��/slike/kalendar.png��$��Right=�$��12��$��12��$��Center=� J� IsHitTestVisible$ False��$��1�� K� ZIndex$ 10��$��2q�z���  �� ScaleX$ -1Q��� 
�������$��1q�$��40��$	��220��$ 10��$ 5q�$
��Left=�$��Bottom=�$��
270,0,0,20q�._��  �� $
��Auto ��� $��* �.+��� -   $��DatumTextbox2��$��Center=�$
��Left=�$��0,0,5,0q�$��0������ *Date2+$ {0:d}��$ Odaberite krajnji datum��# [  $	 end��  -   $��DatumKrajnji��$��40��$��40��$��Right=�$��Center=�$��0q�$��1�� �� *Date2+$ TwoWay=�  Wpf.Ui.Controls.TextBox  $��0��$��40��$	��220��$
��Left=�$��Bottom=�$��
520,0,0,20q�   PlaceholderText$ Pretraga������ *PretragaText+ �� UpdateSourceTrigger$ PropertyChanged=��� $ 20��$ 0q�
�������$��1��$��
20,0,20,60q�   $ 10Q�$	 320Q�$
 Gray��$	 0.5Q�$ 30Q�._�&   System.Windows.Controls.DataGrid  -   $��IzvodiDataGrid��   AutoGenerateColumns$ False��   CanUserAddRows$ False��
������    CanUserResizeRows$ False��    GridLinesVisibility$
  None=�!   HeadersVisibility$! Column=�
������ $��0q�$��16(�"   
IsReadOnly$
" True��$1��+pack://application:,,,/Fonts/#Poppins Light)�#   HorizontalGridLinesBrush
# ���� $   VerticalGridLinesBrush
$ ���� $
��auto��$��Center=�$��Disabled=�$��Disabled=����� *PagedIzvodi+  =  7System.Windows.Controls.Primitives.DataGridColumnHeader)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell% �� Triggers��%  '        '  �     '  ]    �� "  .��� 	 � ��
 �	#FF4F72FF�� 	 � ��

 ������� 	 � ��$

 Bold"��� 	 � ��$
 10q��� 	 � ��$
 Center=��� 	 � ��
 �� "  .R��� #��z��$ 10q�$��0q�._��� $��Center=��� "  .��� 	 � ��$
 50���� 	 � ��

 ������� 	 � ��

 ���� �� 	 �@�OverridesDefaultStyle$
 False���� "  .��� 	 � ��

 ���� �� 	 � ��

 ���� % P�  �@ 
IsSelected$
 True��. ��� 	 � ��

 ���� �� 	 � ��

 �   �&   Columns& 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn' 
  Header$' Broj fakture��( 
  Width5  /System.Windows.Controls.DataGridLengthConverter$( * ) 
  MinWidth$	) 100Q�1  +System.Windows.Controls.DataGridBoundColumn*   Binding* �� *BrojFakture++   ElementStyle+ �� " ��.��� 	 �@��TextAlignment$
 Center=��� 	 � ��$
 Center=��� 	 �@��Padding$
 10q�	  $' Tip fakture��$( * $	) 100Q�* �� *
TipFakture++ �� " ��.��� 	 �@��TextAlignment$
 Center=��� 	 � ��$
 Center=��� 	 �@��Padding$
 10q�	  $' Pravno lice��$( * $	) 100Q�* �� *
PravnoLice++ �� " ��.��� 	 �@��TextAlignment$
 Center=��� 	 � ��$
 Center=��� 	 �@��Padding$
 10q�	  $' Osnovica��$( * $	) 120Q�* �� *OsnovicaRSD++ �� " ��.��� 	 �@��TextAlignment$
 Center=��� 	 � ��$
 Center=��� 	 �@��Padding$
 10q�	  $	' PDV��$( * $	) 100Q�* �� *PdvRSD++ �� " ��.��� 	 �@��TextAlignment$
 Center=��� 	 � ��$
 Center=��� 	 �@��Padding$
 10q�	  $' Ukupno��$( * $	) 100Q�* �� *	UkupnoRSD++ �� " ��.��� 	 �@��TextAlignment$
 Center=��� 	 � ��$
 Center=��� 	 �@��Padding$
 10q�	  $' Datum��$( * $	) 100Q�* �� *DatumSlanja+$ {0:dd.MM.yyyy.}��+ �� " ��.��� 	 �@��TextAlignment$
 Center=��� 	 � ��$
 Center=��� 	 �@��Padding$
 10q�4  .System.Windows.Controls.DataGridTemplateColumn  $' Akcije��$
( Auto ,   CellTemplate, �� .R��� - �� Orientation$- 
Horizontal=�$��Center=�.+��� $��40��$��30��$��0q�
�������. � Cursor$
. Hand��$��0q�$��0,0,5,0q����� *DataContext.Detalji+/ �� RelativeSource/ �� 0 �� AncestorType0 UserControl���� ���� " ��.��� 	 � ��
 �	#FF4F72FF�� 	 � ��
 �� " ��.R��� #��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� 	 � ��
 �#82A6FFP�  � ��$
 True��. ��� 	 � ��
 �#3D64C2.���� $��/slike/detalji.png��$��25��$��20��$��Center=�$��Center=��� $��1��$- 
Horizontal=�$��Right=�$��Bottom=�$��
0,10,20,20q�.+��� $��Nazad��$��0,0,10,0q����� *PrethodnaStranica+�� $��Sledeće������ *SledecaStranica+