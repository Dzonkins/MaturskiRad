   M S B A M L   `   `   `  ����Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ProgramZaRacunovodstvo.ViewModels!ProgramZaRacunovodstvo.ViewModels  5      [ WLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF 5      U/clr-namespace:ProgramZaRacunovodstvo.ViewModels!ProgramZaRacunovodstvo.ViewModels  5	      3    -ProgramZaRacunovodstvo.ViewModel.GlavnaStrana   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:ProgramZaRacunovodstvo.ViewModels     5      hlvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      9vms/clr-namespace:ProgramZaRacunovodstvo.ViewModels  5	      .��5      � 
�������.+�5   
   �� $
��Auto=�6   .��5      � $��20q�6     � RowDefinitions  5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� $��0��6   $��0��5      .+�5      �� -   5        $��Firma��5       $��Dobrodošli ImeFirme��5       $1��+pack://application:,,,/Fonts/#Poppins Light)�5        $��28(�5!       $��
25,20,0,20q�5"       $	��759��5#       /  )LiveChartsCore.SkiaSharpView.WPF.PieChart  5$      ,  &LiveChartsCore.SkiaSharpView.WPF.Chart   LegendPosition$ Bottom=�5&   #   $	��500��5'   #      Series 5$   #   �� *PrihodiRashodi+   Title 5%   #   �� *PrihodiRashodiNaslov+5'   #   5(      �� 5*      $��0��6   $��1��5+      .+�5,        Wpf.Ui.Controls.Card  $
��Auto��6   $	��120��5-      $��10q�5.      $��40,80,40,10q�5/      ��50      �� 51       �� 
TargetType"  6.   .R�52   "   ��  �� CornerRadius$ 20��6)    �� Padding# z��53   )   ��54   &   �� 55   *    �� 
StartPoint$	 0,0&�6>   	 �� EndPoint$		 1,1&�56   >   .��57   .   � 
 � Color$
 	#FF7BD27B��6;    � Offset$ 0Q�58   ;   � 59   .   $
 	#FF98E599��6;   $ 1Q�5:   ;   5;   +    J� Effect 5=   &   3  -System.Windows.Media.Effects.DropShadowEffect  5>   *      ShadowDepth$ 10Q�6;      	Direction$	 320Q�5?   ;      Color$
 Gray��5@   ;      Opacity$	 0.5Q�5A   ;      
BlurRadius$ 30Q�5B   ;   ._�5D   &   �� $��Stretch=�67   $��Stretch=�5E   7   5F   #   5G      .��5I      �� .+�5J      �� -   5        $��Stanje��5L   (   $ ��Trenutno stanje za februar��5J   (   $��30(�5K   (   $��10,0,0,0q�5M   (   
���   �$1��+pack://application:,,,/Fonts/#Poppins Light)�5O   (   �� 5P      $��35(�5Q   (   $��10,0,0,0q�5R   (   
���   �$1��+pack://application:,,,/Fonts/#Poppins Light)�5T   (   ��5P   (   �� *StanjeFormatted+5T   (   5U      5V        5X      $
��Auto��6   $	��120��5Y      $��10q�5Z      $��
40,0,40,10q�5[      ��5\      �� 5]      "  6.   .R�5^   "   �� $ 20��6)   # z��5_   )   ��5`   &   �� 5a   *   $	 0,0&�6>   $		 1,1&�5b   >   .��5c   .   � $
 	#FF4F72FF��6;   $ 0Q�5d   ;   � 5e   .   $
 	#FF6A8CFF��6;   $ 1Q�5f   ;   5g   +    5i   &     5j   *   $ 10Q�6;   $	 320Q�5k   ;   $
 Gray��5l   ;   $	 0.5Q�5m   ;   $ 30Q�5n   ;   ._�5p   &   �� $��Stretch=�67   $��Stretch=�5q   7   5r   #   5s      .��5u      �� .+�5v      �� -   5        $��Ulazne��5w   (   $ ��Ulazne fakture za februaru��5v   (   $��30(�5x   (   $��10,0,0,0q�5y   (   $
��Bold"�5z   (   
�������$1��+pack://application:,,,/Fonts/#Poppins Light)�5|   (   �� 5}      $��40(�5~   (   $��10,0,0,0q�5   (   $
��Bold"�5�   (   
�������$1��+pack://application:,,,/Fonts/#Poppins Light)�5�   (   ��5}   (   �� *UlazneFakture+5�   (   5�      5�        5�      $
��Auto��6   $	��120��5�      $��10q�5�      $��
40,0,40,10q�5�      ��5�      �� 5�      "  6.   .R�5�   "   �� $ 20��6)   # z��5�   )   ��5�   &   �� 5�   *   $	 0,0&�6>   $		 1,1&�5�   >   .��5�   .   � $
 	#FF4F72FF��6;   $ 0Q�5�   ;   � 5�   .   $
 	#FF6A8CFF��6;   $ 1Q�5�   ;   5�   +    5�   &     5�   *   $ 10Q�6;   $	 320Q�5�   ;   $
 Gray��5�   ;   $	 0.5Q�5�   ;   $ 30Q�5�   ;   ._�5�   &   �� $��Stretch=�67   $��Stretch=�5�   7   5�   #   5�      .��5�      �� .+�5�      �� -   5        $��Izlazne��5�   (   $ ��Izlazne fakture u februaru��5�   (   $��30(�5�   (   $��10,0,0,0q�5�   (   $
��Bold"�5�   (   
�������$1��+pack://application:,,,/Fonts/#Poppins Light)�5�   (   �� 5�      $��40(�5�   (   $��10,0,0,0q�5�   (   $
��Bold"�5�   (   
�������$1��+pack://application:,,,/Fonts/#Poppins Light)�5�   (   ��5�   (   �� *IzlazneFakture+5�   (   5�      5�      5�      5  /LiveChartsCore.SkiaSharpView.WPF.CartesianChart  5�      $��2��6%   $��0��5�   %   $	��400��5�   %   $��10q�5�   %      Series 5�   %   �� *DobavljaciSeries+   XAxes 5�   %   �� *DobavljaciXAxes+   YAxes 5�   %   �� *DobavljaciYAxes+ 5�   %   �� *DobavljaciNaslov+5�   %     5�      $��2��6%   $��1��5�   %   $	��400��5�   %   $��10q�5�   %    5�   %   �� *KlijentiSeries+ 5�   %   �� *KlijentiXAxes+ 5�   %   �� *KlijentiYAxes+ 5�   %   �� *KlijentiNaslov+5�   %     5�      $��3��6%   $��2��5�   %   $	��400��5�   %   $��20q�5�   %    5�   %   �� *PrihodiRashodiMesec+ 5�   %   �� *PrihodiRashodiXAxes+ 5�   %   �� *PrihodiRashodiYAxes+ 5�   %   �� *PrihodiRashodiVise+5�      5�      5�      5�      