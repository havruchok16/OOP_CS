   M S B A M L   `   `   `  ����A  =CS_4_5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CS_4_5CS_4_5  5   	       CS_4_5.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:CS_4_5     5   	      Text_Editor  � Title#  �   5   	   $	��450��6/   $	��750��6<    � Icon$/ )C:\Users\37544\Desktop\C#\CS_4_5\font.png��6H    � 	Resources 5	       �� Source�� 5
   
   $ /Dictionary1.xaml?�6   %    6:   .��5      � -   5         �Name$ 
LayoutRoot��5       � RowDefinitions 5   
   �� 5      $
��0.1* �6   6,   �� 5      6   �� 5      $
��0.1* �6   6,   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��0.3* �6#   62   �� 5      $
��0.3* �6#   62   �� 5      $
��0.4* �6#   62   �� 5      $
��0.2* �6#   62   �� 5      $
��0.2* �6#   62   �� 5      $
��0.2* �6#   62   �� 5      $
��0.5* �6#   62   �� 5      $
��0.2* �6#   62   �� 5      $
��0.7* �6#   62   �� 5      $
��0.2* �6#   62   �� 5       $
��0.2* �6#   62   �� 5!      $
��0.2* �6#   62   .+�5$      �� -   5         ��Name$
 Save��5$      $��0��6#     Save#���  63   6T   �� 5%      -   5        $
 Open��5%      $��1��6#     Open#���  63   6T   �� 5&      -   5         ��Name$
 Func��5&      $��2��6%   .@�5'      �� -   5        	 ��Name$
	 Copy��5'        Copy#���  6*   6J   �� 5(      -   5        $	 Paste��5(       	 Paste#���  6+   6L   �� 5)      -   5        $
	 Undo��5)        Undo#���  6*   6J   �� 5*      -   5        $		 Cut��5*        Cut#���  6)   6H   5+      �� 5-      -	   5        $ button_I��5-      $��3��6'   $��I��67   $��Italic$�6C   6p   �� 5.      -
   5        $ button_B��5.      $��4��6'   $��B��67   $
��Bold"�6C   6o   �� 5/      -   5        $ button_U��5/      $��5��6'   $��U��67   6]   �� 51      -   5        $
 Font��51      $��6��6%   .@�52      �� $��Arial��6   $��Arial)�6)   6>   �� 53      $��Century Gothic��6   $��Century Gothic)�62   6P   �� 54      $��Georgia��6   $��Georgia)�6+   6B   �� 55      $��Courier New��6   $��Courier New)�6/   6J   �� 56      $��Monotype Corsiva��6   $��Monotype Corsiva)�64   6T   57      �� 59      -   5        $ 	FontColor��59      $��7��6*   .@�5:      �� 
���   �
���   �1116H   �� 5;      
�������
�������2226F   �� 5<      
���  ��
���  ��3336D   �� 5=      
�������
�������4446F   �� 5>      
������
������5556J   �� 5?      
����·�
����·�6666L   5@      �� 5B      $��8��6   $��Center=�6)   $��2q�6D   .+�5C      �� -   5        
 ��Name$
 Slider��5C       � Minimum$ 12Q�6)    � Maximum$ 48Q�66    �� TickPlacement$ BottomRight=�6C    �� TickFrequency$ 2Q�6_    �� IsSnapToTickEnabled .  �� Ticks$&  12,14,16,18,20,22,24,26,28,36,48R�6�   6�   5D      �� 5F      -   5        $	 lan��5F      $��9��6"     ENG#���  62   6l   �� 5H      -   5        $ style��5H      $��10��6&   .@�5I      �� 
����� �
����� �aqua6H   �� 5J      
����i��
����i��piink6O   5K      �� 5M      -   5        $ myButton��5M      $��11��6'   $	��-_-��68   $��30��6F   $��30��6R   
���������5N      �� 5O       �� 
TargetType" ��6&   .R�5P      ��  ��Name$ buttonBorder��6!    �� CornerRadius$ 15��67   #��z��5Q      #��z��5R      #��z��5S      ._�5T      �� #��z��6)   #��z��5U      #��z��5V      #��z��5W      5X       �� Triggers 5Y      P� 5Z       P� Property �@J�IsMouseOver P� Value . . �5[   "   ��  �� Property � �� �� Value$ 10(�6=   �� 5\   "    � ��
 �  ��6?   5]      5_      5a      5b      � 5d   
   $��1��6    5e      �� 5f      6&   .+�5h      �� -   5         ��Name$ MyRichTextBox��5h      $��0��61    �� 	IsEnabled .  � Language$ ru-ru�6]    J� 	AllowDrop . ��5i      ��  �� ElementName$
 Font�� �� Path$
 Text� �� Mode$ OneWay=�  �� TargetNullValue$  Arial��! �� UpdateSourceTrigger$! PropertyChanged=���5j      �� $ Slider��$ Value�$ OneWay=�$  12��$! PropertyChanged=�5k      5l      � 5m   
   $��2��6    5n      �� 5o      $��0.15* �6#   63   �� 5p      $
��0.1* �6#   62   �� 5q      6%   .+�5s      �� -   5        " ��Name$" Symbols��5s   $   $��0��6     Symbols#���  65   6[   �� 5t      -   5        $" Number��5t   $   $��1��6   .��64   067   5u      5v      5w      