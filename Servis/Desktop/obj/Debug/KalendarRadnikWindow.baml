   M S B A M L   `   `   `  ����B  >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Desktop.ViewModelDesktop.ViewModel  5   	   G CWpfScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:WpfScheduler;assembly=WpfSchedulerWpfScheduler 5   	   "    Desktop.KalendarRadnikWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5	viewmodelclr-namespace:Desktop.ViewModel     5   	   IWpfScheduler0clr-namespace:WpfScheduler;assembly=WpfScheduler     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	     � Title$  
MainWindow��5   	    � 	Resources 5      5   /Desktop.ViewModel.KalendarRadnikWindowViewModel   	ViewModel��%   &	          5	   
   62   5
      .��5      � -   5        $
��grid��5   E    � DataContext 6   ��  �� Source# [   � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��* �6   6)   .+�5   
   ]� $��0��6   $��Stretch=�6!   $��Stretch=�6?   .+�5      �� -   5        $��btnPrev��5      $��10 0 0 0q�6$   $
��Left=�66   $
��Left=�6Q   $��Previous��6g   $��Center=�6z   6�   �� 5      -   5        $��btnNext��5      $��10 0 0 0q�6$   $
��Left=�66   $
��Left=�6Q   $
��Next��6g   $��Center=�6w   6�   �� 5      -   5        $��
btnModeDay��5      $��0 0 10 0q�6'   $��Right=�69   $��Right=�6U   $	��Day��6l   $��Center=�6{   6�   �� 5      -   5        $��btnModeWeek��5      $��0 0 10 0q�6(   $��Right=�6:   $��Right=�6V   $
��Week��6m   $��Center=�6}   6�   �� 5      -   5        $��btnModeMonth��5      $��0 0 10 0q�6)   $��Right=�6;   $��Right=�6W   $��Month��6n   $��Center=�6   6�   5        WpfScheduler.Scheduler  5   
   -   5        $��scheduleControl��5      $��1��5         Mode$
 Week=�5      $��Stretch=�5"      $��Stretch=�6+      StartJourney 5      �� *StartJourney+   
EndJourney 5       �� *
EndJourney+   Events 5!      �� *WpfScheduleEvents+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�5$      � 5&   
   -   5        $��	editEvent��5&      $	��400��6;   $	��350��6G   $��Center=�6T   ��6!   �� *IsOpen+.��5'      �� .��5(      �� 
���   �$��3q�6-   ._�5)      � 
������� 5*      �� 5+      $
��Auto �6,   6<   �� 5,      $��10 �6,   6:   �� 5-      $��40 �6,   6:   .+�50      �� $��0��6%   .+�52      �� .+�53   "   �� $��Subject��6(   �� 54   "     StandardWatermarkTextBox#���  6�   ��6*   ��  �� Path$ CurrentEvent.Subject� �� ValidatesOnDataErrors .  �� ValidatesOnExceptions . $	 TwoWay=�$
 PropertyChanged=�6�   55      5U      �� 5W       �� Orientation$ 
Horizontal=�6%   $��2��6>   $��Right=�6K   .+�5X      �� $��5q�6%   $��Cancel��6d   ��60   �� *CancelEditCommand+$	 OneWay=�6w   �� 5Y      $��5q�6%   $
��Save��6c   ��60   �� *SaveEventCommand+$	 OneWay=�6t   5Z      5[      5\      5]      5^      5`      5a      