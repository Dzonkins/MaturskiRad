   M S B A M L   `   `   `  ���� Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ProgramZaRacunovodstvo.ViewModels!ProgramZaRacunovodstvo.ViewModels  [ WLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF U/clr-namespace:ProgramZaRacunovodstvo.ViewModels!ProgramZaRacunovodstvo.ViewModels  3    -ProgramZaRacunovodstvo.ViewModel.GlavnaStrana   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:ProgramZaRacunovodstvo.ViewModels     hlvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF     M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  9vms/clr-namespace:ProgramZaRacunovodstvo.ViewModels  .��� 
�������.+��� $
��Auto=�.��� $��20q�  � RowDefinitions  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* � � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��$��0��.+��� -   $��Firma��$��Dobrodošli ImeFirme��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��28(�$��
25,20,0,20q�$	��759��/  )LiveChartsCore.SkiaSharpView.WPF.PieChart  ,  &LiveChartsCore.SkiaSharpView.WPF.Chart   LegendPosition$ Bottom=�$	��500��   Series �� *PrihodiRashodi+   Title �� *PrihodiRashodiNaslov+�� $��0��$��1��.+�  Wpf.Ui.Controls.Card  $
��Auto��$	��120��$��10q�$��40,80,40,10q�����  �� 
TargetType"  .R���  �� CornerRadius$ 20�� �� Padding# z������  �� 
StartPoint$	 0,0&�	 �� EndPoint$		 1,1&�.��� 
 � Color$
 	#FF7BD27B�� � Offset$ 0Q�� $
 	#FF98E599��$ 1Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 10Q�   	Direction$	 320Q�   Color$
 Gray��   Opacity$	 0.5Q�   
BlurRadius$ 30Q�._��� $��Stretch=�$��Stretch=�.���� .+��� -   $��Stanje��$ ��Trenutno stanje za februar��$��30(�$��10,0,0,0q�
���   �$1��+pack://application:,,,/Fonts/#Poppins Light)��� $��35(�$��10,0,0,0q�
���   �$1��+pack://application:,,,/Fonts/#Poppins Light)����� *StanjeFormatted+  $
��Auto��$	��120��$��10q�$��
40,0,40,10q����� "  .R��� $ 20��# z������ $	 0,0&�$		 1,1&�.��� $
 	#FF4F72FF��$ 0Q�� $
 	#FF6A8CFF��$ 1Q�   $ 10Q�$	 320Q�$
 Gray��$	 0.5Q�$ 30Q�._��� $��Stretch=�$��Stretch=�.���� .+��� -   $��Ulazne��$��Ulazne fakture u februaru��$��30(�$��10,0,0,0q�$
��Bold"�
�������$1��+pack://application:,,,/Fonts/#Poppins Light)��� $��40(�$��10,0,0,0q�$
��Bold"�
�������$1��+pack://application:,,,/Fonts/#Poppins Light)����� *UlazneFakture+  $
��Auto��$	��120��$��10q�$��
40,0,40,10q����� "  .R��� $ 20��# z������ $	 0,0&�$		 1,1&�.��� $
 	#FF4F72FF��$ 0Q�� $
 	#FF6A8CFF��$ 1Q�   $ 10Q�$	 320Q�$
 Gray��$	 0.5Q�$ 30Q�._��� $��Stretch=�$��Stretch=�.���� .+��� -   $��Izlazne��$ ��Izlazne fakture u februaru��$��30(�$��10,0,0,0q�$
��Bold"�
�������$1��+pack://application:,,,/Fonts/#Poppins Light)��� $��40(�$��10,0,0,0q�$
��Bold"�
�������$1��+pack://application:,,,/Fonts/#Poppins Light)����� *IzlazneFakture+5  /LiveChartsCore.SkiaSharpView.WPF.CartesianChart  $��2��$��0��$	��400��$��10q�   Series �� *DobavljaciSeries+   XAxes �� *DobavljaciXAxes+   YAxes �� *DobavljaciYAxes+ �� *DobavljaciNaslov+  $��2��$��1��$	��400��$��10q� �� *KlijentiSeries+ �� *KlijentiXAxes+ �� *KlijentiYAxes+ �� *KlijentiNaslov+  $��3��$��2��$	��400��$��20q� �� *PrihodiRashodiMesec+ �� *PrihodiRashodiXAxes+ �� *PrihodiRashodiYAxes+ �� *PrihodiRashodiVise+