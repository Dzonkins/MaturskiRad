   M S B A M L   `   `   `  ����Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProgramZaRacunovodstvoProgramZaRacunovodstvo  5   	   '    !ProgramZaRacunovodstvo.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ProgramZaRacunovodstvo     5   	     � Title$  Program��5   	    � 
ResizeMode$ 	CanResize=�5	   	   
������ $
��1366��5   	   $	��768��5   	    � 	Resources 5         SidebarButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� Triggers	 P� Property
 P� Value��%U  &	        �� 5   
   " ��6+   .�5      ��  � �� �	#FF4F72FF6+   �� 5       � ��
 �����6+   �� 5       � ��$ 20(�6)   �� 5       � ��$2 ,pack://application:,,,/Fonts/#Poppins-Medium)�6+   �� 5       � ��$ 0q�60   �� 5       � ��$ 10q�6(   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 10q�6K   $��2q�6X   
������ ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       	 �@J�IsMouseOver$

 True��61   . �5!      ��  � ��
 �����64   �� 5"       � �� �	#FF3B5FFF63   5#      P� 5$      	 � ��$

 True��6/   . �5%      ��  � �� �	#FF2B4FFF63   �� 5&       � ��
 �����64   5'      5)      5*      .��5,      � .+�5-   
   � -   5         �Name$ 
MainLayout��5-      $y�Visible=�6#    � ColumnDefinitions 5.      �� 5/      $	��200 �6#   �� 51      $��* �6#   .+�56      �� ���	#FF4F72FF$	��200��60   .+�57      �� 
 � Tag$ Pocetna��6   #��[  6'   .��58      �  59      �� 5:      $
��Auto �6/   �� 5;      $��* �6/   .+�5=      �� $��slike/pocetna.png��6    $��30��6;   $��30��6F   $��Center=�6S   $
��Left=�6n   $��	-50,0,0,0q�6�   $��0��6�   �� 5>      $��Početna��6$   $��Center=�63   $��1��6N   $��-6,0,5,0q�6^   5?      5@      �� 5A      $��Nabavke��6   $ Nabavke��6+   #��[  69   5C      �� 5D      $��Prodaja��6   $ Prodaja��6+   #��[  69   �� 5E      $ Izvodi��6   #��[  6&   .��5F      �  5G      �� 5H      $
��Auto �6/   �� 5I      $��* �6/   .+�5K      �� $��slike/izvod.png��6    $��30��69   $��30��6D   $��Center=�6Q   $
��Left=�6l   $��	-59,0,0,0q�6�   $��0��6�   �� 5L      $��Izvodi��6$   $��Bottom=�62   $��1��6M   $��
-11,0,10,0q�6]   5M      5N      5O      �� 5R      -   5         ��Name$ MainContent��5R      $��1��62   5S      � 5T   
   -   5        $ OverlayContainer��5T      
�������$y�	Collapsed=�6<   .+�5U      �� -   5         ��Name$ OverlayContent��5U      5V      5W      5X      