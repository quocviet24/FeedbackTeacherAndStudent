   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5          Project.PageChatStudent   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Project     5        N� Title$  PageChatStudent��5	       � 	Resources 5         StudentMessageTemplate �� CornerRadius �� Padding �� StringFormat  TeacherMessageTemplate%   Project.MessageTemplateSelector  MessageTemplateSelector   StudentTemplate   TeacherTemplate��%�  &	        &	 R    &	 �    7   7  �� 5   
   .R�5      �� $
��Left=�6   .+�5      �� 
����ح�$ 10��60   $ 10q�6B   $��5q�6O   $	��300��6Z   ._�5      �� .+�5      �� $
��Wrap=�6=   ��6$   �� *	Content+6=   �� 5      $��10(�6U   $��Right=�6c   ��6$   �� *	Timestamp+$ {0:G}��6c   5      5      5      5      �� 5   
   .R�5      �� $��Right=�6   .+�5      �� 
������$ 10��61   $ 10q�6C   $��5q�6P   $	��300��6[   ._�5      �� .+�5      �� $
��Wrap=�6=   ��6$   �� *	Content+6=   �� 5      $��10(�6U   $��Right=�6c   ��6$   �� *	Timestamp+$ {0:G}��6c   5      5      5      5         5"   
   8   8  5$   (   5%      .��5'      � ���	#FFC9E3EE.+�5(   
   �� -   5         ��Name$ ChatListView��5(   *   ���	#FFC9E3EE$��Stretch=�6a   $��Stretch=�6}   ��6@   �� *
Messages+��5)      �� 5*       �� ResourceKey$ MessageTemplateSelector��6!   5,      � 5-   
   $��Center=�6   $��Bottom=�61   $
��Auto��6L   .+�5.      �� -   5        $
��chat��5.   .   $	��300��6   $��30��6"   $��5q�6:   $��Center=�6E   $
��Left=�6`   	 �� TextWrapping$
	 Wrap=�6{   �� 5/      -   5        $��btnSend��5/   j   ���	#FF3E3D64$	��100��6-   $��30��69   $
��Bold"�6E   
�������$
��Send��6y   $��5q�6�   $��Center=�6�   $
��Left=�6�   6�   �� 50      -   5        $��btnBack��50   j   ���	#FF3E3D64$	��100��6-   $��30��69   $
��Bold"�6E   
�������$
��Back��6y   $��5q�6�   $��Center=�6�   $
��Left=�6�   6�   51       � 52   
   -   5        
  �Name$
 ContentFrameChat��52      $��1��6   $��Stretch=�67   $��Stretch=�6U   53      54      