   M S B A M L   `   `   `  ����D  @TrelloWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TrelloWPF	TrelloWPF  5   	       TrelloWPF.AddTask   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TrelloWPF     5   	     � Title$  AddTask��5   	   $	��510��6   $	��524��6&   $��18(�62    � 
ResizeMode$ NoResize=�6@   .��5	      � ���	#FFE0AA09 � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� $��
DeadLine :��6   $
��Left=�6%   $��	10,10,0,0q�6@   $	��Top=�6S    J� RenderTransformOrigin$ 0.684,1.753&�6k   $��34��6�   $��93��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dp_deadline��5      $
��Left=�6(   $��
108,12,0,0q�6C   $	��Top=�6W   $	��203��6o   $��32��6{   �� 5   
   $��Note :��6   $
��Left=�6!   $��9,61,0,0q�6<   $	��Top=�6N   $��93��6f   �� 5   
   -   5        $	��Add��5   #   $
��Left=�61   $��	9,432,0,0q�6L   $	��Top=�6_   $	��130��6w   $��30��6�   �� 5   
   -   5        $��Cancel��5   &   $
��Left=�67   $	��Top=�6R   $	��129��6j   $��30��6v   $��379,432,0,0q�6�   �� 5   
   -   5        $��tb_note��5      $	��327��6!   $��10,100,10,0q�6.    �� TextWrapping$
 Wrap=�6C   $��Stretch=�6W    �� AcceptsReturn . $	��Top=�6�   ���	#FFF9EBBB6�   5      5      