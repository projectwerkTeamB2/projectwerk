   M S B A M L   `   `   `  ����   GUI    GUI.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=� � Title$ Strip Applicatie��$	��650��$
��1210��.��� ���#E9C46A.+��� -   $��	plusstrip��   ButtonStyle#��[  $ ��Een nieuwe strip toevoegen��$
��Bold"�$
��Left=�$��	9,559,0,0q�$	��217��$��40��$	��Top=��� -   #��[  $��Zoeken��
���i��$
��Left=�$��1061,12,0,0q�$	��Top=�$	��127��$��29���� -   $��RESET��$
��Left=�$��1097,56,0,0q�$	��Top=�$��90��$��28���� 
���?���$��25(�$��Comic Sans MS)�$
��Bold"�$#��Strip Applicatie
van groep B2��$
��Left=�$��11,2,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -     Name$ StripDataGrid��   SelectionMode$ Single=�$��242,87,0,20q�$
��Left=�$	��946���� -    ��Name$ WonderWomanImage��$
��Left=�$	��416��$��	22,77,0,0q�$	��Top=�$	��433��$��Images/WonderWIMG.png�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~���  �� ScaleX$ -1Q��� ��  �� Angle$ -3.204Q�T� �� -   $��stripBewerken_button��#��[  $%��Geselecteerde strip bijwerken ?��
���i��$
��Left=�$��
242,14,0,0q�$	��Top=�$	��220��$��34���� -   $!��NaarStripCollections_button��#��[  $!��Stripcollections bekijken ?��
���/kU�$
��Left=�$��
242,53,0,0q�$	��Top=�$	��187��$��34���� -	   $��NaarStrip_button��#��[  $y�	Collapsed=�$��Strips bekijken ?��
���/kU�$
��Left=�$��
242,53,0,0q�$	��Top=�$	��187��$��34���� -
   #��[  $��+ Strip collectie��$
��Bold"�$
��Left=�$��	7,408,0,0q�$	��142��$��33��$	��Top=��� 
���**��$��15(�$��Comic Sans MS)�$
��Bold"�$��Toevoegen :��$
��Left=�$��	7,378,0,0q�$	��Top=�	� -   $��RadioBtnStripid��	 	� 	GroupName$	 Search��
 d� 	IsChecked$

 TrueY�$��Strip id��$
��Left=�$��
799,67,0,0q�$	��Top=�	� -   $��RadioBtnStriptittel��$	 Search��$��Strip tittel��$
��Left=�$��
799,44,0,0q�$	��Top=�	� -   $��RadioBtnReeks��$	 Search��$��Reeks��$
��Left=�$��
909,44,0,0q�$	��Top=�	� -   $��RadioBtnColl��$	 Search��$��Collectie tittel��$
��Left=�$��
989,45,0,0q�$	��Top=�	� -   $��RadioBtnAuteur��$	 Search��$��Auteur��$
��Left=�$��
909,67,0,0q�$	��Top=�	� -   $��RadioBtnUitgeverij��$	 Search��$��
Uitgeverij��$
��Left=�$��
990,67,0,0q�$	��Top=��� -   $��SearchTextBox��  placeHolder#��[ 
 � Tag$  Vul hier de zoek waarde in��$��29��$
��Left=�$��
798,10,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��258���� -   $��	bin_image��$��
662,14,0,0q�$
��Fill=�$
��Left=�$��72��$��61��$	��Top=�����  �� 
TargetType" ��.���  �� Property � �� �� Value$ Images/bin.png�� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � ��$ Images/bin2.png���� -   $��	plusreeks��#��[  $
��Left=�$��+ Reeks��$
��Bold"�$
��Left=�$��	9,448,0,0q�$	��140��$��30��$	��Top=��� -   $��plusuitgeverij��#��[  $
��Left=�$��+ Uitgeverij��$
��Bold"�$
��Left=�$��	9,519,0,0q�$	��140��$��30��$	��Top=��� -   $��
plusauteur��#��[  $
��Left=�$��+ Auteur��$
��Bold"�$
��Left=�$��	9,483,0,0q�$	��140��$��30��$	��Top=�