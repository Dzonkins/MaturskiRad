   M S B A M L   `   `   `  ���� Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ProgramZaRacunovodstvo.ViewModels!ProgramZaRacunovodstvo.ViewModels  2    ,ProgramZaRacunovodstvo.Views.DodajPravnoLice   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:ProgramZaRacunovodstvo.ViewModels     M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml    � DataContext  @  :ProgramZaRacunovodstvo.ViewModels.DodajPravnoLiceViewModel  .���� $
��Auto=�$��1��.��� 
������� � RowDefinitions �� $	��120 ��� $��* ��� $
��Auto �.+��� $��Dodaj pravno lice��$1��+pack://application:,,,/Fonts/#Poppins Light)�$��28(�$��
20,40,0,20q�$	��759��$
��Left=�$	��Top=��� $��1�����#ebeced$��Center=� �� Padding$ 60q�$	��720��$	��Top=�$��	0,50,0,50q� �� CornerRadius$ 20��._��  �� $
��Auto ��� $
��Auto �.+��� $��0��.+�  Wpf.Ui.Controls.TextBox  $��50��$
��1000��$
��1000��$��Center=�$	��Top=�$��0,0,0,20q�   PlaceholderText$ Naziv��$��Center=�$��1������ *Naziv+  -   $��50��$
��1000��$
��1000��$��Center=�$	��Top=�$��0,0,0,20q� �� 	MaxLength$ 9��$	 PIB��$��Center=�$��2������ *Pib+  -   $��50��$
��1000��$
��1000��$��Center=�$	��Top=�$��0,0,0,20q�$ 8��$ Matični broj��$��Center=�$��3������ *MaticniBroj+  $��50��$
��1000��$
��1000��$��Center=�$	��Top=�$��0,0,0,20q�$
 Grad��$��Center=�$��4������ *Grad+  $��50��$
��1000��$
��1000��$��Center=�$	��Top=�$��0,0,0,20q�$ Adresa��$��Center=�$��5������ *Adresa+  -   $��50��$
��1000��$
��1000��$��Center=�$	��Top=�$��0,0,0,20q�$ 18��$ Broj računa��$��Center=�$��6������ *Racun+  $��50��$
��1000��$
��1000��$��Center=�$	��Top=�$��0,0,0,0q�$ 	Zastupnik��$��Center=�$��7������ *	Zastupnik+  Wpf.Ui.Controls.TextBlock  $��0,20,0,0q�
���  ��$��Center=�$��17(�$1��+pack://application:,,,/Fonts/#Poppins Light)����� *Greska+� $��1��.+�  Wpf.Ui.Controls.Button  $��2��$��0��$��2��$	��400��$��50��$��Bottom=�$
��Left=�$��0,20,0,0q�$��0q�
�������$1��+pack://application:,,,/Fonts/#Poppins Light)�$��15(�$��8������ *	Sacuvaj+ J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 10Q�   	Direction$	 320Q�	   Color$
	 Gray��
   Opacity$	
 0.5Q�   
BlurRadius$ 30Q�����  �� 
TargetType" ��.���  �� Property � �� �� Value �#4CAF50��  � �� ��  �� 
TargetType" ��.R��� #��z��#��z��#��z��$ 13��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#81C784P�  � ��$
 True��. ���  � �� �#388E3C.���� $��Sačuvaj��$��22(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Center=�$��Center=�  -   $	��400��$��50��$��Bottom=�$��Right=�$��0,0,0,0q�$��0q�
�������$1��+pack://application:,,,/Fonts/#Poppins Light)�$��15(�$��9��   $ 10Q�$	 320Q�$
	 Gray��$	
 0.5Q�$ 30Q����� " ��.���  � ��
 �  ����  � �� �� " ��.R��� #��z��#��z��#��z��$ 13��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#F73B3BP�  � ��$
 True��. ���  � �� �#D32F2F.���� $��Nazad��$��22(�$1��+pack://application:,,,/Fonts/#Poppins Light)�$��Center=�$��Center=�