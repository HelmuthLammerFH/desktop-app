   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GUI.ViewGUI.View  5          GUI.View.TourPositions   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:GUI.View     5        � DataContext  5	      ��    Locator �� Source# [   �� Path$ TourPositions�.��5
      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��109* �6   �� 5      $
��131* �6   .+�5   
   �� $��0��6   ���	#FFB4AAAA.+�5      �� -   5         ��Name$ button��5      $
��Tour��6%   $
��Left=�64   $��	10,10,0,0q�6O   $	��Top=�6b   $��80��6z   ���	#FFD6A1A1��6�   �� *	TourBtn+�� 5      -   5        $ button1��5      $��
Positionen��6&   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   $��80��6�   ���	#FFB94F4F��6�   �� *PositionsBtn+�� 5      -   5        $ button2��5      $��
Teilnehmer��6&   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   $��80��6�   ���	#FFD6A1A1��6�   �� *	MemberBtn+�� 5      -   5        $ button3��5      $��Logout��6&   $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�6e   $��80��6}   ���	#FFD6A1A1��6�   �� *	LogoutBtn+6�   5      � 5   
   $��1��6   $��2��6   .+�5      � y�6   �� *TourEntityIsEmty+.+�5      �� -   5         ��Name$ label��5      $5��/In der Übersicht wurde keine Tour ausgewählt!��6'   $
��Left=�6_   $��	10,10,0,0q�6z   $	��Top=�6�   5      � 5      y�6   �� *TourEntityIsChoosen+ 5      �� 5      $	��58* �6'   �� 5      $
��184* �6'   �� 5      $	��71* �6'   �� 5      $
��167* �6'    � RowDefinitions 5!      �� 5"      $
��243* �6$   �� 5#      $	��47* �6$   .+�5%      �� -   5        $ label2��5%      $��Positionsliste��6(   $
��Left=�6A   $��	10,10,0,0q�6\   $	��Top=�6o   $��2��6�   �� 5&      -   5         ��Name$ listBox��5&      $
��Left=�6+   $	��404��6F   $��	10,41,0,0q�6S   $	��Top=�6f   $	��460��6~   $��4��6  ��6�   �� *CurrentTourEntity.Positions+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� SelectedItem	 6�   �� *SelectedPositionItem+��5'      �� 5(      .R�5)      �  5*   "   �� 5+   &   $��* �67   .+�5-   "   �� $��0��6,   ��6<   �� *Title+5.      5/      51      �� 52      $��1��6   $��0��6*   y�6:   �� *PositionIsSelected+.+�53      �� $��Name:��6   �� 54      $��Start:��6   6/   �� 55      $��Ende:��6   6.   56      �� 57      $��1��6   $��1��6*   y�6:   �� *PositionIsSelected+.+�58      �� 
 �� 
IsReadOnly
 . $��5q�6\   ��6   �� *SelectedPositionItem.Title+6\   �� 59      $��5q�6�   ��6   �� * SelectedPositionItem.StartDate+ �� StringFormat$ {0:dd.MM.yyyy HH:mm:ss}�� �� Mode$ TwoWay=�$ PropertyChanged=�6�   �� 5:      $��5q�6�   ��6   �� *SelectedPositionItem.EndDate+$ {0:dd.MM.yyyy HH:mm:ss}��$ TwoWay=�$ PropertyChanged=�6�   5;      �� 5<      -   5        $ button5��5<      $��	Speichern��6*   $��1��6>   $��2��6K   $	��Top=�6   $��Center=�6�   ��6[   �� *SavePositionBtn+y�6�   �� *PositionIsSelected+�� 5=      -	   5        $ button4��5=      $��Löschen��6*   $
��Left=�6<   $��
82,450,0,0q�6W   $	��Top=�6k   $��75��6�   $��3��6�   ��6�   �� *DeletePositionBtn+6�   �� 5>      $��1��6   $��3��6*   .+�5?      �� $��Positionen hinzufügen��6   $��Center=�6<   $��Center=�6W   6v   �� 5@      $��5q�6   ��6*   �� *PositionList+ �� SelectedIndex 6O   �� *SelectedPosition+6|   �� 5A      $��Hinzufügen��6   $��Bottom=�62   $��Right=�6M   $��5q�6i   ��6t   �� *AddPositionToTour+6�   5B      5C      5D      5E      5F      