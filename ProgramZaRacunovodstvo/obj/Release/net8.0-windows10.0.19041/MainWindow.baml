   M S B A M L   `   `   `  ���� Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProgramZaRacunovodstvoProgramZaRacunovodstvo  '    !ProgramZaRacunovodstvo.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:ProgramZaRacunovodstvo       � Title$  Program�� � 
ResizeMode$ 	CanResize=� � WindowState$ 	Maximized=�
������ $
��1366��$	��768�� � 	Resources    SidebarButtonStyle �� 
TargetType �� Property �� Value �� 
StartPoint �� EndPoint	 � Color
 � Offset �� 
TargetType �� Padding �� Triggers P� Property P� Value  GridBackgroundBrush��%�  &	        &	 J    �� " ��.���  � �� �� $	 0,0&�$	 1,1&�.��� $	 	#FF4F72FF��$
 0Q�� $	 	#FF6A8CFF��$
 1Q���  � ��
 �������  � ��$ 20(���  � ��$1 +pack://application:,,,/Fonts/#Poppins Light)���  � ��$ 0q���  � ��$ 10q���  �@�Cursor$
 Hand��-   ��  � �� �� " ��.R��� #��z��$ 10q�$��2q�
������ ._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 �������  � �� �	#FF3B5FFFP�  � ��$
 True��. ���  � �� �	#FF2B4FFF��  � ��
 ������� $	 0,0&�$	 1,0&�.��� $	 	#FF4F72FF��$
 0Q�� $	 	#FF6A8CFF��$
 1Q�.��� .+�� -    �Name$ 
MainLayout��$y�Visible=� � ColumnDefinitions �� $	��200 ��� $��* �.+�� #��[ $	��200�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� $	��100��._�� $��Center=�$��Center=� �� $��50 ��� $
��Auto � �� $
��Auto ��� $
��Auto �.+��� $��slike/vector.png��$��30��$��30��$��0��$��0��$��Center=�$��Center=�$��	-19,0,0,0q��� $��1��$��Center=�$��0,0,0,0q�$	��125��.+��� $	��125���� $��Dobrodošli��
�������$
��Left=�$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)��� -   $��ImeKorisnika��$��ImeKorisnika��
�������$
��Left=�$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)��� 
 � Tag$ Pocetna��#��[  $��1��$��False��.���  �� $
��Auto ��� $��* �.+��� $��slike/pocetna.png��$��30��$��30��$��Center=�$
��Left=�$��	-47,0,0,0q�$��0���� $��Početna��$��Center=�$��1��$��-6,0,5,0q�$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)��� $ Nabavke��#��[  $��2��$��False��.���  �� $
��Auto ��� $��* �.+��� $��slike/nabavke.png��$��30��$��30��$��Center=�$
��Left=�$��	-46,0,0,0q�$��0���� $��Nabavke��$��Center=�$��1��$��-5,0,2,0q�$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)��� $ Prodaja��#��[  $��3��$��False��.���  �� $
��Auto ��� $��* �.+��� $��slike/prodaja.png��$��30��$��30��$��Center=�$
��Left=�$��	-50,0,0,0q�$��0���� $��Prodaja��$��Center=�$��1��$��-8,0,8,0q�$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)��� $ Izvodi��#��[  $��4��$��False��.���  �� $
��Auto ��� $��* �.+��� $��slike/izvod.png��$��30��$��30��$��Center=�$
��Left=�$��	-60,0,0,0q�$��0���� $��Izvodi��$��Center=�$��1��$��
-17,0,18,0q�$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)��� $ Pravna lica��#��[  $��5��$��False��.���  �� $
��Auto ��� $
��Auto �.+��� $��slike/pravnalica.png��$��30��$��30��$��Center=�$
��Left=�$��1,0,0,0q�$��0���� $��Pravna lica��$��Center=�$��Center=�$��1��$��	12,0,24,0q�$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)��� $ OFirmi��#��[  $��6��$��False��.���  �� $
��Auto ��� $��* �.+��� $��slike/info.png��$��30��$��30��$��Center=�$
��Left=�$��	-32,0,0,0q�$��0���� $��O firmi��$��Center=�$��Right=�$��1��$��	10,0,33,0q�$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)��� $ PromeniFirmu��#��[  $��8��$��False��.��� .+��� $��Promeni firmu��$��Center=�$��Center=�$��0,0,0,0q�$
��auto��$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)��� $ 	IzlogujSe��#��[  $��9��$��False��.���  �� $
��Auto ��� $��* �.+��� $��slike/logout.png��$��30��$��30��$��Center=�$
��Left=�$��	-47,0,0,0q�$��0���� $��
Izloguj se��$��Center=�$��1��$��-5,0,0,0q�$��20(�$1��+pack://application:,,,/Fonts/#Poppins Light)��� -    ��Name$ MainContent��$��1��$��False��� -   $ OverlayContainer��
�������$y�	Collapsed=�.+��� -    ��Name$ OverlayContent��