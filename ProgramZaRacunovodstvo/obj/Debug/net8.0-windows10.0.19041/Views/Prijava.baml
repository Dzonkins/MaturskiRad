   M S B A M L   `   `   `  ����Q  MProgramZaRacunovodstvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ProgramZaRacunovodstvo.ViewModels!ProgramZaRacunovodstvo.ViewModels  5      $    ProgramZaRacunovodstvo.Prijava   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      ;local/clr-namespace:ProgramZaRacunovodstvo.ViewModels  5      .��5      � $
��auto��6   $
��auto��5        � ColumnDefinitions  5	   
   �� 5
      $��* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�5   "   .��5      �  � Color$ 	#FF223FFF��6    � Offset$ 1Q�5      � 5      $ 	#FF4FBBFF��6   5      .+�5   
   � $��Center=�6   $��Center=�5      .+�5      �� $��Prijava��6   $��40(�5      $1��+pack://application:,,,/Fonts/#Poppins Light)�5      
�������$��207,-40,207,540q�5        Wpf.Ui.Controls.Button  5      -   5        $��Center=�5      $��	0,381,0,0q�5       $	��Top=�5!      $��70��5"      $	��470��5#      $��0q�5$      $1��+pack://application:,,,/Fonts/#Poppins Light)�5%      $��30(�5&         CornerRadius$ 15��5(      $��10q�5)      $��3��5*       J� Effect 5+      3  -System.Windows.Media.Effects.DropShadowEffect  5,         ShadowDepth$ 10Q�6'      	Direction$	 320Q�5-   '   	   Color$
	 Gray��5.   '   
   Opacity$	
 0.5Q�5/   '      
BlurRadius$ 30Q�50   '   ��52      �� 53       �� 
TargetType"  6   .�54      ��  �� Property � �� �� Value
 � ���55   !   �� 56       � ��
 �   �57   !   �� 58       � �� 59      �� 5:   "    �� 
TargetType" ��62   .R�5;   &   �� #��z��6-   #��z��5<   -   #��z��5=   -    �� CornerRadius$ 15��5>   -   ._�5?   *   �� $��Center=�6;   $��Center=�5@   ;   5A   '    �� Triggers 5B   &   P� 5C   *    P� Property �@J�IsMouseOver P� Value$
 True��5D   2   . �5E   .   ��  � �� �#FFB3005F   5   5G   +   P� 5I   *    � ��$
 True��5J   2   . �5K   .   ��  � �� �#CC77005L   5   5M   +   5O   #   5Q      5R      .��5T      �� $��
Prijavi se��6   $��30(�5U      $1��+pack://application:,,,/Fonts/#Poppins Light)�5V      $��Center=�5W      $��Center=�5X      
���   �5Y      5Z        5\      -   5        $��Center=�5\      $��	0,467,0,0q�5]      $	��Top=�5^      $��70��5_      $	��470��5`      $��0q�5a      $1��+pack://application:,,,/Fonts/#Poppins Light)�5b      $��30(�5c      $ 15��5e      $��10q�5f      $��4��5g       5h        5i      $ 10Q�6'   $	 320Q�5j   '   $
	 Gray��5k   '   $	
 0.5Q�5l   '   $ 30Q�5m   '   ��5o      �� 5p      "  6   .�5q      ��  � ��
 � ���5r   !   �� 5s       � ��
 �   �5t   !   �� 5u       � �� 5v      �� 5w   "   " ��62   .R�5x   &   �� #��z��6-   #��z��5y   -   #��z��5z   -   $ 15��5{   -   ._�5|   *   �� $��Center=�6;   $��Center=�5}   ;   5~   '    5   &   P� 5�   *    �@J�IsMouseOver$
 True��5�   2   . �5�   .   ��  � �� �#FFB3005�   5   5�   +   P� 5�   *    � ��$
 True��5�   2   . �5�   .   ��  � �� �#CC77005�   5   5�   +   5�   #   5�      5�      .��5�      �� $��Registruj se��6   $��30(�5�      $1��+pack://application:,,,/Fonts/#Poppins Light)�5�      $��Center=�5�      $��Center=�5�      5�      �� 5�      -   5        $��txtPasswordPlaceholder��5�      $��Lozinka��5�      ���	#FF616161$��24(�5�      $1��+pack://application:,,,/Fonts/#Poppins Light)�5�       J� IsHitTestVisible$ False��5�      $��Center=�5�       K� ZIndex$ 1��5�      $��37,292,393,237q�5�      G� 5�      -   5        $��txtPassword��5�      $��Center=�5�      $	��470��5�      $��70��5�      $��24(�5�      $1��+pack://application:,,,/Fonts/#Poppins Light)�5�      
���   �$��Center=�5�      $��0q�5�      $��0,275,0,220q�5�      ���	#8CFFFFFF G� PasswordChar$	 ●��5�      $��2��5�      ��5�      �� 5�      " G�6   .�5�      ��  �@J�Effect 5�        5�   "   $ 10Q�63   $	 320Q�5�   3   $
	 Gray��5�   3   $	
 0.5Q�5�   3   $ 30Q�5�   3   5�      �� 5�       � �� 5�      �� 5�   "   " G�62   .R�5�   &   �� $ 15��6-   $��0q�5�   -   
������ #��z��5�   -    �� Padding$ 10q�5�   -   ._�5�   *   ��  ��Name$ PART_ContentHost��67   $��Center=�5�   7   5�   '   5�   #   5�      5�      5�      �� 5�      -   5        $��txtPasswordVisible��5�      $��Center=�5�      $	��Top=�5�      $	��470��5�      $��70��5�      $��24(�5�      $1��+pack://application:,,,/Fonts/#Poppins Light)�5�      
���   �$��Center=�5�      $��0q�5�      $��	0,275,0,0q�5�      $y�	Collapsed=�5�      $��2��5�      .��6#   ��5�      �� 5�      " ��6   .�5�      ��  �@J�Effect 5�        5�   "   $ 10Q�63   $	 320Q�5�   3   $
	 Gray��5�   3   $	
 0.5Q�5�   3   $ 30Q�5�   3   5�      5�      .��5�   !   ��5�      �� 5�      " ��6&   .R�5�      �� $ 15��6!   $��0q�5�   !   
������ $ 10q�5�   !   ���	#8CFFFFFF._�5�      �� $ PART_ContentHost��6+   $��Center=�5�   +   5�      5�      .��5�   $   5�        Wpf.Ui.Controls.TextBox  5�      -   5        $��txtEmail��5�      $��Center=�5�      $��	0,192,0,0q�5�      $	��Top=�5�      $	��470��5�      $��70��5�      $��24(�5�      $1��+pack://application:,,,/Fonts/#Poppins Light)�5�      ���	#FF616161$��Email��5     $��Center=�5     $��0q�5     $��1��5     .��6&   ��5     �� 5     " ��6   .�5	     ��  �@J�Effect 5
       5  "   $ 10Q�63   $	 320Q�5  3   $
	 Gray��5  3   $	
 0.5Q�5  3   $ 30Q�5  3   5     5     .��5  !   ��5     �� 5     " ��6&   .R�5     �� $ 15��6!   $��0q�5  !   
������ $ 10q�5  !   ���	#8CFFFFFF._�5     �� $ PART_ContentHost��6+   $��Center=�5  +   5     5     .��5  $   5      �� 5$     $��0,48,0,0q�6   $��/slike/Vector.png��5%     $
��Fill=�5&     $��Center=�5'     $	��120��5(     $	��120��5)     $	��Top=�5*     �� 5+     -   5        $��greska��5+     $ ��Netačan email ili lozinka��5,     $��18(�5-     
���  ��$y�	Collapsed=�5/     $��Center=�50     $��Center=�51     $��	0,155,0,0q�52       53     -   5        $��46��53     $��32��54     $��447,294,52,239q�55     $��0q�57     $��False��59     ��56     Z� ��5:     �� 5;     " ��6&   .R�5<     �� 
������ $��0q�5=  !   ._�5>     �� $��40��6$   $��26��5?  $   $��/slike/sifra.png��5@  $   $
��Fill=�5A  $    J� RenderTransformOrigin$ 0.5,0.5&�5B  $   5C     5D     5F     5G     5H     5I     