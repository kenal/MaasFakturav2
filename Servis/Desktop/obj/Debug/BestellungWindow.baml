   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5       Desktop"   MassProject.BestellungWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      -   5          �Name$  Window��5       � Title$ Materialbeschtellung��5      $��1241.01��5      $	��607��6    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6_   .   (System.Windows.Interactivity.Interaction   Triggers 5	      /   )System.Windows.Interactivity.EventTrigger  5
   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6$   ��  �� Path$ DataContext.PuniCombo�	 �� ElementName$	 Window��5      .��5      � -   5        
 �Name$
 MaterialBestellungGrid��5      ���#FFFFFF � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0��6;   ���#E0E0E0$��30��6`   .+�5      �� $'��!ikone\IkonaMaterialBestellung.png��6   �� 5      $��Materialbeschtellung��6   $��14(�64   $
��Bold"�6B   $��Center=�6T   5      � 5    
   $��1��6   $��0��6   $��10q�6,   ��5!      �� 5"       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5#      �  � Color$ #FEFEFE��6#    � Offset$ 0Q�63   � 5$      $ #D7D7D7��6#   $ 1Q�63   5%       5'      �� 5(      $
��Auto �6    �� 5)      �� 5*      �� 5+       5-      �� 5.      $
��Auto �6#   �� 5/      .+�51      �� $��
Lieferant:��6   $��0��6)   $��0��69   $��0,10,0,8q�6F   $��14(�6X   �� 52      -   5        $��cmbLieferant��52      $��1��6+   $��0��6;   $	��120��6H   $��25��6T   $
��Left=�6`   $��10,0,0,0q�6{    � Cursor$
 Hand��6�   ��6�   �� *ListaDobavljaca1+ �� SelectedItem 6�   �� $&  DataContext.SelektovaniDobavljac�$	 Window����53      �� 54      .R�55      �� �� 56      �6"   �� *ime+57      58      5:      �� 5;      $��Fertigung am:��6   $��1��6,   $��0��69   $��14(�6I   $��0,0,5,0q�6W   �� 5<      $ 
Horizontal=�6   $��30��62   $	��Top=�6>   $��1��6V   $��1��6c   $��10,0,0,0q�6s   .+�5=      (  "System.Windows.Controls.DatePicker     Text$ Datum auswahlen��6   $	��150��64   �� 5>      $��  KW:��6   $��14(�6(   �� 5?      -   5        $��txtKW��5?   1   $��50��6   $��25��6%   61   �� 5@      $��  bis��6   $��14(�6(     5A      $ Datum auswahlen��6   $��0,2,0,0q�64   $	��150��6E   5B      �� 5C      $��	Bestellt:��6   $��14(�6(   $��0��66   $��2��6F   �� 5D      $ 
Horizontal=�6   $��30��62   $��2��6>   $��1��6K   $	��Top=�6[   $
��10,0q�6s   .+�5E      	� -   5         	�Name$ rdbBestellt1��5E      $��Center=�64    	� 	GroupName$ Bestellt��6O   $
 Hand��6d   $	��0,2q�6r   .��5F      �� $ 
Horizontal=�6!   }�. .+�5G      �� $��ikone/IkonaBoxRed.png��6!   $��25��6@   $��25��6K   5H      5I      	� 5J      -   5        $ rdbBestellt2��5J      $��Center=�64   $ Bestellt��6O   $
 Hand��6d   .��5K      �� $ 
Horizontal=�6!   }�. .+�5L      �� $��ikone/IkonaBoxOrange.png��6!   $��25��6C   $��25��6N   5M      5N      	� 5O      -   5        $ rdbBestellt3��5O      $��Center=�64   $ Bestellt��6O   $
 Hand��6d   .��5P      �� $ 
Horizontal=�6!   }�. .+�5Q      �� $��ikone/IkonaBoxGreen.png��6!   $��25��6B   $��25��6M   5R      5S      5T      �� 5U      $ 
Horizontal=�6   $��3��62   $
��Left=�6?   $��1��6Z   $��5,0,0,5q�6j   .+�5V      �� $��25��6   $��5,0,0,0q�6%   $
 Hand��66   .��5W      �� $ 
Horizontal=�6!   .+�5X      �� $��ikone\IkonaNeustart.png��6    �� 5Y      $��	Neustart ��6$   $��14(�65   $��Center=�6C   5Z      5[      �� 5\      $��25��6   $��5,0,0,0q�6%   $
 Hand��66   .��5]      �� $ 
Horizontal=�6!   .+�5^      �� $��ikone\IkonaPretraga.png��6    �� 5_      $��Suche ��6$   $��14(�62   $��Center=�6@   $��57��6[   $��Center=�6f   5`      5a      5b      5c      &   System.Windows.Controls.DataGrid  5d   
   -   5        $��	datagrid1��5d      $��0��6$   $��3��64      SelectionMode$ Single=�6A      AutoGenerateColumns .  $��14(�5e   #      CanUserAddRows .     
IsReadOnly .    CanUserResizeColumns . $��	12,2,22,0q�6x   ��5d   X   ��    Columns 5f      0  *System.Windows.Controls.DataGridTextColumn  5g      ,  &System.Windows.Controls.DataGridColumn   Header$ AB��6%      Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 61   -	   5        
col1_1��5g   ;     5h      $ 	Kunde Nr.��6%   $ *	 68   -
   5        
col1_2��5h   B     5i      $ Kunde��6%   $ *	 64   -   5        
col1_3��5i   >     5j      $ Produkt��6%   $ *	 66   -   5        
col1_4��5j   @     5k      $ MaterialType��6%   $ *	 6;   -   5        
col1_5��5k   E     5l      $ Material��6%   $ *	 67   -   5        
col1_6��5l   A     5m      $ Oberfläche��6%   $ *	 69   -   5        
col1_7��5m   C     5n      $ Stärke��6%   $ *	 65   -   5        
col1_8��5n   ?     5o      $ Qm��6%   $ *	 61   -   5        
col1_9��5o   ;     5p      $ Länge��6%   $ *	 64   -   5        col1_10��5p   >     5q      $ Breit��6%   $ *	 64   -   5        col1_11��5q   >     5r      $ Nr. der Platte��6%   $ *	 6=   -   5        col1_12��5r   G     5s      $ 	Fertigung��6%   $ *	 68   -   5        col1_13��5s   B     5t      $ Woche��6%   $ *	 64   -   5        col1_14��5t   >     5u      $ 	Lieferant��6%   $ *	 68   -   5        col1_15��5u   B     5v      $ Bestellt��6%   $ *	 67   -   5        col1_16��5v   A     5w      $ Aktionen��6%   $ *	 67   -   5        col1_17��5w   A   5y      �� 5z   
   $ 
Horizontal=�6   $��2��6.   $��0��6;   $��Right=�6K   $��0,0,22,5q�6g   .+�5{      �� $��Suche:��6   $��14(�6%   �� 5|      -   5         ��Name$ txtSucheMaterial��5|      $	��130��60   $��25��6<   5}      5~      5�      