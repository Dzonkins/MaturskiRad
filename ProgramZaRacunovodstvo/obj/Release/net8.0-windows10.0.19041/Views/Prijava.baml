   M S B A M L   `   `   `  ���� Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ProgramZaRacunovodstvo.ViewModels!ProgramZaRacunovodstvo.ViewModels  $    ProgramZaRacunovodstvo.Prijava   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  ;local/clr-namespace:ProgramZaRacunovodstvo.ViewModels  .��� $
��auto��$
��auto��  � ColumnDefinitions  �� $��* �����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF223FFF�� � Offset$ 1Q�� $ 	#FF4FBBFF��.+�� $��Center=�$��Center=�.+��� $��Prijava��$��40(�$1��+pack://application:,,,/Fonts/#Poppins Light)�
�������$��207,-40,207,540q�  Wpf.Ui.Controls.Button  -   $��Center=�$��	0,381,0,0q�$	��Top=�$��70��$	��470��$��0q�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��30(�   CornerRadius$ 15��$��10q�$��3�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 10Q�   	Direction$	 320Q�	   Color$
	 Gray��
   Opacity$	
 0.5Q�   
BlurRadius$ 30Q�����  �� 
TargetType"  .���  �� Property � �� �� Value
 � �����  � ��
 �   ���  � �� ��  �� 
TargetType" ��.R��� #��z��#��z��#��z�� �� CornerRadius$ 15��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#FFB300P�  � ��$
 True��. ���  � �� �#CC7700.���� $��
Prijavi Se��$��30(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Center=�$��Center=�
���   �  -   $��Center=�$��	0,467,0,0q�$	��Top=�$��70��$	��470��$��0q�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��30(�$ 15��$��10q�$��4��   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q����� "  .���  � ��
 � �����  � ��
 �   ���  � �� �� " ��.R��� #��z��#��z��#��z��$ 15��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#FFB300P�  � ��$
 True��. ���  � �� �#CC7700.���� $��Registruj Se��$��30(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Center=�$��Center=��� -   $��txtPasswordPlaceholder��$��Lozinka�����	#FF616161$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)� J� IsHitTestVisible$ False��$��Center=� K� ZIndex$ 1��$��37,292,393,237q�G� -   $��txtPassword��$��Center=�$	��470��$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)�
���   �$��Center=�$��0q�$��0,275,0,220q����	#8CFFFFFF G� PasswordChar$	 ●��$��2������ " G�.���  �@J�Effect   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q���  � �� �� " G�.R��� $ 15��$��0q�
������ #��z�� �� Padding$ 10q�._���  ��Name$ PART_ContentHost��$��Center=��� -   $��txtPasswordVisible��$��Center=�$	��Top=�$	��470��$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)�
���   �$��Center=�$��0q�$��	0,275,0,0q�$y�	Collapsed=�$��2��.������ " ��.���  �@J�Effect   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.��  Wpf.Ui.Controls.TextBox  -   $��txtEmail��$��Center=�$��	0,192,0,0q�$	��Top=�$	��470��$��70��$��24(�$1��+pack://application:,,,/Fonts/#Poppins Light)����	#FF616161$��Email��$��Center=�$��0q�$��1��.������ " ��.���  �@J�Effect   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q�.������ " ��.R��� $ 15��$��0q�
������ $ 10q����	#8CFFFFFF._��� $ PART_ContentHost��$��Center=�.���� $��0,48,0,0q�$��/slike/Vector.png��$
��Fill=�$��Center=�$	��120��$	��120��$	��Top=��� -   $��greska��$ ��Netačan email ili lozinka��$��18(�
���  ��$y�	Collapsed=�$��Center=�$��Center=�$��	0,155,0,0q�  -   $��46��$��32��$��447,294,52,239q�$��0q�$��False����Z� ���� " ��.R��� 
������ $��0q�._��� $��40��$��26��$��/slike/sifra.png��$
��Fill=� J� RenderTransformOrigin$ 0.5,0.5&�