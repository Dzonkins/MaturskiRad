   M S B A M L   `   `   `  ����Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProgramZaRacunovodstvoProgramZaRacunovodstvo  5      '    !ProgramZaRacunovodstvo.IzborFirme   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      0local$clr-namespace:ProgramZaRacunovodstvo  5      .��5	      � ��5
   
   �� 5        �� EndPoint$  0.5,1&�6"    �� 
StartPoint$ 0.5,0&�5   "   .��5      �  � Color$ 	#FF223FFF��6    � Offset$ 1Q�5      � 5      $ 	#FF4FBBFF��6   5      .+�5   
   �� $��0,60,0,0q�6   $��/slike/firma.png��5      $
��Fill=�5      $��Center=�5      $	��146��5      $	��139��5      $	��Top=�5      A� 5   
   -   5         A�Name$ 
FirmaPanel��5       A� Rows$ 4��5       A� Columns$ 2��5      $��Center=�5      $	��Top=�5      $��	0,200,0,0q�5       �� 5"   
    �� Orientation$ 
Horizontal=�6   $��Center=�5#      $��Bottom=�5$      $��0,0,0,50q�5%      .+�5'        Wpf.Ui.Controls.Button  -   5        $��70��5(      $	��470��5)      $��0q�5*      $1��+pack://application:,,,/Fonts/#Poppins Light)�5+      $��30(�5,      $��0,0,20,0q�5-         CornerRadius$ 15��5.      	 J� Effect	 50      3  -System.Windows.Media.Effects.DropShadowEffect  51      
   ShadowDepth$
 10Q�6'      	Direction$	 320Q�52   '      Color$
 Gray��53   '      Opacity$	 0.5Q�54   '      
BlurRadius$ 30Q�55   '   ��57      �� 58       �� 
TargetType"  6   .�59      ��  �� Property � �� �� Value
 �����5:   !   �� 5;       � ��
 �   �5<   !   �� 5=       � �� 5>      �� 5?   "    �� 
TargetType" ��62   .R�5@   &   �� #��z��6-   #��z��5A   -   #��z��5B   -    �� CornerRadius$ 15��5C   -   ._�5D   *   �� $��Center=�6;   $��Center=�5E   ;   5F   '    �� Triggers 5G   &   P� 5H   *    P� Property �@J�IsMouseOver P� Value$
 True��5I   2   . �5J   .   ��  � �� �#EDEDED5K   5   5L   +   P� 5N   *    � ��$
 True��5O   2   . �5P   .   ��  � �� �#B8B7B65Q   5   5R   +   5T   #   5V      5W      ��5Y      �� 5Z      $��Dodaj firmu��6    $��30(�5[       $1��+pack://application:,,,/Fonts/#Poppins Light)�5\       $��Center=�5]       $��Center=�5^       5`        5b      -   5        $��70��5c      $	��470��5d      
�������$��0q�5f      $1��+pack://application:,,,/Fonts/#Poppins Light)�5g      $��30(�5h      $ 15��5j      	 5k        5l      $
 10Q�6'   $	 320Q�5m   '   $
 Gray��5n   '   $	 0.5Q�5o   '   $ 30Q�5p   '   ��5r      �� 5s      "  6   .�5t      ��  � ��
 �  ��5u   !   �� 5v       � ��
 �����5w   !   �� 5x       � �� 5y      �� 5z   "   " ��62   .R�5{   &   �� #��z��6-   #��z��5|   -   #��z��5}   -   $ 15��5~   -   ._�5   *   �� $��Center=�6;   $��Center=�5�   ;   5�   '    5�   &   P� 5�   *    �@J�IsMouseOver$
 True��5�   2   . �5�   .   ��  � �� �#F73B3B5�   5   5�   +   P� 5�   *    � ��$
 True��5�   2   . �5�   .   ��  � �� �#D32F2F5�   5   5�   +   5�   #   5�      5�      ��5�      �� 5�      $��Nazad��6    $��30(�5�       $1��+pack://application:,,,/Fonts/#Poppins Light)�5�       $��Center=�5�       $��Center=�5�       5�      5�      5�      5�      