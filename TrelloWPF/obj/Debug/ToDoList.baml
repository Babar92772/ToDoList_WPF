   M S B A M L   `   `   `  ����D  @TrelloWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TrelloWPF	TrelloWPF  5   	       TrelloWPF.ToDoList   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QGongSolutions.WPF.DragDrop, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullddurn:gong-wpf-dragdrop  5   	   #localclr-namespace:TrelloWPF  5   	     � Title$  ToDoList��5	   	   $	��615��6   $
��1200��6'    � 
ResizeMode$ NoResize=�64   .��5
      � ���	#FFE0AA09.+�5   
   �� $��To Do��6   $
��Left=�6    $��	161,6,0,0q�6;   $	��Top=�6N   $��18(�6f   $
��Bold"�6t   �� 5   
   -   5        $��lv_todo��5   e   )  #GongSolutions.Wpf.DragDrop.DragDrop   IsDragSource . $
��Left=�6t   $	��470��6�   $��1,45,0,0q�6�   $	��Top=�6�   $	��370��6�    �� SelectionMode$ Single=�6�   ���	#FFF9EBBB   DragHandler 63   �� *ListTasksTodo+ �� View 5      �� 5      .P�5      �� $��
Crea. Date��6%    �� Width$
 70px��69    �� DisplayMemberBinding 6F   �� *
CreateDate+�� 5      $
��Task��6%   $ 230px��63    6A   �� *Note+�� 5      $��DeadLine��6%   $
 70px��67    6D   �� *
DeadLine+5      5      �� 5   
   $��In Progress��6   $
��Left=�6&   $��	543,6,0,0q�6A   $	��Top=�6T   $��18(�6l   $
��Bold"�6z   �� 5   
   -   5        $��lv_inProgress��5   k      IsDropTarget . $
��Left=�6�   $	��470��6�   $��
409,45,0,0q�6�   $	��Top=�6�   $	��370��6�   $ Single=�6�   ���	#FFF9EBBB 63   �� *ListTasksInProgress+ 5      �� 5      .P�5      �� $��
Crea. Date��6%   $
 70px��69    6F   �� *
CreateDate+�� 5      $
��Task��6%   $ 230px��63    6A   �� *Note+�� 5      $��DeadLine��6%   $
 70px��67    6D   �� *
DeadLine+5      5      �� 5   
   $
��Done��6   $
��Left=�6   $��	965,6,0,0q�6:   $	��Top=�6M   $
��Bold"�6e   $��18(�6w   	 J� RenderTransformOrigin$	 1.159,0.416&�6�   �� 5    
   -   5        $��lv_done��5       $
��Left=�6"   $	��470��6=   $��
813,45,0,0q�6J   $	��Top=�6^   $	��370��6v   $ Single=�6�   ���	#FFF9EBBB 5!      �� 5"      .P�5#      �� $��
Crea. Date��6%   $
 70px��69    6F   �� *
CreateDate+�� 5$      $
��Task��6%   $ 230px��63    6A   �� *Note+�� 5%      $��DeadLine��6%   $
 70px��67    6D   �� *
DeadLine+5&      5(      �� 5)   
   -   5        $��Add task��5)   #   $
��Left=�66   $��	5,526,0,0q�6Q   $	��Top=�6d   $��90��6|   $��35��6�   �� 5*   
   -   5        $��Delete��5*   &   $
��Left=�67   $��689,526,0,0q�6R   $	��Top=�6g   $��90��6   $��35��6�   �� 5+   
   -   5        $
��Edit��5+   &   $
��Left=�65   $��346,526,0,0q�6P   $	��Top=�6e   $��90��6}   $��35��6�   �� 5,   
   -   5        $��>��5,   2   $
��Left=�6A   $��379,115,0,0q�6\   $	��Top=�6q   $��20��6�   $��20��6�   �� 5-   
   -   5        $��<��5-   2   $
��Left=�6A   $��379,146,0,0q�6\   $	��Top=�6q   $��20��6�   $��20��6�   �� 5.   
   -	   5        $��>��5.   2   $
��Left=�6A   $��785,115,0,0q�6\   $	��Top=�6q   $��20��6�   $��20��6�   $	 	5.15,0.35&�6�   �� 5/   
   -
   5        $��<��5/   2   $
��Left=�6A   $��785,146,0,0q�6\   $	��Top=�6q   $��20��6�   $��20��6�   $	 
4.25,0.375&�6�   �� 50   
   -   5        $��Logout��50   &   $
��Left=�67   $��1081,526,0,0q�6R   $	��Top=�6h   $��90��6�   $��35��6�   51      52      