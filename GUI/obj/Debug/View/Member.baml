   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GUI.ViewGUI.View  5          GUI.View.Member   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:GUI.View     5        � DataContext  5	      ��    Locator �� Source# [   �� Path$ Member�.��5
      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���	#FFB4AAAA.+�5      �� -   5         ��Name$ button��5      $
��Tour��6%   $
��Left=�64   $��	10,10,0,0q�6O   $	��Top=�6b   $��80��6z   ���	#FFD6A1A1��6�   �� *	TourBtn+�� 5      -   5        $ button1��5      $��
Positionen��6&   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   $��80��6�   ���	#FFD6A1A1��6�   �� *PositionsBtn+�� 5      -   5        $ button2��5      $��
Teilnehmer��6&   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   $��80��6�   ���	#FFB94F4F��6�   �� *	MemberBtn+�� 5      -   5        $ button3��5      $��Logout��6&   $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�6e   $��80��6}   ���	#FFD6A1A1��6�   �� *	LogoutBtn+6�   5      � 5   
   $��1��6   .+�5      � y�6   �� *TourEntityIsEmty+.+�5      �� -   5         ��Name$ label��5      $5��/In der Übersicht wurde keine Tour ausgewählt!��6'   $
��Left=�6_   $��	10,10,0,0q�6z   $	��Top=�6�   5      � 5      y�6   �� *TourEntityIsChoosen+.+�5      �� -   5        $ label2��5      $
��Left=�6(   $��	12,45,0,0q�6C   $	��Top=�6V   $��16(�6�   $
��Bold"�6�   ��6n   �� *CurrentTourEntity.Title+6�   �� 5      -   5        $ label3��5      $
��Name��6(   $
��Left=�67   $��	12,84,0,0q�6R   $	��Top=�6e   �� 5      -   5        $ label3_Copy1��5      $��	Teilnahme��6.   $
��Left=�6B   $��
292,84,0,0q�6]   $	��Top=�6q   �� 5      -	   5         ��Name$ listBox��5      $
��Left=�6+   $	��365��6F   $��
10,115,0,0q�6S   $	��Top=�6g   $	��460��6   ��6�   �� *CurrentTourEntity.Members+ �� SelectedItem 6�   �� *CurrentSelectedMember+��5      �� 5      .R�5       �  5!   "   �� 5"   &   $	��140 �67   �� 5#   &   $	��140 �67   �� 5$   &   $	��140 �67   .+�5&   "   �� $��1��6,   ��6<   �� *	Firstname+�� 5'   "   $��0��6,   ��6<   �� *
Lastname+�� 5(   "   $��2��6+    d� 	IsChecked 6;   �� *
AttendTour+5)      5*      5,      �� 5-      $��Feedback abgeben��6   $��Bottom=�64   $��Right=�6O   $��10,30q�6k   ��6z   �� *FeedbackBtn+6�   �� 5.      $��
Bearbeiten��6   $��Bottom=�6.   $��Right=�6I   $
��10,5q�6e   ��6s   �� *	EditBtn+6�   5/      50      51      52      