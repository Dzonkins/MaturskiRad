   M S B A M L   `   `   `  ���� Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProgramZaRacunovodstvo.ViewsProgramZaRacunovodstvo.Views  /    )ProgramZaRacunovodstvo.Views.Registracija   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:ProgramZaRacunovodstvo.Views     .��� $
��auto��$
��auto��  � ColumnDefinitions  �� $��* �����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF223FFF�� � Offset$ 1Q�� $ 	#FF4FBBFF��.+�� $��Center=�$��Center=� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��	0,550,0,0q�$	��Top=�$��70��$��0q�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��30(�$��Center=�$	��470��$��8�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 10Q�   	Direction$	 320Q�	   Color$
	 Gray��
   Opacity$	
 0.5Q�   
BlurRadius$ 30Q�����  �� 
TargetType" ��.���  �� Property � �� �� Value
 � �����  � ��
 �   ���  � �� ��  �� 
TargetType" ��.R��� #��z��#��z��#��z�� �� CornerRadius$ 15��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#FFB300P�  � ��$
 True��. ���  � �� �#CC7700.���� $��Kreiraj nalog��$��30(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Center=�$��Center=��� -   $��txtPasswordPlaceholder��$��Lozinka�����	#FF616161$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)� J� IsHitTestVisible$ False�� K� ZIndex$ 1��$��36,468,393,235q�$��86��G� -   $��txtPassword��$	��Top=�$��70��$	��470��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)�
���   �$��Center=�$��0q����	#8CFFFFFF$��	0,451,0,0q�$��7������ " G�.���  � �� �	#8CFFFFFF��  � ��
 �   ���  �@J�Effect   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q���  � �� �� " G�.R��� $ 15��$��0q�
������ ���	#8CFFFFFF �� Padding$ 10q�._���  ��Name$ PART_ContentHost��$��Center=��� -   $��txtPasswordVisible��$	��Top=�$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)�
���   �$��Center=�$��0q�$��1��$��	0,451,0,0q�$��Center=�$	��470��$y�	Collapsed=�$��7��.������ " ��.���  �@J�Effect   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -   $��txtEmail��$��	0,367,0,0q�$	��Top=�$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$��Email��$��Center=�$��0q�$��Center=�$	��470��$��6��.������ " ��.���  �@J�Effect   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -   $��46��$��32��$��427,470,42,0q�$	��Top=�$��0q�$��False����Z� ���� " ��.R��� 
������ $��0q�._��� $��40��$��26��$��/slike/sifra.png��$
��Fill=� J� RenderTransformOrigin$ 0.5,0.5&��� -    ��Name$ txtIme��$��22,30,267,0q�$	��Top=�$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$	��Ime��$��Center=�$��0q�$��1��$	��226��$��1��.������ " ��.���  �@J�Effect   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -   $ 
txtPrezime��$��268,30,23,0q�$	��Top=�$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$��Prezime��$��Center=�$��0q�$��1��$	��224��$��2��.������ " ��.���  �@J�Effect   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -	   $ txtJMBG�� �� 	MaxLength$ 13��$��	0,115,0,0q�$	��Top=�$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$
��JMBG��$��Center=�$��0q�$��Center=�$	��470��$��3��.������ " ��.���  �@J�Effect   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -
   $ 	txtAdresa��$��	0,283,0,0q�$	��Top=�$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$��Adresa��$��Center=�$��0q�$��Center=�$	��470��$��5��.������ " ��.���  �@J�Effect   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -   $ txtGrad��$��	0,199,0,0q�$	��Top=�$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$
��Grad��$��Center=�$��0q�$��Center=�$	��470��$��4��.������ " ��.���  �@J�Effect   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� -   $��
0,643,0,33q�
�������$��0q�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��30(�$��Center=�$	��470��$��70��$��9��   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q����� " ��.���  � ��
 �  ����  � ��
 �������  � �� �� " ��.R��� #��z��#��z��#��z��$ 15��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#F73B3BP�  � ��$
 True��. ���  � �� �#D32F2F.���� $��Odustani��$��30(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Center=�$��Center=��� -   $��greska��$ ��Netačan email ili lozinka��$��18(�
���  ��$y�	Collapsed=�$��Center=�$��Center=�$��	0,323,0,0q�