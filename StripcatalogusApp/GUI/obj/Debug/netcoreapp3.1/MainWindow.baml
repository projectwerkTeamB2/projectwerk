   M S B A M L   `   `   `  ����  GUI    GUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ Strip Applicatie��5
   	   $	��650��6"   $
��1210��6/   .��5      � ���#E9C46A.+�5   
   �� -   5        $��	plusstrip��5         ButtonStyle#��[  6"   $ ��Een nieuwe strip toevoegen��6G   $
��Bold"�6l   $
��Left=�6~   $��	9,559,0,0q�6�   $	��217��6�   $��40��6�   $	��Top=�6�   �� 5   
   -   5        #��[  5      $��Zoeken��67   
���i��$
��Left=�6_   $��1061,12,0,0q�6z   $	��Top=�6�   $	��127��6�   $��29��6�   6�   �� 5   
   -   5        $��RESET��5      $
��Left=�6#   $��1097,56,0,0q�6>   $	��Top=�6S   $��90��6k   $��28��6v   6�   �� 5   
   
���?���$��25(�6#   $��Comic Sans MS)�61   $
��Bold"�5      $#��Strip Applicatie
van groep B2��6   $
��Left=�6@   $��11,2,0,0q�6[   $	��Top=�6m   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ StripDataGrid��5         SelectionMode$ Single=�6+   $��242,87,0,20q�6B   $
��Left=�6W   $	��946��6r   6~   �� 5   
   -   5         ��Name$ WonderWomanImage��5      $
��Left=�6*   $	��416��6E   $��	22,77,0,0q�6R   $	��Top=�6e   $	��433��6}   $��Images/WonderWIMG.png��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      ��  �� ScaleX$ -1Q�6%   �� 5      �� 5       �� Angle$ -3.204Q�6&   T� 5      5      5       �� 5!   
   -   5        $��stripBewerken_button��5!   7   #��[  6   $%��Geselecteerde strip bijwerken ?��6S   
���i��$
��Left=�6�   $��
242,14,0,0q�6�   $	��Top=�6�   $	��220��6�   $��34��6�   6�   �� 5"   
   -   5        $!��NaarStripCollections_button��5"   7   #��[  6   $!��Stripcollections bekijken ?��6Z   
���/kU�$
��Left=�6�   $��
242,53,0,0q�6�   $	��Top=�6�   $	��187��6�   $��34��6�   6�   �� 5#   
   -	   5        $��NaarStrip_button��5#   7   #��[  6   $y�	Collapsed=�6O   $��Strips bekijken ?��6f   
���/kU�$
��Left=�6�   $��
242,53,0,0q�6�   $	��Top=�6�   $	��187��6�   $��34��6�   6�   �� 5$   
   -
   5        #��[  5$      $��+ Strip collectie��67   $
��Bold"�6S   $
��Left=�6e   $��	7,408,0,0q�6�   $	��142��6�   $��33��6�   $	��Top=�6�   �� 5'   
   
���**��$��15(�6$   $��Comic Sans MS)�62   $
��Bold"�5(      $��Toevoegen :��6   $
��Left=�6*   $��	7,378,0,0q�6E   $	��Top=�6X   	� 5*   
   -   5        $��RadioBtnStripid��5*   )   	 	� 	GroupName$	 Search��6   
 d� 	IsChecked$

 TrueY�6@   $��Strip id��6Q   $
��Left=�6d   $��
799,67,0,0q�6   $	��Top=�6�   	� 5+   
   -   5        $��RadioBtnStriptittel��5+   *   $	 Search��6   $��Strip tittel��6E   $
��Left=�6\   $��
799,44,0,0q�6w   $	��Top=�6�   	� 5,   
   -   5        $��RadioBtnReeks��5,   )   $	 Search��6   $��Reeks��6>   $
��Left=�6N   $��
909,44,0,0q�6i   $	��Top=�6}   	� 5-   
   -   5        $��RadioBtnColl��5-   )   $	 Search��6   $��Collectie tittel��6=   $
��Left=�6X   $��
989,45,0,0q�6s   $	��Top=�6�   	� 5.   
   -   5        $��RadioBtnAuteur��5.   )   $	 Search��6   $��Auteur��6?   $
��Left=�6P   $��
909,67,0,0q�6k   $	��Top=�6   	� 5/   
   -   5        $��RadioBtnUitgeverij��5/   )   $	 Search��6   $��
Uitgeverij��6C   $
��Left=�6X   $��
990,67,0,0q�6s   $	��Top=�6�   �� 50   
   -   5        $��SearchTextBox��50   8     placeHolder#��[ 6   
 � Tag$  Vul hier de zoek waarde in��6M   $��29��6o   $
��Left=�6{   $��
798,10,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��258��6�   �� 52   
   -   5        $��	bin_image��52   '   $��
662,14,0,0q�69   $
��Fill=�6M   $
��Left=�6\   $��72��6w   $��61��6�   $	��Top=�6�   ��53      �� 54       �� 
TargetType" ��6   .�55      ��  �� Property � �� �� Value$ Images/bin.png��6/    �� Triggers 56      P� 57       P� Property �@J�IsMouseOver P� Value$
 True��69   . �58      ��  � ��$ Images/bin2.png��67   59      5;      5=      �� 5?   
   -   5        $��	plusreeks��5?      #��[  6#   $
��Left=�6H   $��+ Reeks��6j   $
��Bold"�6|   $
��Left=�6�   $��	9,448,0,0q�6�   $	��140��6�   $��30��6�   $	��Top=�6�   �� 5@   
   -   5        $��plusuitgeverij��5@      #��[  6(   $
��Left=�6M   $��+ Uitgeverij��6o   $
��Bold"�6�   $
��Left=�6�   $��	9,519,0,0q�6�   $	��140��6�   $��30��6�   $	��Top=�6  �� 5A   
   -   5        $��
plusauteur��5A      #��[  6$   $
��Left=�6I   $��+ Auteur��6k   $
��Bold"�6~   $
��Left=�6�   $��	9,483,0,0q�6�   $	��140��6�   $��30��6�   $	��Top=�6�   5D      5E      