   M S B A M L   `   `   `  ����  Desktop    Desktop.RechNaturstein   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  RechNaturstein��5   	   $
��1024��6    $	��900��6-   $	��600��6<   $	��600��6L    � SizeToContent$ WidthAndHeight=�6Y    � WindowStartupLocation$ CenterScreen=�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   � ���#E0E0E0$��0��6$   $��2��64   $��0��6H   .+�5      �� $"��images/icons/iconAngebot.png��6   $��30��6:   $
��Left=�6F   �� 5      $��Rechnung fur Angebot��6   $
��Bold"�63   $��16(�6E   $��	30,-3,0,0q�6S   5      � 5   
   $��0��6   $��1��6   $��10q�6,   
�������.+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	datagrid1��5      $��1��6*   $��1��6:   $��4��6G   	datagrid1��   SelectionMode$ Single=�6k   ���#FFFFFF   	RowHeight$ 30Q�6�      AutoGenerateColumns .  $��Expanded&�6�   $��14(�6�   	   CanUserAddRows	 .  ��6�   �� 
   AlternatingRowBackground
 5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ #FFFFFF��6'    � Offset$ 0Q�67   � 5      $ #D6D6D6��6'   $ 1Q�67   � 5      $ #D6D6D6��6'   $	 0.5Q�67   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6B      Header$ Rechnungs Nr��6M   -   5        
col1_1��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   )   �� *val1+6s     5      $ * 6B   $ AB��6L   -   5        
col1_2�� 5   )   �� *val2+6X     5      $ * 6B   $ 	Kunden Nr��6L   -   5        
col1_3�� 5   )   �� *val3+6_     5      $ * 6B   $ Kunde��6L   -   5        
col1_4�� 5   )   �� *val4+6[     5       $ * 6B   $ Addresse��6L   -   5        
col1_5�� 5    )   �� *val5+6^     5!      $ * 6B   $ Telefon��6L   -   5        
col1_6�� 5!   )   �� *val6+6]     5"      $ * 6B   $ E-Mail��6L   -	   5        
col1_7�� 5"   )   �� *val7+6\     5#      $ * 6B   $ Aktionen��6L   -
   5        
col1_8�� 5#   )   �� *val8+6^   5%      5&      5'      5(      