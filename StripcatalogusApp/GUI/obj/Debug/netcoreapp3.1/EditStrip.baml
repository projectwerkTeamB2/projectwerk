   M S B A M L   `   `   `  ����  GUI    GUI.EditStrip   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  Strip wijzigen��5   	   $	��505��6    $
��830 ��6-    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5
       � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ 18                     (�6)   �� 5       � ��$ Calibri)�6+   �� 5       � ��$
 Bold"�6+   5      5      .��5      � ���#E9C46A.+�5   
   �� -   5         ��Name$ ExtraInfo_TextBox��5      $��14(�60   $
��Left=�6>   $��	426,0,0,0q�6Y   $
��Wrap=�6l   $��	TextBlock��6�   $��Center=�6�   $	��271��6�   $	��373��6�   �� 5   
   ���#81b29a$
��Left=�6#   $	��404��6>   $��-5,5,0,0q�6K   
���   �$	��Top=�6l   $	��812��6�   $��8��6�   $��7��6�   $��1��6�   �� 5   
   ���#4A203B$
��Left=�6#   $	��407��6>   $��-2,2,0,0q�6K   $	��Top=�6^   $	��823��6v   �� 5   
   
�������$��Center=�6%   $	��383��6B   $��0,11,0,0q�6O   $	��Top=�6a   $	��825��6y    �� RadiusY$
 13.5��6�   	 �� RadiusX$
	 13.5��6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ 0Q�6$   �� 5       T� 5!       T� X$ 0Q�6)   5"      5$      �� 5%   
   $#��Laten we een strip bewerken !��6   $��Black"�68   $��32(�6K   $
��Left=�6Y   $��	45,29,0,0q�6t   $	��Top=�6�   �� 5&   
   $8��2( Vul hieronder de gegevens van de strip in aub. )��6   $
��Left=�6M   $��	45,69,0,0q�6h   $	��Top=�6{   �� 5'   
   $$��( U kunt meerdere selecteren )��6   $
��Left=�69   $��366,114,0,0q�6T   $	��Top=�6i   �� 5)   
   -   5         ��Name$ cancel_update��5)   N      ButtonStyle#��[  6   $��	Annuleren��6:   $
��Left=�6e   $��626,414,0,0q�6�   $	��Top=�6�   $	��148��6�   $��34��6�   ���#902C146�   �� 5*   
   -   5        $ Button_update_confirmed��5*   Q   #��[  6   $��strip Bewerken��68   $
��Left=�6r   $��282,414,0,0q�6�   $	��Top=�6�   $	��288��6�   $��34��6�   6�   �� 5,   
   -   5        $��TextBox_titel��5,   .   $
��Left=�6   $��178,140,0,0q�6C   $�� ��6X    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��152��6�   $��26��6�   �� 5-   
   $
��Left=�6   $��
53,144,0,0q�6/   $��Strip titel:��6C   $
��Wrap=�6W   $	��Top=�6k   �� 50   
   -   5        $��
TextBox_nr��50   .   $
��Left=�6   $��178,176,0,0q�6@   $�� ��6U   $
 Wrap=�6]   $	��Top=�6q   $	��152��6�   $��26��6�   �� 51   
   $
��Left=�6   $��
53,176,0,0q�6/   $��Strip nummer:��6C   $
��Wrap=�6X   $	��Top=�6l   �� 53   
   -   5        $��TextBox_reeks��53   /   $
��Left=�6   $��178,210,0,0q�6D    �� Text$  ��6Y   $	��Top=�6a   $	��152��6y   $��25��6�   ��54      �� 55      .R�56      �� ��6    �� *Naam+57      59      �� 5:   
   $
��Left=�6   $��
53,213,0,0q�6/   $��Strip Reeks:��6C   $
��Wrap=�6W   $	��Top=�6k   �� 5<   
   -   5        $��TextBox_uitgeverij��5<   .   $
��Left=�6   $��178,245,0,0q�6H   $  ��6]   $	��Top=�6f   $	��152��6~   $��26��6�   ��5=      �� 5>      .R�5?      �� ��6    �� *Naam+5@      5B      �� 5C   
   $
��Left=�6   $��
53,245,0,0q�6/   $��Strip Uitgeverij:��6C   $
��Wrap=�6\   $	��Top=�6p   �� 5E   
   -	   5        $��TextBox_auteurs��5F   M   
 � Tag$( "Voor Beeld, Jeff De Voorbeeld, ...��6   $
��Left=�61   $��366,140,0,0q�6d   $	��Top=�6y   $	��408��6�   $	��181��6�   ��5G      �� 5H      .R�5I      ��  �� Orientation$ 
Horizontal=�6!   .+�5J      �� -
   5         d� 	IsChecked 5J   #   ��  �� Path$ 	Ischecked� �� Mode$ TwoWay=�6h   �� 5K      ��6$   �� *Naam+5L      5M      5O      �� 5Z   
   $
��Left=�6   $��
371,97,0,0q�6/   $��
Auteur(s):��6C   $
��Wrap=�6U   $	��Top=�6i   �� 5[   
   $
��Left=�6   $��/Images/BoomIMG.png��6+   $��94��6H   $��736,386,0,0q�6T   $	��Top=�6i   $��95��6�   5^      5_      