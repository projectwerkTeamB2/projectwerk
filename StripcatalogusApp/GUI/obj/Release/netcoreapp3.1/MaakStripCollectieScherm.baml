   M S B A M L   `   `   `  ����   GUI"    GUI.MaakStripCollectieScherm   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$   Nieuwe collectie toevoegen��$	��505��$
��830 �� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType �� Property �� Value��%u   '��       �� " ��.���  � ��$ 18                     (���  � ��$ Calibri)���  � ��$
 Bold"�.��� ���#E9C46A.+��� -    ��Name$ ExtraInfo_TextBox��$��14(�$
��Left=�$��	426,0,0,0q�$
��Wrap=�$��	TextBlock��$��Center=�$	��271��$	��373���� ���#81b29a$
��Left=�$	��404��$��-5,5,0,0q�
���   �$	��Top=�$	��812��$��8��$��7��$��1���� ���#4A203B$
��Left=�$	��407��$��-2,2,0,0q�$	��Top=�$	��823���� 
�������$��Center=�$	��383��$��0,11,0,0q�$	��Top=�$	��825�� �� RadiusY$
 13.5��	 �� RadiusX$
	 13.5��
 J� RenderTransformOrigin$
 0.5,0.5&�z�V� .~��� ��  �� AngleX$ 0Q��� T�  T� X$ 0Q��� $-��'Laten we een nieuwe collectie toevoegen��$��Black"�$��32(�$
��Left=�$��	45,20,0,0q�$	��Top=��� $?��9( Vul hieronder de gegevens van de nieuwe strip in aub. )��$
��Left=�$��	45,73,0,0q�$	��Top=��� $
��Left=�$��/Images/Text.png��$	��522��$��-63,110,0,0q�$	��Top=�$	��560���� -      ButtonStyle#��[  $��	Annuleren��$
��Left=�$��626,414,0,0q�$	��Top=�$	��148��$��34�����#902C14�� -   #��[  $��strip aanmaken��$
��Left=�$��282,414,0,0q�$	��Top=�$	��288��$��34���� $
��Left=�$��/Images/BoomIMG.png��$��94��$��736,386,0,0q�$	��Top=�$��95���� -    ��Name$ TextBox_titel��$
��Left=�$��205,164,0,0q�$�� �� �� TextWrapping$
 Wrap=�$	��Top=�$	��152��$��26���� $
��Left=�$��
49,168,0,0q�$��Strip collectie titel:��$
��Wrap=�$	��Top=��� -   $ 
TextBox_nr��$
��Left=�$��205,247,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��152��$��26���� $
��Left=�$��
49,249,0,0q�$��Nummer:��$
��Wrap=�$	��Top=��� -    ��Name$ TextBox_uitgeverij��$
��Left=�$��205,207,0,0q� �� Text$  ��$	��Top=�$	��152��$��26������ .R��� ���� *Naam+�� $
��Left=�$��
49,205,0,0q�$��Uitgeverij:��$
��Wrap=�$	��Top=��� $$��( U kunt meerdere selecteren )��$
��Left=�$��433,121,0,0q�$	��Top=��� -    ��Name$ TextBox_Strips��$
��Left=�$��438,152,0,0q�$	��Top=�$	��346��$	��214������ .R���  �� Orientation$ 
Horizontal=�.+��� -	    d� 	IsChecked �� *	Ischecked+ �� Mode$ TwoWay=��� ���� *
StripTitel+�� $
��Left=�$��438,104,0,0q�$��	Strip(s):��$
��Wrap=�$	��Top=�