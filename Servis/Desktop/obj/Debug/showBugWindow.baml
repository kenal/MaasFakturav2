   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   B >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DesktopDesktop 5   	   9!clr-namespace:Desktop.HelperClassDesktop.HelperClass 5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	   	      Desktop.showBugWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   'viewsclr-namespace:Desktop     5   	   3local!clr-namespace:Desktop.HelperClass     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	   	   -   5          �Name$  Window��5   	    � Title$ showBugWindow��5
   	   $
��1024��6   $	��900��6,   $	��600��6;   $	��600��6K    � SizeToContent$ WidthAndHeight=�6X    � WindowStartupLocation$ CenterScreen=�6w    � 	Resources 5      -  'Desktop.HelperClass.BackgroundConverter   BackgroundConverter��%   &	          5   
   6$   5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� 	 �� Path$	 DataContext.PopuniGridBug�
 �� ElementName$
 Window��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � ���#E0E0E0$��0��6$   $��2��64   $��0��6H   .+�5      �� $"��images/icons/iconShowBug.png��6   $��20��6:   $
��Left=�6F   �� 5      $
��Bugs��6   $
��Bold"�6#   $��16(�65   $��	30,-3,0,0q�6C   5       � 5"   
   -   5        $��grdBen��5"      ���#C0C0C0$��0��62   $��2��6C   $��10q�6P   .+�5#      &   System.Windows.Controls.DataGrid  -   5          Name$ 	datagrid1��5#         
IsReadOnly . $��1��6<   $��1��6�   $��4��6�   	datagrid1��   SelectionMode$ Single=�6�   ���#FFFFFF   	RowHeight$ 80Q�6*     AutoGenerateColumns .  $��Expanded&�6y  $��14(�6�     CanUserAddRows .   �� SelectedItem 6L   �� $ 	 DataContext.SelektovaniBug�$
 	datagrid1�� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���69  �� *ListaBugova+   AlternatingRowBackground 5$      �� 5%       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5&      �  � Color$ #FFFFFF��6'    � Offset$ 0Q�67   � 5'      $ #D6D6D6��6'   $ 1Q�67   � 5(      $ #D6D6D6��6'   $	 0.5Q�67   5)         Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ Geschrieben��6C   -   5        
col1_1��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5,   )   �� *datum+6X     5-      $ Benutzer��6@   -   5        
col1_2�� 5-   %   �� *idUser+6R     5.      $	 Bug��6F   -   5        
col1_3�� 5.   )   �� *	sadrzaj+6S   4
  .System.Windows.Controls.DataGridTemplateColumn
  57      $ Status��6-   -   5        
col1_4�� 
  CellTemplate 58      �� 59      .R�5:      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6C   .+�5;   &   ��   ��Name$  
btnPocetna��6-   $��5q�6A   $��35��6L   $��25��6�   ! � Cursor$
! Hand��6�   ��6W   �� *status+" �� 	Converter#" [  ��6�   �� $	 DataContext.PromjeniBug�$
 	datagrid1��6
  5<      5=      5?      
  5@      $
 Akt.��6-   -   5        
col1_5�� 5A      �� 5B      .R�5C   "   �� $ 
Horizontal=�6-   $��Center=�6G   .+�5D   &   �� $��5q�6-   $��35��68   $��25��6C   $
! Hand��6�   ��6O   �� $	 DataContext.ObrisiBug�$
 	datagrid1��.��5E   *   �� $��ikone/IkonaObrisi.png��60   5F   '   5G   #   5H      5J      5L      5M      5N      5O      