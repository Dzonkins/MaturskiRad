   M S B A M L   `   `   `  ���� Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProgramZaRacunovodstvo.ViewsProgramZaRacunovodstvo.Views  -    'ProgramZaRacunovodstvo.Views.DodajFirmu   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:ProgramZaRacunovodstvo.Views     M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  .��� $
��auto��$
��auto������   �� EndPoint$  0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF223FFF�� � Offset$ 1Q�� $ 	#FF4FBBFF��.+�� $��Center=�$��Center=�.+��� -    ��Name$ txtImeFirme��
 � Tag$ 	Ime firme��$��0,0,0,0q�$	��Top=�$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$��	Ime firme��$��Center=�$��0q�$��Center=�$	��470��$��1��.������  �� 
TargetType" ��.���  �� Property �@J�Effect �� Value 3  -System.Windows.Media.Effects.DropShadowEffect  	   ShadowDepth$	 10Q�
   	Direction$	
 320Q�   Color$
 Gray��   Opacity$	 0.5Q�   
BlurRadius$ 30Q�.������  �� 
TargetType" ��.R���  �� CornerRadius$ 15��$��0q�
������  �� Padding$ 10q����	#8CFFFFFF._���  ��Name$ PART_ContentHost��$��Center=�.���� -   $ 
txtMaticni��$��	0,168,0,0q�$ Matični broj�� �� 	MaxLength$ 8��$	��Top=�$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$��Matični broj��$��Center=�$��0q�$��Center=�$	��470��$��3��.������ " ��.���  �@J�Effect   $	 10Q�$	
 320Q�$
 Gray��$	 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -   $ txtPIB��$��0,84,0,0q�$	 PIB��$ 9��$	��Top=�$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$	��PIB��$��Center=�$��0q�$��Center=�$	��470��$��2��.������ " ��.���  �@J�Effect   $	 10Q�$	
 320Q�$
 Gray��$	 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -   $ 	txtAdresa��$��	0,252,0,0q�$	��Top=�$ Adresa sedišta firme��$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$��Adresa sedišta firme��$��Center=�$��0q�$��Center=�$	��470��$��4��.������ " ��.���  �@J�Effect   $	 10Q�$	
 320Q�$
 Gray��$	 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -   $ txtGrad��$��	0,336,0,0q�$	��Top=�$
 Grad��$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$
��Grad��$��Center=�$��0q�$��Center=�$	��470��$��5��.������ " ��.���  �@J�Effect   $	 10Q�$	
 320Q�$
 Gray��$	 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -   $ txtBrojZiroRacuna��$��	0,420,0,0q�$	��Top=�$ Broj žiro računa��$ 18��$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$��Broj žiro računa��$��Center=�$��0q�$��Center=�$	��470��$��6��.������ " ��.���  �@J�Effect   $	 10Q�$	
 320Q�$
 Gray��$	 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -   $ txtZastupnik��$��	0,504,0,0q�$	��Top=�$ 	Zastupnik��$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$��	Zastupnik��$��Center=�$��0q�$��Center=�$	��470��$��7��.������ " ��.���  �@J�Effect   $	 10Q�$	
 320Q�$
 Gray��$	 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -   $��	0,608,0,0q�$	��Top=�$��70��
�������$��0q�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��30(�$��Right=�$	��226��$��9�� J� Effect   $	 10Q�$	
 320Q�$
 Gray��$	 0.5Q�$ 30Q����� " ��.���  � ��
 �  ����  � ��
 �������  � �� �� " ��.R��� #��z��#��z��#��z��$ 15��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#F73B3BP�  � ��$
 True��. ���  � �� �#D32F2F.���� $��Nazad��$��30(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Center=�$��Center=��� -	   $��	0,608,0,0q�$	��Top=�$��70��$��0q�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��30(�$
��Left=�$	��226��$��8��   $	 10Q�$	
 320Q�$
 Gray��$	 0.5Q�$ 30Q����� " ��.���  � ��
 � �����  � ��
 �   ���  � �� �� " ��.R��� #��z��#��z��#��z��$ 15��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#FFB300P�  � ��$
 True��. ���  � �� �#CC7700.���� $��Dodaj firmu��$��30(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Center=�$��Center=��� -
   $��greska��$#��Molimo vas popunite sva polja��$��18(�
���  ��$y�	Collapsed=�$��Center=�$��Center=�$��	0,500,0,0q�