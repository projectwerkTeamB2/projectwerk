   M S B A M L   `   `   `  ����?  ;JSON, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	   -   5          � Title$  Json inreader��5   	   $	��450��6   $	��800��6,   ���#fadcaa.��5      � .+�5   
   �� $��15q�6   ���#794c746>   �� 5   
   $��Center=�6   ���#b2deec$��60��6@   $��0,23,0,0q�6L   ���#794c74$	��Top=�6p   $	��800��6�   �� 5   
   -   5        $��
Hoofdlabel��5      $��Normal"�6"   $��Center=�66   
����=H�$��25(�6v   $1��+Laad uw Json in en wij updaten uw databank.��6�   $��
1,23,1,338q�6�   $��Segoe UI Black)�6�   �� 5   
   -   5        $��FileNameTextBox��5   >   $
��Left=�5      $��27��6-   $��	50,96,0,0q�69    �� TextWrapping$
 Wrap=�6L   $�� ��5      $	��Top=�6   $	��494��62   6>   �� 5   
   -   5         ��Name$ BrowseButton��5      $��Browse a file��6'   $
��Left=�6?   $��
549,96,0,0q�5      $	��Top=�6%   $	��112��6=    J� RenderTransformOrigin$ 1.047,0.821&�5      $��27��65   �� 5   
   -   5        $��
TextBlock1��5       $
��Left=�5      $��58��6/   $��
50,128,0,0q�6;   $
��Wrap=�5      $�� ��6(   $	��Top=�60   $	��416��5      6    � 5   
   -   5        $��pbStatus��5   u   $	��320��6   $��35��6#    � Minimum$ 0Q�6/   $��	0,282,0,0q�6�   $	��Top=�6�   $��Center=�6�    � Value 6<   �� *x+5!      �� 5"   
   -   5        $��pbStatusTEXTBLOCK��5"      $��Center=�6�   $	��Top=�6�   $��	0,292,0,0q�6�   ��6-   ��  �� ElementName$ pbStatus�� �� Path$ Value� �� StringFormat$ {0:0} strips bewerkt��6�   �� 5$   
   -   5        $��NaarDBLabel��5$      $��Center=�6$   
����=H�$��20(�6d   $3��-Wenst u met deze strips, uw databank updaten?��6r   $��0,186,2,187q�6�   �� 5&   
   -	   5        $��NaarDBButton��5&      $��Naar databank versturen��6%   $��Center=�6G   ���#b2deec$��	0,239,0,0q�5'      $	��Top=�6$   $	��228��6<   $ 1.047,0.821&�5(      $��33��65   �� 5+   
   -
   5        $��VanDBButton��5+      $(��"Databank naar text bestand zetten?��6$   $��Center=�6Q   ���#b2deec$��	0,344,0,0q�5,      $	��228��6$   $ 1.047,0.821&�5-      $��33��65   $	��Top=�6A   �� 5.   
   -   5        $��NaarDBButtonKeuze��5.      $#��Json naar Databank versturen?��6*   $��Center=�6R   ���#b2deec$��	0,344,0,0q�5/      $	��228��6$   $ 1.047,0.821&�50      $��33��65   $	��Top=�6A   $y�	Collapsed=�6Y   �� 53   
   -   5        $��
TextBlock2��55       $
��Left=�53      $��29��6/   $��
50,157,0,0q�6;   $
��Wrap=�54      $	��Top=�6)   $	��349��55      6    56      57      