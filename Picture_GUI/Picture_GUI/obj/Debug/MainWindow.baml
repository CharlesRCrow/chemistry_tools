   M S B A M L   `   `   `  ����E  APhoto_Crow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Picture_GUIPicture_GUI  5   	       Picture_GUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Picture_GUI     5   	     � Title$  
MainWindow��5   	   $	��900��6   $
��1600��6)   .��5	      ]� $��10q�6   
����p��.+�5
   
   � $��Center=�6   $	��Top=�61   $��0,0,0,0q�6F   5      � 5   
   $��Right=�6   $��Bottom=�60   $��0,0,0,0q�6H   .+�5      �� $
��Bold"�6   $��14(�6&   
�������$��0,0,0,10q�6G   .��6Y   Charles Crow Photo App V1.06v   5      � 5   
   $
��Left=�6   $��	10,0,0,10q�6*   $	��125��6=   .+�5      �� $	��125��6   .+�5      �� -   5        $��btnOpenFile��5      $��16(�6F   $��	0,50,0,10q�6T   .��6h   	Open file6s   �� 5      -   5        $��
colorLabel��5      $
��Bold"�6+   $��14(�6=   
�������$��0,0,0,10q�6^   $y�Hidden=�6p   .��6�   Color Filter6�   �� 5      -   5        $��colorSelection��5       �� 
IsReadOnly . $y�Hidden=�5   H   5      �� 5      -   5        $��BrightnessLabel��5      $��
Brightness��6/   $��14(�6D   $
��Bold"�6R   
�������$��	0,30,0,10q�6w   $y�Hidden=�6�   �� 5      -   5        $��BrightnessSlider��5      $��Center=�6L    � Value$ 0Q�6g    �� IsSnapToTickEnabled .  � Minimum$
 -0.5Q�5       � Maximum$	 0.5Q�6$    � LargeChange$	 0.1Q�62    � SmallChange$
 0.01Q�6D    �� TickFrequency$
 0.01Q�6W   $��0,5,0,0q�6l   $y�Hidden=�6}   �� 5      -   5        $��ContrastLabel��5      $��Contrast��6-   $��14(�6@   $
��Bold"�6N   
�������$��	0,20,0,10q�6s   $y�Hidden=�6�   �� 5      -   5        $��ContrastSlider��5      $��Center=�6J   $ 0Q�6e   $y�Hidden=�6o    . $ -1Q�5      $ 1Q�6"   $	 0.2Q�6.   $
 0.02Q�6@   $
 0.02Q�6U   $��0,0,0,10q�6h   �� 5      -   5        $��	BlurLabel��5      $
��Blur��6)   $��14(�68   $
��Bold"�6F   
�������$��	0,10,0,10q�6k   $y�Hidden=�6~   �� 5      -	   5        $��
BlurSlider��5      $��Center=�6F   $ 0Q�6a   $y�Hidden=�6k    . $ 0Q�5       $ 10Q�6!   $	 0.2Q�6.   $	 0.2Q�6@   $
 0.02Q�6T   $��0,0,0,10q�6g   �� 5!      -
   5        $��mirrorButton��5!      $��16(�6B   {�.  $y�Hidden=�6b   $��	0,30,0,10q�6v   .��6�   Mirror6�   �� 5"      -   5        $��rotateButton��5"      $��16(�6B   {�.  $y�Hidden=�6b   .��6v   Rotate6~   �� 5#      -   5        $��resetButton��5#      $��16(�6:   {�.  $y�Hidden=�6Z   $��	0,50,0,10q�6n   .��6�   Reset6�   �� 5$      -   5        $��btnSaveFile��5$      $��16(�6F   {�.  $y�Hidden=�6f   $��	0,50,0,10q�6z   .��6�   	Save file6�   5%      5&      �� 5'   
   -   5        	 ��Name$	 myImage��5'      6#   5(      5)      