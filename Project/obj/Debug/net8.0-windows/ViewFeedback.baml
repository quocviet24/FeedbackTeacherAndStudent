   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	       Project.ViewFeedback   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	     � Title$  ViewFeedback��5   	   $	��450��6   $	��800��6+   .��5	      � ���	#FFC9E3EE � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��2��6-   $��Center=�6A   $
��Bold"�6^   $��36(�6p   ���	#FF3E3D64.��6�   Feedback table6�   �� 5   
   $��1��6   $��0��6   $��Center=�6-   $
��Bold"�6J   $��18(�6\   ���	#FF3E3D64.��6�   
Question6�   �� 5   
   $��1��6   $��1��6   $��Center=�6-   $
��Bold"�6J   $��18(�6\   ���	#FF3E3D64.��6�   	Frequency6�   �� 5   
   $��2��6   $��0��6   6/   �� 5   
   $��3��6   $��0��6   ���	#FF3E3D64$
��Bold"�6D   .��6V   &$Frequency of coming to class on time6|   �� 5    
   $��4��6   $��0��6   ���	#FF3E3D64$
��Bold"�6D   .��6V   53Frequency ensures sufficient knowledge and progress6�   �� 5!   
   $��5��6   $��0��6   ���	#FF3E3D64$
��Bold"�6D   .��6V   :8Frequency of answering questions and supporting students6�   � 5#   
   $��3��6   $��1��6!   $��Center=�61   $��Center=�6N   .+�5$      �� -   5        $��	freOntime��5$   ?   ���	#FF3E3D64$
��Bold"�6-    �� 
IsReadOnly$
 True��6Q   $��0q�6c   ���	#FFC9E3EE6�   5%      � 5&   
   $��4��6   $��1��6!   $��Center=�61   $��Center=�6N   .+�5'      �� -   5        $��freFull��5'   ?   ���	#FF3E3D64$
��Bold"�6-   $
 True��6O   $��0q�6a   ���	#FFC9E3EE6�   5(      � 5)   
   $��5��6   $��1��6!   $��Center=�61   $��Center=�6N   .+�5*      �� -   5        $��
freRespone��5*   ?   ���	#FF3E3D64$
��Bold"�6-   $
 True��6R   $��0q�6d   ���	#FFC9E3EE6�   5+      �� 5,   
   $��6��6   $��0��6   $��0,25,0,0q�6.   ���	#FF3E3D64$
��Bold"�6W   .��6i   
Comments6s   &   System.Windows.Controls.DataGrid  5-   
   -   5        $��dgClass��5-      $��7��6#   $��0��60   $��2��6@   6W   �� 5.   
   -   5        $��btnBack��5.      ���	#FF3E3D64$
��Bold"�67   
�������$��9��6\   $��0��6i   $��2��6y   $��30��6�   $	��120��6�   $��0,10,0,0q�6�   .��6�   Back to classroom6�   5/      50      